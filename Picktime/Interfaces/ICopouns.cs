using Picktime.DTOs;

namespace Picktime.Interfaces
{
    public interface ICopouns
    {
        Task<PointsSummaryDTO> GetAllPoints(int userId);
    }
}
