using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace phjtec.web.Controllers
{
    [Produces("application/json")]
    [Route("api/Services")]
    public class ServicesController : Controller
    {
        private readonly IEnumerable<ProvidedService> _providedServices;
        public ServicesController()
        {
            _providedServices = new List<ProvidedService>
                {
                    new ProvidedService
                    {
                        Name = "Software Development",
                        Description = "We provide software development solutions for a range of uses, from small desktop application development to enterprise level multi-tier microservice architecture solutions."
                    },
                     new ProvidedService
                    {
                        Name = "Performance Testing",
                        Description = "Ensuring your solutions perform under pressure is an important and often overlooked aspect, we can help identify performance bottlenecks and guide you on ways to mitigate performance issues."
                    }
                };
        }
        [HttpGet]
        public IEnumerable<ProvidedService> Get()
        {
            return _providedServices;
        }

        public class ProvidedService
        {
            public string Name { get; set; }
            public string Description { get; set; }
        }
    }
}