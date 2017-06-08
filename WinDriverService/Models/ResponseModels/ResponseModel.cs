namespace WinAutomationService.Models.ResponseModels
{
    public class ResponseModel<T>
    {
        public string Message { get; set; }
        public T Entity { get; set; }

        public ResponseModel(string message)
        {
            Message = message;
        }

        public ResponseModel(string message, T entity)
        {
            Message = message;
            Entity = entity;
        }
    }
}