using System;
using System.Collections.Generic;
using System.Windows.Automation;
using TestStack.White;
using WinAutomationService.Models.UIAutomation;

namespace WinAutomationService.Repository
{
    public class AutomationElementRepository : AbstractRepository<AutomationElementWrapper>
    {
        public AutomationElementWrapper Save(AutomationElement automationElement)
        {
            return Save(new AutomationElementWrapper()
            {
                AutomationElement = automationElement
            });
        }
    }


    public class ApplicationRepository : AbstractRepository<ApplicationWrapper>
    {
        public ApplicationWrapper Save(Application application)
        {
            var uiApplication = new ApplicationWrapper {Application = application};
            Save(uiApplication);
            return uiApplication;
        }
    }

    public abstract class AbstractRepository<T> where T : Persistable
    {
        private static readonly IDictionary<string, T> Container =
            new Dictionary<string, T>();

        public Type DerivedType { get; set; }


        public T Save(T t)
        {
            var id = Guid.NewGuid().ToString();
            t.WinDriverElementId = id;
            Container.Add(id, t);
            return t;
        }

        public T Get(string id)
        {
            return Container[id];
        }

        public IEnumerable<T> GetAll()
        {
            return Container.Values;
        }
    }
}