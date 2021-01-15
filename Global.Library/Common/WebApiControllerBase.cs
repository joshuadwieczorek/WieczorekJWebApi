using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;

namespace Global.Library.Common
{
    public class WebApiControllerBase<T> : ControllerBase
    {
        private readonly ILogger<T> _logger;
        private readonly Bugsnag.IClient _bugSnag;


        public WebApiControllerBase(
              ILogger<T> logger
            , Bugsnag.IClient bugSnag)
        {
            _logger = logger;
            _bugSnag = bugSnag;
        }


        protected void LogError(Exception e)
        {
            _bugSnag?.Notify(e);
            _logger?.LogError("{e}", e);
        }
    }
}