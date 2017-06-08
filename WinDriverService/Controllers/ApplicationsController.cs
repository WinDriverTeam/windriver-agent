using System;
using System.Web.Http;
using WinAutomationService.Models.RequestModels;
using WinAutomationService.Models.ResponseModels;
using WinAutomationService.Models.UIAutomation;
using WinAutomationService.WinAutoServices;

namespace WinAutomationService.Controllers
{
    public class ApplicationsController : ApiController
    {
        // GET
        public object Get(string id)
        {
            try
            {
                Console.WriteLine("Start Get Application Details for id=" + id);
                return new ResponseModel<ApplicationWrapper>("Application Details.",
                    Services.Application.GetApplicationDetails(id));
            }
            catch ( Exception e)
            {
                return new ResponseModel<Exception>("Error occured while Getting Application Details for id=" + id, e);
            }
        }

        // POST WinAuto/Application
        public object Post([FromBody] ControlApplicationRequest applicationRequest)
        {
            try
            {
                Console.WriteLine("Start Launching application " + applicationRequest);
                var app = Services.Application.GetApplication(applicationRequest);
                return new ResponseModel<ApplicationWrapper>("Application has been started.", app);
            }
            catch (Exception e)
            {
                return new ResponseModel<Exception>("Error occured while starting application", e);
            }
        }

        public object Delete(string id)
        {
            try
            {
                return Services.Application.CloseApplication(id);
            }
            catch (Exception e)
            {
                return "Exception occured" + e;
            }
        }
    }
}