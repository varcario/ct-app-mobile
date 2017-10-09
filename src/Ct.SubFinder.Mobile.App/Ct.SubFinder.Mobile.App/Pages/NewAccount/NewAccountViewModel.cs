
using Ct.SubFinder.Mobile.App.Controllers;
using Prism.Commands;
using Prism.Mvvm;
using System;

namespace Ct.SubFinder.Mobile.App.Pages.NewAccount
{
    public class NewAccountViewModel : BindableBase
    {
        private readonly AppController _appController;

        public string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        public DelegateCommand NewGeneralContractorCommand { set; get; }
        public DelegateCommand NewSubContractorCommand { set; get; }
        
        public NewAccountViewModel(AppController appController)
        {
            _appController = appController ?? throw new ArgumentException(nameof(appController));

            Title = "Create an Account";
            NewGeneralContractorCommand = new DelegateCommand(OnNewGeneralContractor);
            NewSubContractorCommand = new DelegateCommand(OnNewSubContractor);            
        }

        private void OnNewGeneralContractor()
        {
            _appController.State.Account.AccountType = Domain.AccountType.GeneralContractor;
            _appController.NavigateToSignUp();
        }

        private void OnNewSubContractor()
        {
            _appController.State.Account.AccountType = Domain.AccountType.SubContractor;
            _appController.NavigateToSignUp();
        }
    }
}
