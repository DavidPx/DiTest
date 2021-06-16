using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using DiTest.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DiTest
{
    [Route("api/[controller]")]
    [ApiController]
    public class DiTestController : ControllerBase
    {
        private readonly ILogger<DiTestController> _logger;
        private readonly ITransientService transientService;
        private readonly ISingletonService singletonService;
        
        private readonly ISecondTransientService secondTransientService;
        public DiTestController(
            ILogger<DiTestController> logger, 
            ITransientService transientService, 
            ISingletonService singletonService, 
            ISecondTransientService secondTransientService)
        {
            this.transientService = transientService;
            this.secondTransientService = secondTransientService;
            this.singletonService = singletonService;
            _logger = logger;
        }

    [HttpGet]
    public IActionResult Get()
    {

        return Ok(new
        {
            TransientId = transientService.WhatIsMyId(),
            SecondTransientId = secondTransientService.WhatIsMyId(),
            TransientDependencyId = transientService.WhatIsTheScopedId(),
            Transient2DependencyId = secondTransientService.WhatIsTheScopedId(),
            SingletonService = singletonService.WhatIsMyId()
        });
    }
}

}