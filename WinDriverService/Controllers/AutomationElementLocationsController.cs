using System.Collections.Generic;
using System.Web.Http;
using System.Windows.Automation;
using WinAutomationService.Factories;
using WinAutomationService.Models.RequestModels;
using WinAutomationService.Models.ResponseModels;
using WinAutomationService.WinAutoServices;

namespace WinAutomationService.Controllers
{
    public class AutomationElementLocationsController : ApiController
    { 
        // POST api/<controller>
        public LocateAutomationElementResponse Post([FromBody]LocateAutomationElementRequest locateAutomationElement)
        {
            return Services.AutomationElement.HandleLocateAutomationElementRequest(locateAutomationElement);
        }
         
    }
}