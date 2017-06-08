namespace WinAutomationService.Models.RequestModels.Locate
{
    public class PropertyConditionModel
    {
        public string Name { get; set; }
        public string Value { get; set; }

        public override string ToString()
        {
            return $"{nameof(Name)}: {Name}, " +
                   $"{nameof(Value)}: {Value}";
        }
    }
}