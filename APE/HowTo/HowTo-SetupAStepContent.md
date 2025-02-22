# HowTo-SetupAStepContent

## Summary
This HowTo goes through the details on setting up a step content within the Main Window. The step content is the region
of the main window that allows for different types of step data to be set before it is added to the protocol editor table
within the main window. Each type of step will require different parameters, and these different parameters must be 
presented to the user to set, which is why the step content is required. Each step requires a new step content view model
and data template on the main window within the Step Content region.

## Content
- Notes
- Setup the Step Content Specific View Model
- Initialize the Step Content Specific View Model within the MainWindowViewModel
- Setup the Subscription Action for when the Button is Clicked
- Setup the Data Template for the Step
- Add the Data Template to the Step Content for the Step


### Notes
Each step requires a button with a minmally descriptive content set which will toggle the step content to appear or
disappear within the *Add Step Panel*. When the step content section is toggled the step content specific view model 
shall also be initialized. Within this solution all view models for the step content shall be named as the step content
of interest and followed by StepContentViewModel, e.g. for the *Add Reagent* step the view model shall be 
*AddReagentStepContentViewModel*, the toggle for it's UIEvent shall be *ToggleAddReagentStepContent*. Every step
content specific view model shall inherit from *StepContentViewModel* so that it has a MyBannerViewModel
and a MyDescriptorViewModel.

### Setup the Step Content Specific View Model
Place all step content specific view models at *APE.ViewModels.StepContent* and name it prefixed by the type of step and
end in *StepContentViewModel*, e.g. for Add Reagent, it shall be *AddReagentStepContentViewModel*, as mentioned in the 
Notes section. Inherit *StepContentViewModel* so that each step content view model will have a MyBannerViewModel
and a MyDescriptorViewModel, any other step content specific properties shall be set in the view model. For example,
a simple case is for Add Sample:
```
public class AddSampleStepContentViewModel : StepContentViewModel 
{
	private string batch;
	private string sampleType;
	private int volume;
	private bool requiresNewTips;

	public string Batch ...
	...
	...
}
```

### Initialize the Step Content Specific View Model
Initialization of the Step Content Specific View Model shall occur in within specific *SetupStepContentDataPanel_*
methods within *MainWindowViewModel*. For example if we consider *Add Sample* we would have:
```
public void SetupStepContentDataPanel_AddSample()
        {
            StepContentObject = new AddSampleStepContentViewModel
            {
                MyStepContentViewModel = new StepContentViewModel
                {
                    MyBannerViewModel = new BannerViewModel
                    {
                        Title = "Add Sample",
                        Description = "Protocol step for adding a sample",
                        IconPath = "pack://application:,,,/Resources/Images/sample-icon.png"
                    },
                    MyDescriptorViewModel = new DescriptorViewModel
                    {
                        Title = "Add Sample",
                        Description = "Add a specific volume of sample to the corresponding Deep Well."
                    },
                },
                SampleType = "Plasma",
                Batch = "A",
                RequiresNewTips = true,
                Volume = 100
            };
        }
```

### Setup the Subscription Action for when the Button is Clicked
Within the code-behind for the MainWindow (MainWindow.xaml.cs), within the toggle method for the specific 
step, initialize the step content specific view model's banner and descritor along with setting the height
at which the step content shall be toggled at. For example:
```
private void OnToggleAddSampleStepContent()
        {
            ToggleStepPanelDataContent(new GridLength(0.8, GridUnitType.Star), 
                new AddSampleStepContentViewModel(), ViewModel.SetupStepContentDataPanel_AddSample);
        }
```
where *ToggleStepPanelDataContent* handles the opening and closing of the Data Panel within the Step Panel. You can set
the data panel height however you like, here we use the star type, the second parameter here is to ensure we either
close the data panel or create the correct one if needed, and the third parameter uses the MainWindowViewModel's method
for handling what happens when the data panel appears.

### Setup the Data Template for the Step
Each step will require their own data template so the view knows what to load dynamically for the user to see.
Provide a key for the data tempalte using the step and end with *Template*, e.g. for Add Sample the data template
can be called *AddSampleStepContentTemplate*. An example data template is:
```
<DataTemplate x:Key="AddSampleStepContentTemplate">
                        <StackPanel Orientation="Vertical">
                            <shared:Banner DataContext="{Binding MyStepContentViewModel.MyBannerViewModel}"/>
                            <shared:Descriptor DataContext="{Binding MyStepContentViewModel.MyDescriptorViewModel}"/>
                            <StackPanel Orientation="Horizontal">
                                <TextBlock Text="Batch"/>
                                <TextBox Text="{Binding MyStepContentViewModel.Batch}"/>
                            </StackPanel>
                            <StackPanel Orientation="Horizontal">
                                <TextBlock Text="Volume"/>
                                <TextBox Text="{Binding MyStepContentViewModel.Volume}"/>
                            </StackPanel>
                        </StackPanel>
</DataTemplate>
```
this shall be placed at *APE.Resources.DataTemplate* in a *resource dictionary*, the naming convention will be the 
same as the data template key name, therefore in this case we have *AddSampleStepContentTemplate.xaml*. This data template
now can be used within the MainWindow by adding it as a windows resource which will be coverered in the following section
on adding the data template.

### Add the Data Template to the Step Content for the Step
Once the data template is setup it can be used via a static resource to get the tempalte.
```
<DataTemplate DataType="{x:Type scvms:AddSampleStepContentViewModel}">
    <ContentPresenter ContentTemplate="{StaticResource AddSampleStepContentTemplate}"/>
</DataTemplate>
```