using System;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Forms;

namespace WinAutomationService.Support
{
    public class ClickAtClickablePointExecutor : IExecutable
    {

        public AutomationElement ClickableItem { get; set; }

        public ClickAtClickablePointExecutor(AutomationElement clickableItem)
        {
            ClickableItem = clickableItem;
        }

        [DllImport("user32.dll")]
        private static extern void mouse_event(UInt32 dwFlags, UInt32 dx, UInt32 dy, UInt32 dwData, IntPtr dwExtraInfo);

        public object Execute()
        {
            Point p = ClickableItem.GetClickablePoint();
            Cursor.Position = new System.Drawing.Point((int)p.X, (int)p.Y);
            mouse_event(0x02 | 0x04, (uint)p.X, (uint)p.Y, 0, new IntPtr());
            return null;
        }
    }
}
