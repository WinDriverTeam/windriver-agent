using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using TestStack.White;
using WinAutomationService.Models.RequestModels;
using WinAutomationService.Models.UIAutomation;
using WinAutomationService.Repository;

namespace WinAutomationService.WinAutoServices
{
    public class ApplicationService
    {
        private readonly ApplicationRepository _applicationRepository = new ApplicationRepository();

        // Names of Application class methods
        private const string LaunchByExecutable = "LaunchByExecutable";
        private const string AttachToProcessByExecutable = "AttachToProcessByExecutable";
        private const string AttachToProcessByProcessId = "AttachToProcessByProcessId";
        private const string AttachOrLaunchByProcessName = "AttachOrLaunchByProcessName";

        public ApplicationWrapper GetApplication(ControlApplicationRequest applicationRequest)
        {
            Application application = null;

            if (applicationRequest.MethodName == LaunchByExecutable)
                application = Application.Launch(applicationRequest.Executable);

            if (applicationRequest.MethodName == AttachToProcessByProcessId)
                application = Application.Attach(applicationRequest.ProcessId);

            if (applicationRequest.MethodName == AttachToProcessByExecutable)
                application = Application.Attach(applicationRequest.Executable);

            if (applicationRequest.MethodName == AttachOrLaunchByProcessName)
            {
                application =
                    Application.AttachOrLaunch(Process.GetProcessesByName(applicationRequest.ProcessName)[0].StartInfo);
            }
            applicationRequest.ApplicationName = application?.Name;

            return  _applicationRepository.Save(application);
        }

        public ApplicationWrapper GetApplicationDetails(string id)
        {
            var application = _applicationRepository.Get(id);
            
            return application;
        }

        public string CloseApplication(string appId)
        {
            var application = _applicationRepository.Get(appId).Application;

            var appName = application.Name;
            application.Close();
            return "Application [" + appName + "] has been successful closed";
        }
    }
}