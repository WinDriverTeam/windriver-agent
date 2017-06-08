using System;

namespace WinAutomationService.WinAutoServices
{
    public class Services
    {
        private static readonly Lazy<ApplicationService> ApplicationServiceLazy =
            new Lazy<ApplicationService>(() => new ApplicationService());
         
        private static readonly Lazy<AutomationElementService> ElementServiceLazy =
            new Lazy<AutomationElementService>(() => new AutomationElementService());

        public static ApplicationService Application => ApplicationServiceLazy.Value;
         
        public static AutomationElementService AutomationElement => ElementServiceLazy.Value;
    }
}