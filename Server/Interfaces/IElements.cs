using SalesManagementApp.Shared.Models;
using SalesManagementApp.Shared.Models.VM;

namespace SalesManagementApp.Server.Interfaces
{
    public interface IElements
    {
        Task<Subelements> Add(Subelements subelements);
        Task<bool> Update(Subelements subelements);
        Task<bool> Delete(int id);
        Task<List<Subelements>> GetAllElements();
        Task<Subelements> GetElement(int id);
        Task<List<WindowElementsVM>> GetWindowAndElements();
    }
}
