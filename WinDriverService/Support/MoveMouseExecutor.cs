using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Forms;

namespace WinAutomationService.Support
{
    public class MoveMouseExecutor : IExecutable
    {
        public AutomationElement Item { get; set; }

        public MoveMouseExecutor(AutomationElement targetItem)
        {
            Item = targetItem;
        }

        public object Execute()
        {
            Point p = Item.GetClickablePoint();
            Cursor.Position = new System.Drawing.Point((int)p.X, (int)p.Y);
            return null;
        }
    }
}
