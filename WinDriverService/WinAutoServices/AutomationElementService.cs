using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Automation;
using Castle.Core.Internal;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using WinAutomationService.Factories;
using WinAutomationService.Models.RequestModels;
using WinAutomationService.Models.RequestModels.Locate;
using WinAutomationService.Models.ResponseModels;
using WinAutomationService.Models.UIAutomation;
using WinAutomationService.Repository;
using WinAutomationService.Support;

namespace WinAutomationService.WinAutoServices
{
    // ReSharper disable once InconsistentNaming
    public class AutomationElementService
    {
        // Names of Action methods
        private const string Click = "Click";
        private const string SendKeys = "SendKeys";
        private const string DoubleClick = "DoubleClick";
        private const string ClickAtClickablePoint = "ClickAtClickablePoint";
        private const string GetText = "GetText";
        private const string MoveMouse = "MoveMouse";
        private const string RightClick = "RightClick";

        private readonly AutomationElementRepository _automationElementRepository = new AutomationElementRepository();

        public AutomationElementWrapper GetElementById(string elementId)
        {
            return _automationElementRepository.Get(elementId);
        }

        public string PerformAction(string automationElementId, string requestAction)
        {
            throw new System.NotImplementedException();
        }

        public LocateAutomationElementResponse HandleLocateAutomationElementRequest(
            LocateAutomationElementRequest request)
        {
            Console.WriteLine("Start HandleLocateAutomationElementRequest : " + request);
            // Results that will be returned from method
            var results = new List<AutomationElementWrapper>();

            // Base node
            var baseNode = (string.IsNullOrEmpty(request.ParrentWinDriverElementId))
                ? AutomationElement.RootElement
                : _automationElementRepository.Get(request.ParrentWinDriverElementId).AutomationElement;

            // Find Option (One or Many) to be found
            var findOption = FindOptionFactory.Get(request.FindOption);

            // Tree scope where elements should be found
            var treeScope = TreeScopeFactory.Get(request.SearchScope);

            // Create condition (Single or Multi)
            Condition condition = null;
            if (request.PropertyConditionModels.Count == 1)
            {
                var propertyConditionModel = request.PropertyConditionModels[0];
                condition = ConditionFactory.Get(propertyConditionModel.Name, propertyConditionModel.Value);
            }
            else if (request.PropertyConditionModels.Count > 1)
            {
                var propertyConditions = (from pc in (request.PropertyConditionModels)
                    select ConditionFactory.Get(pc.Name, pc.Value)).ToArray();
                condition = new AndCondition(propertyConditions);
            }

            // Select find style (First or Many) Automation Elements to be found
            if (findOption == FindOption.FindFirst)
            {
                var automationElement = baseNode.FindFirst(treeScope, condition);
                results.Add(_automationElementRepository.Save(automationElement));
            }
            else
            {
                var automationElements = baseNode.FindAll(treeScope, condition).OfType<AutomationElement>().ToList();
                results.AddRange(automationElements.Select(ae => _automationElementRepository.Save(ae)));
            }

            return new LocateAutomationElementResponse
            {
                AutomationElementWrappers = new List<AutomationElementWrapper>(results)
            };
        }

        public InteractAutomationElementResponse HandleInteractAutomationElementRequest(InteractAutomationElementRequest request)
        {
            var automationElementWrapper = _automationElementRepository.Get(request.WinDriverElementId);

            IExecutable executable = null;

            if (request.Action == Click || request.Action == DoubleClick || request.Action == ClickAtClickablePoint
                || request.Action == GetText || request.Action == MoveMouse || request.Action == RightClick)
                executable = ActionFactory.Get(request.Action, automationElementWrapper.AutomationElement);

            if (request.Action == SendKeys)
                executable = ActionFactory.Get(request.Action, automationElementWrapper.AutomationElement, request.Value);
            
            return new InteractAutomationElementResponse("Action was performed successfully", executable.Execute());
        }
                       
    }
}