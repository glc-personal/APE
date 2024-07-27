# HowTo-AddNewSharedUserControl

## Summary
This HowTo goes through the details on setting up a new User Control that is *shared* (i.e. common and can be
reused). 

## Contetnt
- Notes
- Setup the View Model
- Setup the User Control (View)
- Use Elsewhere

### Notes
In this solution shared user controls shall be placed in *APE.View.Shared* and their view models shall
be placed in *APE.ViewModels.Shared*. The names of the user controls shall be minimally desciptive and their
view models shall share the same name but be suffixed by *ViewModel*. When using a user control's view model
elsewhere, the instance shall use the user control or user control's view models name but prefixed by *My*.
For example, if we have a user control called *IconButton*, it's view model is *IconButtonViewModel*, and
if the view model is used elsewhere the instance shall be named *MyIconButtonViewModel*.

### Setup the View Model
Start be setting up the view model so that binding in the user control view is easier in the sense that the
data binding variable names will already be setup. All view models for the shared user controls shall be
placed at *APE.ViewModels.Shared* and suffixed with *ViewModel*. When the view model is setup ensure that it 
inherits *ViewModelBase* so that it has the *INotifyPropertyChanged* methods and event. For an example look
at any of the current existing view models in *APE.ViewModels.Shared*.

### Setup the User Control (View)
Once the view model is setup use the view model's public attributes to bind. Any example in 
*APE.Views.Shared* can be seen.

### Use Elsewhere
As previously mentioned, instanes of the user control's view model shall be prefixed with *My*. To use the
shared user controls ensure to add:
```
<xmlns:shared="clr-namespace:APE.Views.Shared">
```
to the views header. These references shall always be named *shared* in this solution for consistency.