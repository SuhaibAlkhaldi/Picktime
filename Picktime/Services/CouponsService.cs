using Microsoft.EntityFrameworkCore;
using Picktime.Context;
using Picktime.DTOs.Category;
using Picktime.DTOs.Coupon;
using Picktime.DTOs.Errors;
using Picktime.Entities;
using Picktime.Helpers.Error;
using Picktime.Interfaces;
using System.Security.Claims;

namespace Picktime.Services
{
    public class CouponsService : ICoupon
    {
        private readonly PickTimeDbContext _context;
        private readonly IHttpContextAccessor _httpContextAccessor;
        public CouponsService(PickTimeDbContext context, IHttpContextAccessor httpContextAccessor)
        {
            _context = context;
            _httpContextAccessor = httpContextAccessor;
        }
        public async Task<AppResponse<PointsSummaryDTO>> GetAllPoints(int userId)
        {
            try
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
                if (user == null)
                    throw new Exception("User not found");

                // Calculate used points from redeemed coupons
                var usedPoints = await _context.UserRedeemedCoupons
                    .Where(rc => rc.UserId == userId)
                    .Include(rc => rc.LockUpItem)
                    .SumAsync(rc => (int?)rc.LockUpItem.Points) ?? 0;


                return new AppResponse<PointsSummaryDTO>
                {
                    Data = new PointsSummaryDTO
                    {
                        AvailablePoints = user.Points,
                        UsedPoints = usedPoints
                    }
                    
                };
            }
            catch (Exception ex)
            {
                return AppResponse<PointsSummaryDTO>.Error(new Error { Message = ErrorKeys.ErrorInGetAllPoints, Category = "Coupon" });

            }


        }


        public async Task<AppResponse<CouponDTO>> AddCoupon(AddCouponInputDTO input)
        {
            try
            {
                var lockUpType = _context.LockUpType.FirstOrDefault(t => t.Name == input.CouponName);

                if (lockUpType == null)
                {

                    lockUpType = new LockUpType
                    {
                        Name = input.CouponName
                    };
                    _context.LockUpType.Add(lockUpType);
                }



                var lockUpItem = new LockUpItems
                {
                    Points = input.Points,
                    Discount = input.Discount,
                    LockUpType = lockUpType
                };

                _context.LockUpItems.Add(lockUpItem);
                await _context.SaveChangesAsync();


                return new AppResponse<CouponDTO>
                {
                    Data = new CouponDTO
                    {
                        LockUpItemId = lockUpItem.Id,
                        CouponName = lockUpType.Name,
                        Points = lockUpItem.Points,
                        Discount = lockUpItem.Discount,
                        LockUpTypeId = lockUpType.Id
                    }

                };
            }

            catch (Exception ex)
            {
                return AppResponse<CouponDTO>.Error(new Error { Message = ErrorKeys.ErrorInAddCoupon, Category = "LockUpItem" });
            }
        }



        public async Task<AppResponse<CouponDTO>> UpdateCoupon(UpdateCouponInputDTO input)
        {
            try
            {
                var lockUpItem = await _context.LockUpItems
                    .FirstOrDefaultAsync(x => x.Id == input.Id);

                if (lockUpItem == null)
                    return AppResponse<CouponDTO>.Error(new Error { Message = "Coupon Not Found" });



                LockUpType lockUpType = null;

                if (input.LockUpTypeId.HasValue)
                {

                    lockUpType = await _context.LockUpType
                        .FirstOrDefaultAsync(t => t.Id == input.LockUpTypeId.Value);

                    if (lockUpType == null)
                        return AppResponse<CouponDTO>.Error(new Error { Message = "Coupon Not Found" });

                    if (!string.IsNullOrWhiteSpace(input.CouponName))
                    {
                        lockUpType.Name = input.CouponName;
                        _context.LockUpType.Update(lockUpType);
                    }


                    lockUpItem.LockUpTypeId = lockUpType.Id;
                }
                else
                {
                    lockUpType = await _context.LockUpType
                        .FirstOrDefaultAsync(t => t.Id == lockUpItem.LockUpTypeId);
                }


                if (input.Points.HasValue)
                    lockUpItem.Points = input.Points.Value;

                if (input.Discount.HasValue)
                    lockUpItem.Discount = input.Discount.Value;

                _context.LockUpItems.Update(lockUpItem);
                await _context.SaveChangesAsync();

                return new AppResponse<CouponDTO>
                {
                    Data = new CouponDTO
                    {
                        LockUpItemId = lockUpItem.Id,
                        CouponName = lockUpType?.Name,
                        Points = lockUpItem.Points,
                        Discount = lockUpItem.Discount,
                        LockUpTypeId = lockUpType?.Id ?? lockUpItem.LockUpTypeId
                    }

                };
            }
            catch (Exception ex)
            {
                return AppResponse<CouponDTO>.Error(new Error { Message = ErrorKeys.ErrorInUpdateCoupon, Category = "LockUpItem" });

            }
        }



