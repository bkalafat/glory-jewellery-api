using System.Collections.Generic;
using GloryJewelleryApi.Models;
using GloryJewelleryApi.Services;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace GloryJewelleryApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JewelleryController : ControllerBase
    {
        private readonly IJewelleryService _jewelleryService;

        public JewelleryController(IJewelleryService jewelleryService)
        {
            _jewelleryService = jewelleryService;
        }

        // GET: api/<JewelleryController>
        [HttpGet]
        public IEnumerable<Jewellery> Get()
        {
            return _jewelleryService.Get();
        }

        // GET api/<JewelleryController>/5
        [HttpGet("{id}")]
        public Jewellery Get(string id)
        {
            return _jewelleryService.Get(id);
        }

        // POST api/<JewelleryController>
        [HttpPost]
        public Jewellery Post([FromBody] Jewellery jewellery)
        {
            return _jewelleryService.Create(jewellery);
        }

        // PUT api/<JewelleryController>/5
        [HttpPut("{id}")]
        public void Put(string id, [FromBody] Jewellery newJewellery)
        {
            _jewelleryService.Update(id, newJewellery);
        }

        // DELETE api/<JewelleryController>/5
        [HttpDelete("{id}")]
        public void Delete(string id)
        {
            _jewelleryService.Remove(id);
        }
    }
}