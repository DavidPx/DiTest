using System;
using Microsoft.Extensions.Logging;

namespace DiTest.Services
{
    public interface ITransientService
    {
        Guid WhatIsMyId();
        Guid WhatIsTheScopedId();
    }
    public class TransientService : ITransientService
    {
        private readonly IScopedDisposableService scopedDisposableService;
        private readonly ILogger<TransientService> logger;

        public TransientService(IScopedDisposableService scopedDisposableService, ILogger<TransientService> logger)
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