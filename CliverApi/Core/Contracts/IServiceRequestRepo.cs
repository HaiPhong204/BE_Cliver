using CliverApi.DTOs;
using CliverApi.DTOs.RequestFeatures;
using CliverApi.Models;

namespace CliverApi.Core.Contracts
{
    public interface IServiceRequestRepo : IGenericRepository<ServiceRequest>
    {
        Task<ServiceRequest> CreateServiceRequest(string userId, CreateServiceRequestDto createDto);
        Task DeleteServiceRequest(int id, string userId);
        Task<IEnumerable<ServiceRequest>> GetServiceRequests(string userId, Common.Enum.Mode mode);
        Task<ServiceRequest> GetServiceRequestDetail(int id, string userId);
        Task MarkDoneServiceRequest(int id, string userId);
        Task UpdateServiceRequest(int id, string userId, UpdateServiceRequestDto updateDto);
    }
}
