using CliverApi.Models;

namespace CliverApi.Core.Contracts
{
    public interface IRoomRepository
    {
        Task<List<string>> GetMembersInRoom(int Id);
        Task<List<Room>> GetRoomsOfUser(string userId);
        Task<Room?> GetRoomDetail(string userId, int roomId);
        Task<Room?> GetRoomWithPartnerId(string userId, string partnerId);
    }
}
