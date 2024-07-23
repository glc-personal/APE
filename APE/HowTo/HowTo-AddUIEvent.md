# HowTo-AddUIEvent

## Summary
This HowTo goes through adding a new UIEvent within the Prism Framework's Event Aggregator. It includes
how to setup a Prism *PubSubEvent* which can be subscribed to and published via the Event Aggregator,
how to setup the code behind for a view to subscribe to the event (letting the Event Aggregator know),
and how to setup the view model of interest publish the event (letting the Event Aggregator know). Details on 
how to setup the Event Aggregator is provided at the solution level HowTo.

## Content
- Notes
- Setup a New UIEvent within the Prism Framework
- Setup Event Subscription
- Setup Event Publishing
- Example - Add Step Content - Add Reagent

### Notes
This solution designates Prism *PubSubEvents* for the UI as *UIEvents* and shall be placed at the 
*APE.UIEvents* level. The naming convention shall be a minimally descriptive prefix (e.g. if we want 
to toggle the Add Step Panel within the MainWindow, we can use the prefix *ToggleAddStepPanel*) ending
with *Event*.

### Setup a New UIEvent within the Prism Framework
All UIEvents shall be placed at *APE.UIEvents*, to create a new one, right-click on the **UIEvents** folder
within the **APE** project and add a new Class. Include *Prism.Events*:
```
using Prism.Events;
```
so that we have access to *PubSubEvent*. Set the class as *public* and inherit from *PubSubEvent*. 
An example then would look like:
```
using Prism.Events;

namespace APE.UIEvents {
	public class ToggleAddStepPanelEvent : PubSubEvent {}
}
```

### Setup Event Subscription
Ensure that the view of interest's code-behind (for this solution it is the *MainWindow*) contains a private readonly reference to Prism's
Event Aggregator. If this is the case the view should take in the event aggregator as an input
parameter, with this a subscription to our UIEvent can be setup. An example would be:
```
_eventAggregator.GetEvent<ToggleAddStepPanelEvent>().Subscribe(OnToggleAddStepPanel);
```
Where we *Get* our UIEvent and subscribe to it with an internal function, in this case we use
*OnToggleAddStepPanel* which is a private method within the view's code-behind.

### Setup Event Publishing
Ensure the view model of interest (in this example we are interested in the Add Step Content buttons, so
we are adding the publish to the *AddStepContentViewModel* has a private readonly reference to Prism's Event Aggregator.
If this is the case it should take in the event aggregator as an input parameter, with this
the UIEvents of interest can be published. An example would be:
```
_eventAggregator.GetEvent<ToggleAddStepPanelEvent>().Publish();_
```
This publish can be placed for instance in the *Execute* method (e.g. *ExecuteAddStepPanelCommand*).

### Example - Add Step Content - Add Reagent
#### Create the UIEvent 
Within *APE.UIEvents* add a new class which inherits from Prism's PubSubEvent:
```
using Prism.Events;

namespace APE.UIEvents 
{
	class ToggleAddReagentStepContentEvent : PubSubEvent {}
}
```
This event will be for when we want to toggle the Add Reagent Step Content within the MainWindow.

#### Setup the Method for Handling the UIEvent
Before setting up the subscription to the *ToggleAddReagentStepContentEvent*, we need to know how 
this event will be handled when it occurs. We create a method within *MainWindow.xaml.cs* to take 
care of this:
```
private void OnToggleAddReagentStepContent()
        {
            if (StepContent.Height.Value == 0)
            {
                StepContent.Height = new GridLength(0.8, GridUnitType.Star); 
                
                // Setup the necessary view model for this step content
                // ...
                // ...
            }
            else
            {
                StepContent.Height = new GridLength(0, GridUnitType.Star);
            }
        }
```
This method will toggle the step content section to view the Add Reagent.

#### Setup the Subscription in MainWindow.xaml.cs
In this project we are placing the subscription to the UIEvents for the Step Content within *MainWindow.xaml.cs*.
This can be done within the *Subscribe* method:
```
private void Subscribe()
        {
            _eventAggregator.GetEvent<ToggleAddStepPanelEvent>().Subscribe(OnToggleAddStepPanel);
            _eventAggregator.GetEvent<ToggleAddSampleStepContentEvent>().Subscribe(OnToggleAddSampleStepContent);
            _eventAggregator.GetEvent<ToggleAddReagentStepContentEvent>().Subscribe(OnToggleAddReagentStepContent); // <------------ 
            // ...
            // ...
        }
```
This will subscribe to the *ToggleAddReagentStepContentEvent*. This way, if we can setup the *Add Reagent* button to 
publish this event our *OnToggleAddReagentStepContent* will trigger.

#### Setup the Publish 
In this project we are placing the publish in the *AddStepPanelViewModel* (located at *APE.ViewModels*). To do this
add a private attribute for the *ICommand*:
```
private ICommand addReagentCommand;
```
and a corresponding public attribute as well as the execute and can execute methods:
```
public ICommand AddReagentCommand
        {
            get
            {
                if (addReagentCommand == null)
                {
                    addReagentCommand = new RelayCommand(ExecuteAddReagentCommand, CanExecuteAddReagentCommand);
                }
                return addReagentCommand;
            }
        }
        private void ExecuteAddReagentCommand(object parameter)
        {
            _eventAggregator.GetEvent<ToggleAddReagentStepContentEvent>().Publish();
        }
        private bool CanExecuteAddReagentCommand(object parameter)
        {
            return true;
        }
```

#### Link the ICommand to the Button
Within the *AddStepPanel.xaml* update the Add Reagent button to take the command we created within *AddStepPanelViewModel*:
```
<Button Content="Add Reagent" Command="{Binding AddReagentCommand}"
                    Style="{StaticResource AddStepWindowRightButtonStyle}"/>
```