        public async Task<AppResponse> DeleteCoupon(int couponId)
        {
            try
            {
                if (couponId <= 0 || couponId == null)
                    return AppResponse<CouponDTO>.Error(new Error { Message = "Invalid Coupon ID." });

                var coupon = _context.LockUpItems.Find(couponId);
                if (coupon == null)
                    return AppResponse<CouponDTO>.Error(new Error { Message = "Coupon not found" });

                _context.LockUpItems.Remove(coupon);
                await _context.SaveChangesAsync();

                return AppResponse.Success();
            }
            catch (Exception ex)
            {
                return AppResponse.Error(new Error { Message = ErrorKeys.ErrorInDeleteCoupon, Category = "LockUpItem" });

            }
        }

        public async Task<AppResponse<List<CouponDTO>>> GetAllCoupons()
        {
            try
            {
                var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);

                if (userIdClaim == null)
                {
                    return AppResponse<List<CouponDTO>>.Error(new Error { Message = "User is not authenticated. Please sign in." });
                }

                int userId = int.Parse(userIdClaim.Value);
                var user = await _context.Users.FindAsync(userId);

                if (user == null || !user.IsLoggedIn)
                {
                    return AppResponse<List<CouponDTO>>.Error(new Error { Message = "User is not signed in." });
                }

                var coupons = await(from i in _context.LockUpItems
                                    join t in _context.LockUpType on i.LockUpTypeId equals t.Id
                                    where i.IsActive == true && i.Points <= user.Points
                                    select new CouponDTO
                                    {
                                        LockUpItemId = i.Id,
                                        CouponName = t.Name,
                                        Discount = i.Discount,
                                        Points = i.Points,
                                        LockUpTypeId = i.LockUpTypeId
                                    }).ToListAsync();

                return AppResponse<List<CouponDTO>>.Success(coupons);
            }
            catch (Exception ex)
            {
                return AppResponse<List<CouponDTO>>.Error(new Error { Message = ErrorKeys.ErrorInGetCoupon, Category = "LockUpItem" });
            }
        }

        public async Task<AppResponse> RedeemCoupon(int lockUpItemId)
        {
            try
            {

                var userIdClaim = _httpContextAccessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier);

                if (userIdClaim == null)
                {
                    return AppResponse.Error(new Error { Message = "User is not authenticated. Please sign in." });
                }

                int userId = int.Parse(userIdClaim.Value);
                var user = await _context.Users.FindAsync(userId);

                if (user == null || !user.IsLoggedIn)
                {
                    return AppResponse.Error(new Error { Message = "User is not signed in." });
                }

                var coupon = await _context.LockUpItems.FirstOrDefaultAsync(c => c.Id == lockUpItemId && c.IsActive);
                if (coupon == null)
                    return AppResponse.Error(new Error { Message = "Coupon not found or inactive." });

                if (user.Points < coupon.Points)
                    return AppResponse.Error(new Error { Message = "Not enough points to redeem this coupon." });

                // Deduct points
                user.Points -= coupon.Points;
                _context.Users.Update(user);

                // Store selection (assuming you have a UserCoupons table)
                var userCoupon = new UserRedeemedCoupon
                {
                    UserId = userId,
                    LockUpItemId = lockUpItemId
                };
                await _context.UserRedeemedCoupons.AddAsync(userCoupon);

                await _context.SaveChangesAsync();

                return AppResponse.Success("Coupon redeemed successfully.");
            }
            catch (Exception ex)
            {
                return AppResponse.Error(new Error { Message = ErrorKeys.ErrorInDeleteCoupon, Category = "LockUpItem" });
            }
        }
    }
}
