using System.Collections.Generic;
using Newtonsoft.Json;
using TestStack.White;

namespace WinAutomationService.Models.UIAutomation
{
    // ReSharper disable once InconsistentNaming
    public class ApplicationWrapper : Persistable
    {

        [JsonIgnore]
        public Application Application { get; set; }
    }
}