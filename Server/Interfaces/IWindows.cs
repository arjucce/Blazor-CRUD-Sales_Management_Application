using SalesManagementApp.Shared.Models;

namespace SalesManagementApp.Server.Interfaces
{
    public interface IWindows
    {
        Task<Windows> Add(Windows windows);
        Task<bool> Update(Windows windows);
        Task<bool> Delete(int id);
        Task<List<Windows>> GetAllWindows();
        Task<Windows> GetWindow(int id);
    }
}
