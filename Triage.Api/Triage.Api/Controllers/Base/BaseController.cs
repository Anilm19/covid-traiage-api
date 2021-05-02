using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Triage.Api.Controllers.Base
{
    public class BaseController<TService> : Controller
    {
        public BaseController(TService service, ILogger logger)
        {
            Service = service;
            Logger = logger;
        }
        protected TService Service { get; }
        protected ILogger Logger { get; }
    }
}
