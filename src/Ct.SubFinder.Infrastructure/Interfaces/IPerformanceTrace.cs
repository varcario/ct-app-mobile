﻿
namespace Ct.App.Infrastructure.Interfaces
{
    public interface IPerformanceTrace
    {
        void CreateLog(Marker marker, string a = "", string b ="" , int c = 0);        
    }
}
