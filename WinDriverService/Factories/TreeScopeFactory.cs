using System;
using System.Collections.Generic;
using System.Windows.Automation;

namespace WinAutomationService.Factories
{
    public class TreeScopeFactory
    {
        private static readonly IDictionary<string, TreeScope> Map = new Dictionary<string, TreeScope>();

        static TreeScopeFactory()
        {
            Map["AutomationElement"] = TreeScope.Element;
            Map["Children"] = TreeScope.Children;
            Map["Descendants"] = TreeScope.Descendants;
            Map["Subtree"] = TreeScope.Subtree;
            Map["Parent"] = TreeScope.Parent;
            Map["Ancestors"] = TreeScope.Ancestors;
        }

        private TreeScopeFactory()
        {
        }

        public static TreeScope Get(string scopeName)
        {
            if (Map.ContainsKey(scopeName))
            {
                return Map[scopeName];
            }
            throw new Exception($"Failed to create TreeScope for key {scopeName}");
        }
    }
}