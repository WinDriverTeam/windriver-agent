using System.Collections.Generic;
using WinAutomationService.Models.RequestModels;
using WinAutomationService.Models.RequestModels.Locate;
using WinAutomationService.Models.UIAutomation;

namespace WinAutomationService.Models.ResponseModels
{
    public class LocateAutomationElementResponse
    {
        public List<AutomationElementWrapper> AutomationElementWrappers { get; set; }
    }
}