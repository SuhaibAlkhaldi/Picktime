using Microsoft.EntityFrameworkCore;
using Picktime.Context;
using Picktime.DTOs;
using Picktime.DTOs.Coupon;
using Picktime.DTOs.Provider;
using Picktime.Entities;
using Picktime.Heplers;
using Picktime.Interfaces;

namespace Picktime.Services
{
    public class LockUpItemService : ILockUpItem
    {
        private readonly PickTimeDbContext _context;

        public LockUpItemService(PickTimeDbContext context)
        {
            _context = context;
        }

        public async Task<AppResponse<CouponDTO>> AddCoupon(AddCouponInputDTO input)
        {
            try
            {
                var lockUpType =  _context.LockUpType.FirstOrDefault(t => t.Name == input.CouponName);

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

                var coupon =  _context.LockUpItems.Find(couponId);
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
    }
}
