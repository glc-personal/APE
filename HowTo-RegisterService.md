# HowTo-RegisterService

## Summary:
This HowTo goes through how to register a service for the solution.

## Content
- Notes
- Registering the Service

### Notes
In this solution every service shall have an interface and implementation.

### Registering the Service
To register a service, go to *APE.ApplicationServices* and within *ServiceConfiguration* non-presentation
layer services can be added here. Views and view models shall be registered within the *ConfigureServices*
in *App.xaml.cs*.