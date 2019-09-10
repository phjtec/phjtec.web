using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using phjtec.web.core.io;

namespace phjtec.web.Controllers
{
    [Produces("application/json")]

    public class ServicesController : Controller
    {
        private static IEnumerable<ProvidedService> _providedServices;
        private readonly IJsonContentReader _jsonContentReaderService;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly string _servicesContentPath;
        private static DateTime _cacheAge;

        public ServicesController(IJsonContentReader jsonContentReaderService, IHostingEnvironment hostingEnvironment)
        {         
            _jsonContentReaderService = jsonContentReaderService;
            _hostingEnvironment = hostingEnvironment;
            _servicesContentPath = System.IO.Path.Combine(_hostingEnvironment.ContentRootPath, "content/services");
        }

        

        [HttpGet]
        [Route("api/Services")]
        public IEnumerable<ProvidedService> Get()
        {
            if(DateTime.Now - _cacheAge > TimeSpan.FromMinutes(5))
            {
                _providedServices = _jsonContentReaderService.ReadMany<ProvidedService>(_servicesContentPath).OrderBy(s => Guid.NewGuid()).Take(3).ToList();
                _cacheAge = DateTime.Now;
            }
           
            return _providedServices;
        }

        [HttpGet]
        [Route("api/Services/{serviceRoute}")]
        public IEnumerable<ProvidedService> Get(string serviceRoute)
        {
            var providedServices = _jsonContentReaderService.ReadMany<ProvidedService>(_servicesContentPath).Where(s => s.ServiceRoute == serviceRoute).ToList();
            return providedServices;
        }

        public class ProvidedService
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string FullContent { get; set; }
            public string ServiceRoute { get; set; }
        }
    }
}