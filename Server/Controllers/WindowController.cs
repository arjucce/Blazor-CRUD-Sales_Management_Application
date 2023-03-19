using Microsoft.AspNetCore.Mvc;
using SalesManagementApp.Server.Interfaces;
using SalesManagementApp.Shared.Models;

namespace SalesManagementApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class WindowController : ControllerBase
    {
        private readonly IWindows _windows;
        public WindowController(IWindows windows)
        {
            _windows = windows;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var windows = await _windows.GetAllWindows();
            return Ok(windows);            
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Windows windows = await _windows.GetWindow(id);
            if (windows != null)
            {
                return Ok(windows);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(Windows windows)
        {
            _windows.Add(windows);
        }

        [HttpPut]
        public void Put(Windows windows)
        {
            _windows.Update(windows);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _windows.Delete(id);
            return Ok();
        }
    }
}
