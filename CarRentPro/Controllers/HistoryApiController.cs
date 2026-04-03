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
    [RoutePrefix("api/history")]
    [Authorize]
    public class HistoryApiController : ApiController
    {
        private HistoryService historyService = new HistoryService();

        [HttpGet]
        [Route("")]
        public IHttpActionResult GetHistory()
        {
            var history=historyService.GetHistory();
            return Ok(history);
        }


        // GET HISTORY BY ID
        [HttpGet]
        [Route("{id:int}")]
        public IHttpActionResult GetHistoryById(long id)
        {
            var history = historyService.GetHistoryById(id);
            return Ok(history);
        }


    }
}
