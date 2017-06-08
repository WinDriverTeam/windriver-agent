using System.Windows.Automation;
using System.Windows.Forms;

namespace WinAutomationService.Support
{
    public class ValuePatternExecutor : IExecutable
    {

        public AutomationElement InvocableItem { get; set; }
        public string Value { get; set; }

        public ValuePatternExecutor(AutomationElement invocableItem, string value)
        {
            InvocableItem = invocableItem;
            Value = value;
        }

        public object Execute()
        {
            object valuePattern = null;

            if (!InvocableItem.TryGetCurrentPattern(ValuePattern.Pattern, out valuePattern))
            {
                InvocableItem.SetFocus();
                SendKeys.SendWait(Value);
            }
            else
            {
                InvocableItem.SetFocus();
                ((ValuePattern)valuePattern).SetValue(Value);
            }
            return null;
        }
    }
}
