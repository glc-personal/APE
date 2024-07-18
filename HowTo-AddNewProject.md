# HowTo-AddNewProject

## Summary
This HowTo goes through adding a new project to the APE solution.

## Content
- Notes
- Adding a Project
- Updating the Project

### Notes
The project naming convention for the APE solution is to prefix each project with *APE* and appending
words with a *.*. For example, to create a new Utilities project it would be named *APE.Utilities*. All subordenents
relating to a project will be placed in the folder at the *APE.Project* level, any further additions to this convention
will be done through project folder structures. Back to our example, if we want a *APE.Utilities.Conversions*, *Conversions*, 
would be a folder within *APE.Utilities*.

### Adding a Project
Within **Solution Explorer**, right-click on **Solution 'APE'**, and select **Add** > **New Project**. Name the project
based on the solution project naming convention. The .NET Framework can be set to 4.7.2, but will need to be updated
via the Visual Studio Update Assistance extension tool.

### Updating the Project
Once the project is created, it will need to be updated. To update the project, within **Solution Explorer**, right-click on the 
desired project and select **Upgrade**. This upgrade can be done **In-place** and select to update .NET to version 8.0.