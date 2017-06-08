using System;
using System.Collections.Generic;
using System.Windows.Automation;

namespace WinAutomationService.Factories
{
    public class ConditionFactory
    {

        private static readonly IDictionary<string,AutomationProperty> Map= new Dictionary<string, AutomationProperty>();

          static ConditionFactory ()
          {
            Map["IsControlElementProperty"] = AutomationElementIdentifiers.IsControlElementProperty;
            Map["ControlTypeProperty"] = AutomationElementIdentifiers.ControlTypeProperty;
            Map["IsContentElementProperty"] = AutomationElementIdentifiers.IsContentElementProperty;
            Map["LabeledByProperty"] = AutomationElementIdentifiers.LabeledByProperty;
            Map["NativeWindowHandleProperty"] = AutomationElementIdentifiers.NativeWindowHandleProperty;
            Map["AutomationIdProperty"] = AutomationElementIdentifiers.AutomationIdProperty;
            Map["ItemTypeProperty"] = AutomationElementIdentifiers.ItemTypeProperty;
            Map["IsPasswordProperty"] = AutomationElementIdentifiers.IsPasswordProperty;
            Map["LocalizedControlTypeProperty"] = AutomationElementIdentifiers.LocalizedControlTypeProperty;
            Map["NameProperty"] = AutomationElementIdentifiers.NameProperty;
            Map["AcceleratorKeyProperty"] = AutomationElementIdentifiers.AcceleratorKeyProperty;
            Map["AccessKeyProperty"] = AutomationElementIdentifiers.AccessKeyProperty;
            Map["HasKeyboardFocusProperty"] = AutomationElementIdentifiers.HasKeyboardFocusProperty;
            Map["IsKeyboardFocusableProperty"] = AutomationElementIdentifiers.IsKeyboardFocusableProperty;
            Map["IsEnabledProperty"] = AutomationElementIdentifiers.IsEnabledProperty;
            Map["BoundingRectangleProperty"] = AutomationElementIdentifiers.BoundingRectangleProperty;
            Map["ProcessIdProperty"] = AutomationElementIdentifiers.ProcessIdProperty;
            Map["RuntimeIdProperty"] = AutomationElementIdentifiers.RuntimeIdProperty;
            Map["ClassNameProperty"] = AutomationElementIdentifiers.ClassNameProperty;
            Map["HelpTextProperty"] = AutomationElementIdentifiers.HelpTextProperty;
            Map["ClickablePointProperty"] = AutomationElementIdentifiers.ClickablePointProperty;
            Map["CultureProperty"] = AutomationElementIdentifiers.CultureProperty;
            Map["IsOffscreenProperty"] = AutomationElementIdentifiers.IsOffscreenProperty;
            Map["OrientationProperty"] = AutomationElementIdentifiers.OrientationProperty;
            Map["FrameworkIdProperty"] = AutomationElementIdentifiers.FrameworkIdProperty;
            Map["IsRequiredForFormProperty"] = AutomationElementIdentifiers.IsRequiredForFormProperty;
            Map["ItemStatusProperty"] = AutomationElementIdentifiers.ItemStatusProperty;
        }

        private ConditionFactory()
        {
        }

        public static Condition Get(string propertyConditionName, string propertyConditionValue)
        {
            if (propertyConditionName.Equals("TrueCondition"))
            {
                return Condition.TrueCondition;
            }

            if (Map.ContainsKey(propertyConditionName))
            {
                return new PropertyCondition(Map[propertyConditionName],propertyConditionValue);
            }
            throw new Exception($"Failed to create PropertyCondition for key {propertyConditionName}");
        }
    }
}