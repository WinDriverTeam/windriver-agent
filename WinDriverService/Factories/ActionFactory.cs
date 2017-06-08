using System;
using System.Collections.Generic;
using System.Windows.Automation;
using WinAutomationService.Support;

namespace WinAutomationService.Factories
{
    public class ActionFactory
    {
        private static readonly IDictionary<string, Type> Actions = new Dictionary<string, Type>();

        static ActionFactory()
        {
            Actions["Click"] = typeof(InvokePatternExecutor);
            Actions["SendKeys"] = typeof(ValuePatternExecutor);
            Actions["DoubleClick"] = typeof(DoubleClickExecutor);
            Actions["ClickAtClickablePoint"] = typeof(ClickAtClickablePointExecutor);
            Actions["GetText"] = typeof(TextPatternExecutor);
            Actions["MoveMouse"] = typeof(MoveMouseExecutor);
            Actions["RightClick"] = typeof(RightClickExecutor);
        }

        public static IExecutable Get(string action, AutomationElement automationElement)
        {
            return (IExecutable)Activator.CreateInstance(Actions[action], automationElement);
        }

        public static IExecutable Get(string action, AutomationElement automationElement, string value)
        {
            return (IExecutable)Activator.CreateInstance(Actions[action], automationElement, value);
        }
    }
}