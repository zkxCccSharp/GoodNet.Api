using System;
using GoodNet.Data.Models;
using Microsoft.AspNetCore.Mvc;

namespace GoodNet.Api.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class MyInfoController : ControllerBase
    {
        private readonly ILogger<MyInfoController> _logger;

        public MyInfoController(ILogger<MyInfoController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetMyinfo")]
        public MyInfo Get()
        {
            return GoodNet.Sql.SqlOpr.GetMyInfo();
        }
    }
}

