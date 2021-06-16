using System;
using System.Diagnostics;
using Microsoft.Extensions.Logging;

namespace DiTest.Services
{
    public interface IScopedDisposableService 
    {
        Guid WhatIsMyId();
    }
    public class ScopedDisposableService : IScopedDisposableService, IDisposable
    {
        private readonly ILogger<ScopedDisposableService> logger;
        private Guid foo;
        public ScopedDisposableService(ILogger<ScopedDisposableService> logger)
        {
            logger.LogInformation("Creating");
            foo = Guid.NewGuid();
            this.logger = logger;
        }

        public void Dispose()
        {
            logger.LogInformation("Disposing");
        }

        public Guid WhatIsMyId()
        {
            return foo;
        }
    }
}