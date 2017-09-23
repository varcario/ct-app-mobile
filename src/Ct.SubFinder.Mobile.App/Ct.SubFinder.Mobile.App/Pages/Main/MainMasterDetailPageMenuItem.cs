﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ct.SubFinder.Mobile.App.Pages.Main
{

    public class MainMasterDetailPageMenuItem
    {
        public MainMasterDetailPageMenuItem()
        {
            TargetType = typeof(MainMasterDetailPageDetail);
        }
        public int MenuId { get; set; }
        public string Title { get; set; }

        public Type TargetType { get; set; }

        public string Route { get; set; }
    }
}