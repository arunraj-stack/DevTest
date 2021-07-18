using DeveloperTest.Business.Interfaces;
using DeveloperTest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace DeveloperTest.Controllers
{
    // Trying to demonstrate an orchestration which is for managing lookup/reference data
    // This will act as a single source of truth for all enum's and also extendable for new types(eg: business type, Payment type..etc).
    // There should be a contract between Angular app and API service. (eg: inorder to get the Customer type, the Angular app should pass the key 'CUSTYPE')
    [ApiController, Route("[controller]")]
    public class ReferenceDataController : ControllerBase
    {
       
        private static readonly Dictionary<string, string[]> CustomerTypes = new Dictionary<string, string[]>()
        {
            {
                "CUSTYPE", new string[] { "Large", "Small" } 
            }
        };

        public ReferenceDataController()
        {
        }

        [HttpGet("{typeCode}")]
        [ResponseCache(Duration = 60, Location = ResponseCacheLocation.Any, NoStore = false)]
        public IEnumerable<string> Get(string typeCode)
        {
            return CustomerTypes[typeCode];
        }
    }
}
