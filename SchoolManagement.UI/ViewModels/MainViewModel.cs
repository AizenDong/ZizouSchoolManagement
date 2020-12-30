﻿using Caliburn.Micro;
using SchoolManagement.UI.EventModel;
using SchoolManagement.UI.Library.API;
using SchoolManagement.UI.Library.Models;
using System.Threading;
using System.Threading.Tasks;

namespace SchoolManagement.UI.ViewModels
{
    public class MainViewModel : Conductor<object>, IHandle<LogInEvent>, IHandle<ViewType>
    {
        private readonly DashboardViewModel _dashboardViewModel;
        private readonly SimpleContainer _simpleContainer;
        private readonly IAPIHelper _apiHelper;
        private readonly IWindowManager _windowManager;
        private readonly ILoggedInUser _loggedInUser;
        private readonly IEventAggregator _events;

        private bool _isSideMenuVisible;
        private bool _isMenuBarVisible;

        public MainViewModel(DashboardViewModel dashboardViewModel,
                             SimpleContainer simpleContainer,
                             IAPIHelper apiHelper,
                             IWindowManager windowManager,
                             ILoggedInUser loggedInUser,
                             IEventAggregator events)
        {
            _dashboardViewModel = dashboardViewModel;
            _simpleContainer = simpleContainer;
            _apiHelper = apiHelper;
            _windowManager = windowManager;
            _loggedInUser = loggedInUser;
            _events = events;

            _events.SubscribeOnPublishedThread(this);

            // Initiate the View 
            GetLoginViewModel();
        }

        private void GetLoginViewModel()
        {
            ActivateItemAsync(_simpleContainer.GetInstance<LoginViewModel>());
        }

        #region IHandle Implementation
        public Task HandleAsync(ViewType message, CancellationToken cancellationToken)
        {
            switch (message)
            {
                case ViewType.AddDepartment:
                    ActivateItemAsync(_simpleContainer.GetInstance<AddDepartmentViewModel>());
                    break;
                case ViewType.AddProfessor:
                    ActivateItemAsync(_simpleContainer.GetInstance<AddProfessorViewModel>());
                    break;
                case ViewType.Department:
                    ActivateItemAsync(_simpleContainer.GetInstance<DepartmentViewModel>());
                    break;
                case ViewType.Professor:
                    ActivateItemAsync(_simpleContainer.GetInstance<ProfessorViewModel>());
                    break;
                case ViewType.Course:
                    ActivateItemAsync(_simpleContainer.GetInstance<CourseViewModel>());
                    break;
                case ViewType.AddCourse:
                    ActivateItemAsync(_simpleContainer.GetInstance<AddCourseViewModel>());
                    break;
                case ViewType.Student:
                    ActivateItemAsync(_simpleContainer.GetInstance<StudentViewModel>());
                    break;
                case ViewType.AddStudent:
                    ActivateItemAsync(_simpleContainer.GetInstance<AddStudentViewModel>());
                    break;
                case ViewType.Class:
                    ActivateItemAsync(_simpleContainer.GetInstance<ClassViewModel>());
                    break;
                case ViewType.AddClass:
                    ActivateItemAsync(_simpleContainer.GetInstance<AddClassViewModel>());
                    break;
                case ViewType.UpdateDepartment:
                    var vm = _simpleContainer.GetInstance<UpdateDepartmentViewModel>();
                    ActivateItemAsync(vm);
                    break;
                case ViewType.UpdateProfessor:
                    ActivateItemAsync(_simpleContainer.GetInstance<UpdateProfessorViewModel>());
                    break;
                case ViewType.DepartmentProfessor:
                    ActivateItemAsync(_simpleContainer.GetInstance<DepartmentProfessorViewModel>());
                    break;
                case ViewType.UpdateStudent:
                    ActivateItemAsync(_simpleContainer.GetInstance<UpdateStudentViewModel>());
                    break;
                case ViewType.UpdateCourse:
                    break;
                case ViewType.ShowCourse:
                    break;
                case ViewType.ShowClass:
                    ActivateItemAsync(_simpleContainer.GetInstance<ShowClassViewModel>());
                    break;
                case ViewType.UpdateClass:
                    ActivateItemAsync(_simpleContainer.GetInstance<UpdateClassViewModel>());
                    break;
                default:
                    break;
            };
            return Task.CompletedTask;
        }

        public Task HandleAsync(LogInEvent logInEvent, CancellationToken cancellationToken)
        {
            ActivateItemAsync(_dashboardViewModel);
            IsSideMenuVisible = true;
            IsMenuBarVisible = true;
            return Task.CompletedTask;
        }

        public Task GetDashbord()
        {
            ActivateItemAsync(_simpleContainer.GetInstance<DashboardViewModel>());
            IsSideMenuVisible = true;
            IsMenuBarVisible = true;
            return Task.CompletedTask;
        }

        public Task GetStudent()
        {
            ActivateItemAsync(_simpleContainer.GetInstance<StudentViewModel>());
            IsSideMenuVisible = true;
            IsMenuBarVisible = true;
            return Task.CompletedTask;
        }

        public Task GetClass()
        {
            ActivateItemAsync(_simpleContainer.GetInstance<ClassViewModel>());
            IsSideMenuVisible = true;
            IsMenuBarVisible = true;
            return Task.CompletedTask;
        }

        public Task GetDepartment()
        {
            ActivateItemAsync(_simpleContainer.GetInstance<DepartmentViewModel>());
            IsSideMenuVisible = true;
            IsMenuBarVisible = true;
            return Task.CompletedTask;
        }

        public Task GetCourse()
        {
            ActivateItemAsync(_simpleContainer.GetInstance<CourseViewModel>());
            IsSideMenuVisible = true;
            IsMenuBarVisible = true;
            return Task.CompletedTask;
        }

        public Task GetProfessor()
        {
            ActivateItemAsync(_simpleContainer.GetInstance<ProfessorViewModel>());
            IsSideMenuVisible = true;
            IsMenuBarVisible = true;
            return Task.CompletedTask;
        }
        #endregion

        #region LogOut Command
        public bool CanLogOut
        {
            get { return true; }
        }

        public void LogOut()
        {
            _loggedInUser.Clear();
            IsSideMenuVisible = IsMenuBarVisible = false;
            ActivateItemAsync(_simpleContainer.GetInstance<LoginViewModel>());
        } 
        #endregion
        #region Public Prop

        public bool IsSideMenuVisible
        {
            get { return _isSideMenuVisible; }
            set 
            { 
                _isSideMenuVisible = value;
                NotifyOfPropertyChange(() => IsSideMenuVisible);
            }
        }

        public bool IsMenuBarVisible
        {
            get { return _isMenuBarVisible; }
            set 
            {
                _isMenuBarVisible = value;
                NotifyOfPropertyChange(() => IsMenuBarVisible);
            }
        }
        #endregion
    }
}
