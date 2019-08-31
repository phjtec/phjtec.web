using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using phjtec.web.core.io;

namespace phjtec.web.Controllers
{
    [Produces("application/json")]
    [Route("api/Services")]
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
        public IEnumerable<ProvidedService> Get()
        {
            if(DateTime.Now - _cacheAge > TimeSpan.FromMinutes(5))
            {
                _providedServices = _jsonContentReaderService.ReadMany<ProvidedService>(_servicesContentPath).OrderBy(s => Guid.NewGuid()).Take(3).ToList();
                _cacheAge = DateTime.Now;
            }
           
            return _providedServices;
        }

        public class ProvidedService
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}