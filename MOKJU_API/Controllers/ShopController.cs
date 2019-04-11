using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc;
using MOKJU_API.Models;
using MOKJU_API.Services;

namespace MOKJU_API.Controllers
{
    [Route("api/shops")]
    [ApiController]
    public class ShopController : ControllerBase
    {
        private readonly ShopService _shopService;

        public ShopController(ShopService shopService)
        {
            _shopService = shopService;
        }

        [HttpGet]
        public ActionResult<List<Shop>> Get()
        {
            return _shopService.Get();
        }

        [HttpGet("{id:length(24)}")]
        public ActionResult<Shop> Get(string id)
        {
            var shop = _shopService.Get(id);

            if (shop == null)
            {
                return NotFound();
            }

            return shop;
        }

        [HttpPost]
        public ActionResult<Shop> Create(Shop shop)
        {
            _shopService.Create(shop);

            return CreatedAtRoute("GetBook", new { id = shop.Id.ToString() }, shop);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Shop shopIn)
        {
            var shop = _shopService.Get(id);

            if (shop == null)
            {
                return NotFound();
            }

            _shopService.Update(id, shopIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var shop = _shopService.Get(id);

            if (shop == null)
            {
                return NotFound();
            }

            _shopService.Remove(shop.Id);

            return NoContent();
        }


    }
}