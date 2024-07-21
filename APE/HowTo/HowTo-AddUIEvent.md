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
Ensure that the view of interest's code-behind contains a private readonly reference to Prism's
Event Aggregator. If this is the case the view should take in the event aggregator as an input
parameter, with this a subscription to our UIEvent can be setup. An example would be:
```
_eventAggregator.GetEvent<ToggleAddStepPanelEvent>().Subscribe(OnToggleAddStepPanel);
```
Where we *Get* our UIEvent and subscribe to it with an internal function, in this case we use
*OnToggleAddStepPanel* which is a private method within the view's code-behind.

### Setup Event Publishing
Ensure the view model of interest has a private readonly reference to Prism's Event Aggregator.
If this is the case it should take in the event aggregator as an input parameter, with this
the UIEvents of interest can be published. An example would be:
```
_eventAggregator.GetEvent<ToggleAddStepPanelEvent>().Publish();_
```
This publish can be placed for instance in the *Execute* method (e.g. *ExecuteAddStepPanelCommand*).