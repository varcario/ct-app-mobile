
using Ct.SubFinder.Mobile.App.Controllers;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace Ct.SubFinder.Mobile.App.Pages.Skills
{
    public class SkillsViewModel : BindableBase
    {
        private readonly AppController _appController;

        public string _title;        
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand NextCommand { set; get; }

        public SkillsViewModel(AppController appController)
        {
            _appController = appController ?? throw new ArgumentException(nameof(appController));
            Title = "Skills";
            NextCommand = new DelegateCommand(OnNext);
        }

        private void OnNext()
        {
            _appController.CreateNewAccount();
        }
    }
}
