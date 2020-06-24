using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;

namespace JungleApi.Web.Controllers
{
    //[Authorize(AuthenticationSchemes = "Bearer")]
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };

        private readonly ILogger<WeatherForecastController> _logger;
        private readonly IConfiguration _config;
        private readonly IWebHostEnvironment _host;

        private char[] Randomize(char[] arr)
        {
            Random r = new Random();
            int next = r.Next(arr.Length);
            for (int i = 0; i < arr.Length; i++)
            {
                char c = arr[i];
                arr[i] = arr[next];
                arr[next] = c;
            }
            return arr;
        }

        private IEnumerable<T> Randomize<T>(T[] items)
        {
            Random r = new Random();
            int next = r.Next(items.Length);
            for (int i = 0; i < items.Length; i++)
            {
                T temp = items[i];
                items[i] = items[next];
                items[next] = temp;
            }
            return items;
        }

        public WeatherForecastController(IConfiguration config, IWebHostEnvironment host, ILogger<WeatherForecastController> logger)
        {
            _logger = logger;
            _config = config;
            _host = host;

            char[] arr = new char[] { 'a', 'b', 'c', 'd', 'e', 'f', 'g' };
            string msg = string.Empty;

            foreach (char c in Randomize(arr))
                msg += c;
            msg = string.Empty;

            string[] scale = new string[] { "A", "Bb", "B", "C", "Db", "D", "Eb", "E", "F", "Gb", "G", "Ab" };
            foreach (string s in Randomize(scale))
                msg += s + " ";

        }

        [HttpGet]
        public IEnumerable<WeatherForecast> Get()
        {
            var rng = new Random();
            return Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateTime.Now.AddDays(index),
                TemperatureC = rng.Next(-20, 55),
                Summary = Summaries[rng.Next(Summaries.Length)]
            })
            .ToArray();
        }

        public static T GetFieldValue<T>(DataRow dr, string fieldname)
        {
            if (dr[fieldname] == null || dr[fieldname] == DBNull.Value)
                return default;
            else
                return (T)Convert.ChangeType(dr[fieldname], typeof(T));
        }
        private static DataTable ConvertToDataTable<T>(IList<T> list)
        {
            PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(typeof(T));
            DataTable dt = new DataTable();

            foreach (PropertyDescriptor prop in properties)
            {
                dt.Columns.Add(prop.Name, Nullable.GetUnderlyingType(prop.PropertyType) ?? prop.PropertyType);
            }

            foreach (var item in list)
            {
                DataRow dr = dt.NewRow();
                foreach (PropertyDescriptor prop in properties)
                {
                    dr[prop.Name] = prop.GetValue(item) ?? DBNull.Value;
                }
                dt.Rows.Add(dr);
            }
            return dt;
        }
    }
    public class Name
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
    }
}
