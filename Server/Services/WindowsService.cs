using Microsoft.EntityFrameworkCore;
using SalesManagementApp.Server.Data;
using SalesManagementApp.Server.Interfaces;
using SalesManagementApp.Shared.Models;

namespace SalesManagementApp.Server.Services
{
    public class WindowsService : IWindows
    {
        public readonly ApplicationDBContext _context;
        public WindowsService(ApplicationDBContext context)
        {
            _context = context;
        }

        async Task<Windows> IWindows.Add(Windows windows)
        {
            var obj = await _context.Windows.AddAsync(windows);
            _context.SaveChanges();
            return obj.Entity;
        }

        async Task<bool> IWindows.Delete(int id)
        {
            try
            {
                var data = _context.Windows.FirstOrDefault(x => x.Id == id);
                _context.Remove(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
            
        }

        async Task<List<Windows>> IWindows.GetAllWindows()
        {
            return await _context.Windows.ToListAsync();
        }

        async Task<Windows> IWindows.GetWindow(int id)
        {
            return await _context.Windows.FirstOrDefaultAsync(x => x.Id == id);
        }

       async Task<bool> IWindows.Update(Windows windows)
        {
            try
            {
                _context.Windows.Update(windows);
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
