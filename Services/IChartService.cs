using JungleApi.Web.Models;
using System;
using System.Collections.Generic;

namespace JungleApi.Web.Services
{
    public interface IChartService : IDisposable
    {
        IEnumerable<LineSery> GetLineSeries();
        IEnumerable<SalesData> GetColumnData();
        IEnumerable<Trackball> GetTrackballData();

    }
}
