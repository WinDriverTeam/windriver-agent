using System.Collections.Generic;
using WinAutomationService.Models.RequestModels.Locate;

namespace WinAutomationService.Models.RequestModels
{
    public class LocateAutomationElementRequest
    {
        public string TreeWalkerType { get; set; }
        public string SearchScope { get; set; }
        public string ParrentWinDriverElementId { get; set; }
        public string FindOption { get; set; }
        public List<PropertyConditionModel> PropertyConditionModels { get; set; }

        public override string ToString()
        {
            return $"{nameof(TreeWalkerType)}: {TreeWalkerType}, " +
                   $"{nameof(SearchScope)}: {SearchScope}, " +
                   $"{nameof(ParrentWinDriverElementId)}: {ParrentWinDriverElementId}, " +
                   $"{nameof(FindOption)}: {FindOption}, " +
                   $"{nameof(PropertyConditionModels)}: " +
                   $"{PropertyConditionModels}";
        }
    }
}