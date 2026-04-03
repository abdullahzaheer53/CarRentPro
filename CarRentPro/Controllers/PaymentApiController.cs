using CarRentPro.Data;
using CarRentPro.DTO;
using CarRentPro.Models;
using CarRentPro.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CarRentPro.Controllers
{
    [RoutePrefix("api/payment")]
    [Authorize]
    public class PaymentApiController : ApiController
    {
        private PaymentService paymentService = new PaymentService();

        // GET ALL PAYMENTS
        [HttpGet]
        [Route("")]
        public IHttpActionResult GetPayments()
        {
            var payments = paymentService.GetPayments();    
            return Ok(payments);

        }

        // GET PAYMENT BY ID
        [HttpGet]
        [Route("{id:long}")]
        public IHttpActionResult GetPaymentById(int id)
        {
            var payment = paymentService.GetPaymentById(id);
            return Ok(payment);
        }


    }
}
