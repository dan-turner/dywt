using Raven.Client;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dywt.Web.Filters
{
    public class AtomicFilter : FilterAttribute, IExceptionFilter, IActionFilter
    {
        private bool _exception;

        public AtomicFilter()
        {
            _exception = false;
        }

        public void OnException(ExceptionContext filterContext)
        {
            _exception = true;
        }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            if (!_exception)
            {
                var session = DependencyResolver.Current.GetService<IDocumentSession>();
                session.SaveChanges();
            }
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            _exception = false;
        }
    }
}