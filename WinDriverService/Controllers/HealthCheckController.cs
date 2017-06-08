using System;
using System.Web.Http;
using WinAutomationService.Models.RequestModels;
using WinAutomationService.Models.ResponseModels;
using WinAutomationService.Models.UIAutomation;
using WinAutomationService.WinAutoServices;

namespace WinAutomationService.Controllers
{
    public class HealthCheckController : ApiController
    {
        // GET
        public HealthStatusModel Get()
        {
            return new HealthStatusModel
            {
                Status = "OK",
                Message = "Service is running"
            };
        }

        
    }

    public class HealthStatusModel
    {
        public string Status { get; set; }
        public string Message { get; set; }
    }
}