using System;
using Microsoft.Extensions.Logging;

namespace Global.Library.Common
{
    public abstract class BaseLogger
    {
        private readonly ILogger _logger;
        private readonly Bugsnag.IClient _bugSnag;


        public BaseLogger(
              ILogger logger
            , Bugsnag.IClient bugSnag
            , bool parametersAreRequired = true)
        {
            if (parametersAreRequired)
            {
                if (logger is null)
                    throw new ArgumentNullException(nameof(logger));

                if (bugSnag is null)
                    throw new ArgumentNullException(nameof(bugSnag));
            }

            _logger = logger;
            _bugSnag = bugSnag;
        }


        protected void LogError(Exception e)
        {
            _bugSnag?.Notify(e);
            _logger?.LogError("{e}", e);
        }
    }

    
    public abstract class BaseLogger<T> : BaseLogger
    {
        public BaseLogger(
              ILogger<T> logger
            , Bugsnag.IClient bugSnag) : base(logger, bugSnag) { }
    }
}