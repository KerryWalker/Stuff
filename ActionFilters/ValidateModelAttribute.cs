using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebAPI.ActionFilters
{
	public class ValidateModelAttribute : ActionFilterAttribute
	{
		public override void OnActionExecuting(HttpActionContext actionContext)
		{
			if (!actionContext.ModelState.IsValid)
			{
				actionContext.Response =  actionContext.Request.CreateErrorResponse(System.Net.HttpStatusCode.BadRequest, actionContext.ModelState);
			}	
		}
	}
}
