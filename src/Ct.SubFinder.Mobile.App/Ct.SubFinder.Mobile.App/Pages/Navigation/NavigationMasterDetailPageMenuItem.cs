using System;

namespace Ct.SubFinder.Mobile.App.Pages.Navigation
{
    public class NavigationMasterDetailPageMenuItem
    {
        public int MenuId { get; set; }
        public string Title { get; set; }
        public Action RouteAction { get; set; }
    }
}