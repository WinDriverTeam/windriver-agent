using System.Windows.Automation;
using System.Windows.Forms;

namespace WinAutomationService.Support
{
    public class TextPatternExecutor : IExecutable
    {

        public AutomationElement Element { get; set; }

        public TextPatternExecutor(AutomationElement element)
        {
            Element = element;
        }

        public object Execute()
        {
            object patternObj;
            if (Element.TryGetCurrentPattern(TextPattern.Pattern, out patternObj))
            {
                var textPattern = (TextPattern)patternObj;
                return textPattern.DocumentRange.GetText(-1);
            }
            else if (Element.TryGetCurrentPattern(ValuePattern.Pattern, out patternObj))
            {
                var valuePattern = (ValuePattern)patternObj;
                return valuePattern.Current.Value;
            }
            else
            {
                return Element.Current.Name;
            }
        }
    }
}
