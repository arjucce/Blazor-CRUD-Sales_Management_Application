using Microsoft.EntityFrameworkCore;
using SalesManagementApp.Server.Data;
using SalesManagementApp.Server.Interfaces;
using SalesManagementApp.Shared.Models;
using SalesManagementApp.Shared.Models.VM;

namespace SalesManagementApp.Server.Services
{
    public class ElementService : IElements
    {
        public readonly ApplicationDBContext _context;
        public ElementService(ApplicationDBContext context)
        {
            _context = context;
        }

        async Task<Subelements> IElements.Add(Subelements subelements)
        {
            var obj = await _context.Elements.AddAsync(subelements);
            _context.SaveChanges();
            return obj.Entity;
        }

        async Task<bool> IElements.Delete(int id)
        {
            try
            {
                var data = _context.Elements.FirstOrDefault(x => x.ElementId == id);
                _context.Remove(data);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }

        async Task<List<Subelements>> IElements.GetAllElements()
        {
            return await _context.Elements.ToListAsync();
        }

        async Task<List<WindowElementsVM>> IElements.GetWindowAndElements()
        {
            var result = from a in _context.Elements
                         join b in _context.Windows on a.WindowId equals b.Id
                         select new WindowElementsVM
                          {
                             ElementId = a.ElementId,
                             ElelementType = a.ElelementType,
                             Width = a.Width,
                             Height = a.Height,
                             WindowId = b.Id,
                             WindowName = b.Name,
                          };
            return await result.OrderBy(a=>a.WindowId).ToListAsync();
        }


        async Task<Subelements> IElements.GetElement(int id)
        {
            return await _context.Elements.FirstOrDefaultAsync(x => x.ElementId == id);
        }

        async Task<bool> IElements.Update(Subelements subelements)
        {
            try
            {
                _context.Elements.Update(subelements);
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
