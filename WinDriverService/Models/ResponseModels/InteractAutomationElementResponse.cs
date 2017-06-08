namespace WinAutomationService.Models.ResponseModels
{
    public class InteractAutomationElementResponse
    {
        public string Message { get; set; }
        public object Entity { get; set; }

        public InteractAutomationElementResponse(string message)
        {
            Message = message;
        }

        public InteractAutomationElementResponse(string message, object entity)
        {
            Message = message;
            Entity = entity;
        }
    }
}