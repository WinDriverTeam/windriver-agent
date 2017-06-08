using System;
using System.Linq;
using System.Net.Http;
using System.Web.Http;
using TestStack.White.UIItems.Finders;
using WinAutomationService.Models.RequestModels;
using WinAutomationService.Models.ResponseModels;
using WinAutomationService.Models.UIAutomation;
using WinAutomationService.WinAutoServices;

namespace WinAutomationService.Controllers
{
    public class AutomationElementsController : ApiController
    {
        private readonly AutomationElementService _automationElementService = Services.AutomationElement;
         
        public InteractAutomationElementResponse Post([FromBody] InteractAutomationElementRequest request)
        {
            return Services.AutomationElement.HandleInteractAutomationElementRequest(request);
        }
    }
}