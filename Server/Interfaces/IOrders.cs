using SalesManagementApp.Shared.Models;
using SalesManagementApp.Shared.Models.VM;

namespace SalesManagementApp.Server.Interfaces
{
    public interface IOrders
    {
        Task<Orders> Add(Orders orders);
        Task<bool> Update(Orders orders);
        Task<bool> Delete(int id);
        Task<List<Orders>> GetAllOrders();
        Task<Orders> GetOrder(int id);
        Task<List<OrderVM>> GetOrderVM();
    }
}
