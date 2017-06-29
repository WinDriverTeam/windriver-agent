namespace WinAutomationService.Models.RequestModels
{
    public class ControlApplicationRequest
    {
        public string Id { get; set; }

        public string MethodName { get; set; }

        public string Executable { get; set; }

        public string ProcessId { get; set; }

        public string ProcessName { get; set; }

        public string ApplicationName { get; set; }

        public string Arguments { get; set; }


        public override string ToString()
        {
            return $"{nameof(Id)}: {Id}, " +
                   $"{nameof(MethodName)}: {MethodName}, " +
                   $"{nameof(Executable)}: {Executable}, " +
                   $"{nameof(ProcessId)}: {ProcessId}, " +
                   $"{nameof(ProcessName)}: {ProcessName}, " +
                   $"{nameof(ApplicationName)}: {ApplicationName}" +
                   $"{nameof(Arguments)}: {Arguments}";
        }
    }
}