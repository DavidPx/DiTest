using System;
using Microsoft.Extensions.Logging;

namespace DiTest.Services
{
    public interface IScopedService 
    {
        Guid WhatIsMyId();
    }
    public class ScopedService : IScopedService
    {
        private readonly ILogger<ScopedService> logger;
        private Guid foo;
        public ScopedService(ILogger<ScopedService> logger)
        {
            logger.LogInformation("Creating");
            foo = Guid.NewGuid();
            this.logger = logger;
        }
        public Guid WhatIsMyId()
        {
            return foo;
        }
    }
}