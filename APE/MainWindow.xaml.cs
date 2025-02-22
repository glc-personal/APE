﻿using APE.ViewModels;
using System.Windows;
using APE.ViewModels.Shared;
using APE.ViewModels.StepContent;
using Prism.Events;
using System.Windows.Media;
using System;
using APE.UIEvents;

namespace APE
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindowViewModel ViewModel { get; set; }
        private readonly IEventAggregator _eventAggregator;

        public MainWindow(IEventAggregator eventAggregator)
        {
            InitializeComponent();

            // Setup the event aggregator
            _eventAggregator = eventAggregator;

            // Setup the view model
            ViewModel = new MainWindowViewModel(_eventAggregator);
            ViewModel.MyBannerViewModel = new BannerViewModel
            {
                Title = "Protocol Editor",
                Description = "Create, edit, and run protocols for assay development.",
                IconPath = "pack://application:,,,/Resources/protocol-editor-icon.png"
            };
            ViewModel.MyAddIconButtonViewModel = new IconButtonViewModel
            {
                IconPath = "pack://application:,,,/Resources/Images/left-arrow-icon.png",
                Command = ViewModel.ToggleAddStepPanelCommand,
                ButtonWidth = "20",
                ButtonHeight = "20",
                IconWidth = "10",
                IconHeight = "10"
            };
            ViewModel.MyProtocolInfoStampViewModel = new InfoStampViewModel
            {
                Title = "Protocol",
                Description = "-"
            };
            ViewModel.MyShortDescriptionInfoStampViewModel = new InfoStampViewModel
            {
                Title = "Short Description",
                Description = "No protocol loaded"
            };
            ViewModel.MyAuthorInfoStampViewModel = new InfoStampViewModel
            {
                Title = "Author",
                Description = "-"
            };
            ViewModel.MyStatusInfoStampViewModel = new InfoStampViewModel
            {
                Title = "Status",
                Description = "Ready"
            };
            ViewModel.MyCoordinatesInfoStampViewModel = new InfoStampViewModel
            {
                Title = "Coordiantes",
                Description = "ICP7 - A"
            };
            ViewModel.MyReagentsInfoStampViewModel = new InfoStampViewModel
            {
                Title = "Reagents",
                Description = "ICP7"
            };
            ViewModel.MyTipBoxMappingInfoStampViewModel = new InfoStampViewModel
            {
                Title = "Tip Box Mapping",
                Description = "ICP7"
            };
            ViewModel.MyVersionInfoStampViewModel = new InfoStampViewModel
            {
                Title = "Version",
                Description = "N/A",
            };
            ViewModel.MyDiscreteProgressBarViewModel = new DiscreteProgressBarViewModel(numberOfBars: 1)
            {
                PlayIconButton = new IconButtonViewModel
                {
                    IconPath = "pack://application:,,,/Resources/play-icon.png",
                    Command = ViewModel.PlayCommand,
                    ButtonWidth = "50",
                    ButtonHeight = "50",
                    IconWidth = "40",
                    IconHeight = "40"
                },
                PauseIconButton = new IconButtonViewModel
                {
                    IconPath = "pack://application:,,,/Resources/pause-icon.png",
                    Command = ViewModel.PauseCommand,
                    ButtonWidth = "50",
                    ButtonHeight = "50",
                    IconWidth = "40",
                    IconHeight = "40"
                },
                StopIconButton = new IconButtonViewModel
                {
                    IconPath = "pack://application:,,,/Resources/stop-icon.png",
                    Command = ViewModel.StopCommand,
                    ButtonWidth = "50",
                    ButtonHeight = "50",
                    IconWidth = "40",
                    IconHeight = "40"
                },
            };
            ViewModel.MyProtocolDescriptorViewModel = new DescriptorViewModel
            {
                Title = "Protocol",
                Description = "Below is the current protocol than can be run, tested, and analyzed.",
            };
            ViewModel.Status = "Ready";
            ViewModel.LinkIconPath = "pack://application:,,,/Resources/unlinked-black-icon.png";
            ViewModel.CurrentTime = DateTime.Now.ToString("hh:mm:ss tt");
            ViewModel.CurrentDate = DateTime.Now.ToString("M/d/yyyy");
            ViewModel.StatusBarBackground = Brushes.LightGray;
            ViewModel.StatusBarForeground = Brushes.Black;
            ViewModel.MyAddStepPanelViewModel = new AddStepPanelViewModel(_eventAggregator)
            {
                MyBannerViewModel = new BannerViewModel
                {
                    Title = "Add Step",
                    Description = "Add specific protocol steps to your protocol.",
                    IconPath = "pack://application:,,,/Resources/add-step-icon.png"
                },
                MyLiquidHandlingStepsDescriptorViewModel = new DescriptorViewModel
                {
                    Title = "Liquid Handling Steps",
                    Description = "Steps relating to liquid handling actions."
                },
                MyDurationStepsDescriptorViewModel = new DescriptorViewModel
                {
                    Title = "Duration Steps",
                    Description = "Steps relating to duration actions."
                },
                MyGantryStepsDescriptorViewModel = new DescriptorViewModel
                {
                    Title = "Gantry Step",
                    Description = "Steps relating to gantry actions."
                },
                MyReaderStepsDescriptorViewModel = new DescriptorViewModel
                {
                    Title = "Reader Steps",
                    Description = "Steps relating to reader actions."
                }
            };

            // Set the DataContext
            DataContext = ViewModel;

            // Subscribe to events.
            Subscribe();
        }

        private void Subscribe()
        {
            _eventAggregator.GetEvent<ToggleAddStepPanelEvent>().Subscribe(OnToggleAddStepPanel);
            _eventAggregator.GetEvent<ToggleAddSampleStepContentEvent>().Subscribe(OnToggleAddSampleStepContent);
            _eventAggregator.GetEvent<ToggleAddReagentStepContentEvent>().Subscribe(OnToggleAddReagentStepContent);
        }

        /// <summary>
        /// Triggers on toggling the Add Step Panel 
        /// </summary>
        private void OnToggleAddStepPanel()
        {
            if (MainWindowAddStepPanel.Width.Value == 0)
            {
                MainWindowAddStepPanel.Width = new GridLength(400);
                ViewModel.MyAddIconButtonViewModel.IconPath = "pack://application:,,,/Resources/Images/right-arrow-icon.png";
            }
            else
            {
                MainWindowAddStepPanel.Width = new GridLength(0, GridUnitType.Star);
                ViewModel.MyAddIconButtonViewModel.IconPath = "pack://application:,,,/Resources/Images/left-arrow-icon.png";
            }
        }

        private void ToggleStepPanelDataContent<TViewModel>(GridLength dataPanelHeight, 
            TViewModel viewModel, Action setupAction) where TViewModel : class
        {
            // Ensure that the current step content object is of type TViewModel
            if (ViewModel.StepContentObject is not TViewModel)
            {
                if (StepContent.Height.Value == 0)
                {
                    // Set the data panel height
                    StepContent.Height = dataPanelHeight;
                    // Invoke the action
                    setupAction.Invoke();
                }
                else
                {
                    // Invoke the action
                    setupAction.Invoke();
                }
            }
            else
            {
                if (StepContent.Height.Value == 0)
                {
                    // Set the data panel height
                    StepContent.Height = dataPanelHeight;
                    // Invoke the action
                    setupAction.Invoke();
                }
                else
                {
                    StepContent.Height = new GridLength(0, GridUnitType.Star);
                }
            }
        }

        private void OnToggleAddSampleStepContent()
        {
            ToggleStepPanelDataContent(new GridLength(0.8, GridUnitType.Star), 
                new AddSampleStepContentViewModel(), ViewModel.SetupStepContentDataPanel_AddSample);
        }

        private void OnToggleAddReagentStepContent()
        {
            ToggleStepPanelDataContent(new GridLength(0.8, GridUnitType.Star),
                new AddReagentStepContentViewModel(), ViewModel.SetupStepContentDataPanel_AddReagent);
        }

    }
}
