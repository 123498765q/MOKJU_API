using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MOKJU_API.Models;
using MOKJU_API.Services;

namespace MOKJU_API.Controllers
{
    [Route("api/payments")]
    [ApiController]
    public class PaymentController : ControllerBase
    {
        private readonly PaymentService _paymentService;

        public PaymentController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        [HttpGet]
        public ActionResult<List<Payment>> Get()
        {
            return _paymentService.Get();
        }

        [HttpGet("{id}")]
        public ActionResult<Payment> Get(string id)
        {
            var payment = _paymentService.Get(id);

            if (payment == null)
            {
                return NotFound();
            }

            return payment;
        }

        [HttpPost]
        public ActionResult<Payment> Create(Payment payment)
        {
            _paymentService.Create(payment);

            return CreatedAtRoute("GetBook", new { id = payment.Id.ToString() }, payment);
        }

        [HttpPut("{id:length(24)}")]
        public IActionResult Update(string id, Payment paymentIn)
        {
            var payment = _paymentService.Get(id);

            if (payment == null)
            {
                return NotFound();
            }

            _paymentService.Update(id, paymentIn);

            return NoContent();
        }

        [HttpDelete("{id:length(24)}")]
        public IActionResult Delete(string id)
        {
            var payment = _paymentService.Get(id);

            if (payment == null)
            {
                return NotFound();
            }

            _paymentService.Remove(payment);

            return NoContent();
        }

    }
}