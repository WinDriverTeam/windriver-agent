using System.Windows;
using System.Windows.Automation;
using Newtonsoft.Json;
using TestStack.White.UIItems;

namespace WinAutomationService.Models.UIAutomation
{
    // ReSharper disable once InconsistentNaming
    public class AutomationElementWrapper : Persistable
    {
        private AutomationElement _automationElement;

        [JsonIgnore]
        public AutomationElement AutomationElement
        {
            get { return _automationElement; }
            set
            {
                _automationElement = value;
                var info = value.Current;
                Name = info.Name;
                ControlType = info.ControlType.ProgrammaticName;
                ClassName = info.ClassName;
                LocalizedControlType = info.LocalizedControlType;
                AcceleratorKey = info.AcceleratorKey;
                AccessKey = info.AccessKey;
                HasKeyboardFocus = info.HasKeyboardFocus;
                IsKeyboardFocusable = info.IsKeyboardFocusable;
                IsEnabled = info.IsEnabled;
                HelpText = info.HelpText;
                IsControlElement = info.IsControlElement;
                IsContentElement = info.IsContentElement;
                AutomationId = info.AutomationId;
                ItemType = info.ItemType;
                IsPassword = info.IsPassword;
                NativeWindowHandle = info.NativeWindowHandle;
                ProcessId = info.ProcessId;
                IsOffscreen = info.IsOffscreen;
                Orientation = info.Orientation;
                FrameworkId = info.FrameworkId;
                IsRequiredForForm = info.IsRequiredForForm;
                ItemStatus = info.ItemStatus;
                Orientation = info.Orientation;
                BoundingRectangle = info.BoundingRectangle;
            }
        }

        public string ControlType { get; set; }

        public string ClassName { get; set; }

        public string Name { get; set; }

        public string LocalizedControlType { get; set; }
         
        public string AcceleratorKey { get; set; }

        public string AccessKey { get; set; }

        public bool HasKeyboardFocus { get; set; }

        public bool IsKeyboardFocusable { get; set; }

        public bool IsEnabled { get; set; }

        public string HelpText { get; set; }

        public bool IsControlElement { get; set; }

        public bool IsContentElement { get; set; }

        public string AutomationId { get; set; }

        public string ItemType { get; set; }

        public bool IsPassword { get; set; } 

        public int NativeWindowHandle { get; set; }

        public int ProcessId { get; set; }

        public bool IsOffscreen { get; set; }

        public string FrameworkId { get; set; }

        public bool IsRequiredForForm { get; set; }

        public string ItemStatus { get; set; }

        public OrientationType Orientation { get; set; }
        public Rect BoundingRectangle { get; set; }

    }
}