using System;
using Microsoft.Extensions.Logging;

namespace DiTest.Services
{
    public interface ISingletonService 
    {
        Guid WhatIsMyId();
    }
    public class SingletonService : ISingletonService 
    {
        private readonly ILogger<SingletonService> logger;
        private Guid foo;
        public SingletonService(ILogger<SingletonService> logger)
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