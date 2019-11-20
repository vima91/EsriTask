using System;
using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace EsriTask.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        //public async Task<JsonResult> OnGet()
        //{
        //    string responseBody;
        //    using (var client = new HttpClient())
        //    {
        //        try
        //        {
        //            //Would best be in appSettings, structured as base url, api version then service/name
        //            var apiUrl =
        //                "http://sampleserver1.arcgisonline.com/ArcGIS/rest/services/Demographics/ESRI_Census_USA/MapServer/5?f=json&pretty=true";

        //            var response = await client.GetAsync(apiUrl);
        //            response.EnsureSuccessStatusCode();
        //            responseBody = await response.Content.ReadAsStringAsync();
        //            //Convert to strong type here
        //        }
        //        catch (HttpRequestException e)
        //        {
        //            //Some logging goes here, then handling
        //            _logger.Log(LogLevel.Error, e, "Http Request Exception Occured");
        //            throw;
        //        }
        //        catch (Exception e)
        //        {
        //            //Some more generic logging goes here, then generic handling
        //            _logger.Log(LogLevel.Error, e, "Generic Exception Occured");
        //            throw;
        //        }
        //    }
        //    return new JsonResult(responseBody);
        //}
    }
}