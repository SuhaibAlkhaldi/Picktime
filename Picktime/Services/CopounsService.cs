using Microsoft.EntityFrameworkCore;
using Picktime.Context;
using Picktime.DTOs;
using Picktime.Interfaces;

namespace Picktime.Services
{
    public class CopounsService : ICopouns
    {
        private readonly PickTimeDbContext _context;
 
        public CopounsService(PickTimeDbContext context)
        {
            _context = context;
           
        }
        public async Task<PointsSummaryDTO> GetAllPoints(int userId)
        {
         
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == userId);
            if (user == null)
                throw new Exception("User not found");

            // Calculate used points from redeemed coupons
            var usedPoints = await _context.UserRedeemedCoupons
                .Where(rc => rc.UserId == userId)
                .Include(rc => rc.LockUpItem)
                .SumAsync(rc => (int?)rc.LockUpItem.Points) ?? 0;

            
            return new PointsSummaryDTO
            {
                AvailablePoints = user.Points,
                UsedPoints = usedPoints
            };
        }

    }
}
