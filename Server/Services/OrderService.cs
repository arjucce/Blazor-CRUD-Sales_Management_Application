using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SalesManagementApp.Server.Data;
using SalesManagementApp.Server.Interfaces;
using SalesManagementApp.Shared.Models;
using SalesManagementApp.Shared.Models.VM;

namespace SalesManagementApp.Server.Services
{
    public class OrderService : IOrders
    {
        public readonly ApplicationDBContext _context;
        public OrderService(ApplicationDBContext context)
        {
            _context = context;
        }

        async Task<Orders> IOrders.Add(Orders orders)
        {
            var obj = await _context.Orders.AddAsync(orders);
            _context.SaveChanges();
            return obj.Entity;
        }

        async Task<bool> IOrders.Delete(int id)
        {
            try
            {
                var data = _context.Orders.FirstOrDefault(x => x.OrderId == id);
                _context.Remove(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        async Task<List<Orders>> IOrders.GetAllOrders()
        {
            return await _context.Orders.ToListAsync();
        }

        async Task<Orders> IOrders.GetOrder(int id)
        {
            return await _context.Orders.FirstOrDefaultAsync(x => x.OrderId == id);
        }

        async Task<List<OrderVM>> IOrders.GetOrderVM()
        {            
            var _resultOfElementJoiningWindows = (from a in _context.Orders
                                                  //join b in _context.Elements on a.WindowId equals b.WindowId
                                                  join c in _context.Windows on a.WindowId equals c.Id
                                                  select new OrderVM
                                                  {
                                                      OrderId = a.OrderId,
                                                      OrderName = a.OrderName,
                                                      OrderState = a.State,                                                      
                                                      OrderQuantity = a.Quantity,
                                                      WindowId = a.WindowId,
                                                      WindowName = c.Name,
                                                      //ElelementType = b.ElelementType
                                                  });            

            return await _resultOfElementJoiningWindows.ToListAsync();
        }        

        async Task<bool> IOrders.Update(Orders orders)
        {
            try
            {
                _context.Orders.Update(orders);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
    }
}
