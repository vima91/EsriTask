using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;
using EsriTask.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json.Linq;

namespace EsriTask.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }


        public async Task<JsonResult> OnGetPopulationData(string searchTerm)
        {
            var attributes = new List<PopulationDataAttribute>();
            using (var client = new HttpClient())
            {
                try
                {
                    //Would best be in appSettings, structured as base url, api version then service/name/location, then query string items
                    var baseUrl = "http://sampleserver1.arcgisonline.com";
                    var api = "ArcGIS/rest/services/Demographics/ESRI_Census_USA/MapServer/find";
                    var options =
                        "layers=5&returnGeometry=false&f=pjson";
                    var apiUrl =
                        $"{baseUrl}/{api}?searchText={searchTerm}&{options}";

                    var response = await client.GetAsync(apiUrl);
                    response.EnsureSuccessStatusCode();
                    var responseBody = await response.Content.ReadAsStringAsync();
                    
                    if (!string.IsNullOrEmpty(responseBody))
                    {
                        dynamic populationData = JObject.Parse(responseBody);
                        foreach (var attribute in populationData.results[0].attributes)
                        {
                            //Only interested in certain attributes
                            if (attribute.Name.ToString().StartsWith("AGE_"))
                            {
                                attributes.Add(new PopulationDataAttribute(attribute.Name, Convert.ToInt32(attribute.Value)));
                            }
                        }
                    }
                }
                catch (HttpRequestException e)
                {
                    //Some logging goes here, then handling
                    _logger.Log(LogLevel.Error, e, "Http Request Exception Occured");
                    throw;
                }
                catch (Exception e)
                {
                    //Some more generic logging goes here, then generic handling
                    _logger.Log(LogLevel.Error, e, "Generic Exception Occured");
                    throw;
                }
            }
            return new JsonResult(attributes);
        }
    }
}