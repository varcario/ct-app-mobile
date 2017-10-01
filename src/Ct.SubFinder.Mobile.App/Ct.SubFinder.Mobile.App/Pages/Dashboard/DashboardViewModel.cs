using Ct.SubFinder.Domain;
using Ct.SubFinder.Mobile.App.Views.Camera;
using Ct.SubFinder.Mobile.App.Views.Contacts;
using Ct.SubFinder.Mobile.App.Views.Dashboard;
using Ct.SubFinder.Mobile.App.Views.Messages;
using Prism.Commands;
using Prism.Mvvm;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace Ct.SubFinder.Mobile.App.Pages.Dashboard
{
    public class DashboardViewModel : BindableBase
    {
        #region Bindable Properties

        public DelegateCommand<string> ArticleTappedCommand { get; set; }
        public ObservableCollection<Article> Articles { get; set; }

        #endregion

        public DashboardViewModel()
        {
            ArticleTappedCommand = new DelegateCommand<string>(OnArticleTapped);
            Articles = new ObservableCollection<Article>
            {
                { new Article { Identifier = "1", Description = "DALLAS/FT WORTH - On Aug. 8, professional engineers around the world celebrated the second annual “Professional Engineers Day,” and JQ" }},
                { new Article { Identifier = "2", Description = "DALLAS/FT WORTH - Construction is the lifeblood that runs through Steven Mansfield’s family. The owner of subcontracting company S&C Mansfield" }},
                { new Article { Identifier = "3", Description = "HOUSTON - Established 85 years ago in Ballinger, TX, Mueller Incorporated has come a long ways since its humble beginnings" }},
                { new Article { Identifier = "4", Description = "HOUSTON - With close to 40 years of experience in the electrical industry, brothers Louis and Don Lee, wanted to" }},
                { new Article { Identifier = "5", Description = "SAN ANTONIO - You see a lot of things in 30 years, and after working in an industry for that" }},
                { new Article { Identifier = "6", Description = "SAN ANTONIO - The VFW Post 76 is “The Oldest Post in Texas,” in existence 100 years as of June" }},
                { new Article { Identifier = "7", Description = "SAN ANTONIO - SAN ANTONIO - Faith and prayer are what get Azteca Designs president Cecilia Castellano through. When asked how she became" }},
                { new Article { Identifier = "8", Description = "AUSTIN - Gilbert Jimenez began his plumbing career 30 years ago while in high school in Philadelphia. Although he" }},
                { new Article { Identifier = "9", Description = "AUSTIN - While attending the University of Texas studying business, Scott Miller, owner of Tex Painting found an opportunity to" }},
                { new Article { Identifier = "10", Description = "AUSTIN - Carlos Morales started out in construction as a helper framing houses in 1995 when he was 19 years" }},
                { new Article { Identifier = "1", Description = "DALLAS/FT WORTH - On Aug. 8, professional engineers around the world celebrated the second annual “Professional Engineers Day,” and JQ" }},
                { new Article { Identifier = "2", Description = "DALLAS/FT WORTH - Construction is the lifeblood that runs through Steven Mansfield’s family. The owner of subcontracting company S&C Mansfield" }},
                { new Article { Identifier = "3", Description = "HOUSTON - Established 85 years ago in Ballinger, TX, Mueller Incorporated has come a long ways since its humble beginnings" }},
                { new Article { Identifier = "4", Description = "HOUSTON - With close to 40 years of experience in the electrical industry, brothers Louis and Don Lee, wanted to" }},
                { new Article { Identifier = "5", Description = "SAN ANTONIO - You see a lot of things in 30 years, and after working in an industry for that" }},
                { new Article { Identifier = "6", Description = "SAN ANTONIO - The VFW Post 76 is “The Oldest Post in Texas,” in existence 100 years as of June" }},
                { new Article { Identifier = "7", Description = "SAN ANTONIO - SAN ANTONIO - Faith and prayer are what get Azteca Designs president Cecilia Castellano through. When asked how she became" }},
                { new Article { Identifier = "8", Description = "AUSTIN - Gilbert Jimenez began his plumbing career 30 years ago while in high school in Philadelphia. Although he" }},
                { new Article { Identifier = "9", Description = "AUSTIN - While attending the University of Texas studying business, Scott Miller, owner of Tex Painting found an opportunity to" }},
                { new Article { Identifier = "1", Description = "DALLAS/FT WORTH - On Aug. 8, professional engineers around the world celebrated the second annual “Professional Engineers Day,” and JQ" }},
                { new Article { Identifier = "2", Description = "DALLAS/FT WORTH - Construction is the lifeblood that runs through Steven Mansfield’s family. The owner of subcontracting company S&C Mansfield" }},
                { new Article { Identifier = "3", Description = "HOUSTON - Established 85 years ago in Ballinger, TX, Mueller Incorporated has come a long ways since its humble beginnings" }},
                { new Article { Identifier = "4", Description = "HOUSTON - With close to 40 years of experience in the electrical industry, brothers Louis and Don Lee, wanted to" }},
                { new Article { Identifier = "5", Description = "SAN ANTONIO - You see a lot of things in 30 years, and after working in an industry for that" }},
                { new Article { Identifier = "6", Description = "SAN ANTONIO - The VFW Post 76 is “The Oldest Post in Texas,” in existence 100 years as of June" }},
                { new Article { Identifier = "7", Description = "SAN ANTONIO - SAN ANTONIO - Faith and prayer are what get Azteca Designs president Cecilia Castellano through. When asked how she became" }},
                { new Article { Identifier = "8", Description = "AUSTIN - Gilbert Jimenez began his plumbing career 30 years ago while in high school in Philadelphia. Although he" }},
                { new Article { Identifier = "9", Description = "AUSTIN - While attending the University of Texas studying business, Scott Miller, owner of Tex Painting found an opportunity to" }},
            };            
        }

        private void OnArticleTapped(string identifier)
        {

        }
    }
}
