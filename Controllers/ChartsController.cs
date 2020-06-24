using JungleApi.Web.Models;
using JungleApi.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace JungleApi.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChartsController : ControllerBase
    {
        private IChartService _chartService;

        public ChartsController(IChartService chartService)
        {
            _chartService = chartService;
        }

        [Route("lineseries")]
        [HttpGet]
        public IEnumerable<LineSery> GetLineSeries()
        {
            var series = _chartService.GetLineSeries();

            return series;
        }

        [Route("column")]
        [HttpGet]
        public IEnumerable<SalesData> GetColumnData()
        {
            return _chartService.GetColumnData();
        }

        [Route("trackball")]
        [HttpGet]
        public IEnumerable<Trackball> GetTrackballData()
        {
            return _chartService.GetTrackballData();
        }
    }
}