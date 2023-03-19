using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SalesManagementApp.Server.Interfaces;
using SalesManagementApp.Shared.Models;

namespace SalesManagementApp.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ElementController : ControllerBase
    {
        private readonly IElements _elements;
        public ElementController(IElements elements)
        {
            _elements = elements;
        }

        [HttpGet]        
        public async Task<IActionResult> GetWindowAndElements()
        {
            var data = await _elements.GetWindowAndElements();
            return Ok(data);
        }
        
        [HttpGet("GetAllElements")]
        public async Task<IActionResult> GetAllElements()
        {
            var data = await _elements.GetAllElements();
            return Ok(data);
        }


        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            Subelements subelements = await _elements.GetElement(id);
            if (subelements != null)
            {
                return Ok(subelements);
            }
            return NotFound();
        }

        [HttpPost]
        public void Post(Subelements subelements)
        {
            _elements.Add(subelements);
        }

        [HttpPut]
        public void Put(Subelements subelements)
        {
            _elements.Update(subelements);
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            _elements.Delete(id);
            return Ok();
        }
    }
}
