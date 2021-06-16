using System;
using Microsoft.Extensions.Logging;

namespace DiTest.Services
{
    public interface ISecondTransientService
    {
        Guid WhatIsMyId();
        Guid WhatIsTheScopedId();
    }
    public class SecondTransientService : ISecondTransientService
    {
        private readonly IScopedDisposableService scopedDisposableService;
        private readonly ILogger<SecondTransientService> logger;

        public SecondTransientService(IScopedDisposableService scopedDisposableService, ILogger<SecondTransientService> logger)
        {
            logger.LogInformation("Creating");
            this.scopedDisposableService = scopedDisposableService;
            this.logger = logger;
            foo = Guid.NewGuid();
        }
        private Guid foo;
        
        public Guid WhatIsMyId()
        {
            return foo;
        }

        public Guid WhatIsTheScopedId()
        {
            return scopedDisposableService.WhatIsMyId();
        }
    }
}