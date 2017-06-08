using System.Security.Cryptography;
using WinAutomationService.Models.UIAutomation;

namespace WinAutomationService.Models.RequestModels
{
    public class InteractAutomationElementRequest
    {
        public string WinDriverElementId { get; set; }

        public string Action { get; set; }

        public string Value { get; set; }

    }
}