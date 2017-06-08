using System;
using System.Collections.Generic;
using System.Windows.Automation;
using WinAutomationService.Models.RequestModels.Locate;

namespace WinAutomationService.Factories
{
    public class FindOptionFactory
    {
        private static readonly IDictionary<string, FindOption> Map = new Dictionary<string, FindOption>();

        static FindOptionFactory()
        {
            Map["FindFirst"] = FindOption.FindFirst;
            Map["FindAll"] = FindOption.FindAll;
        }


        public static FindOption Get(string findOptionName)
        {
            if (Map.ContainsKey(findOptionName))
            {
                return Map[findOptionName];
            }
            throw new Exception($"Failed to create FindOption with FindOptionFactory by key {findOptionName}");
        }
    }
}