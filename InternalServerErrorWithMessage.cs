using System;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Results;

namespace WebAPI
{
    /// <summary>
    /// An implementation of the default internal server error which also includes the exeption message by default.
    /// </summary>
    public class InternalServerErrorWithMessage : ExceptionResult
    {
        /// <summary>
        /// Creates the Internal Server Error Wiht Message Class
        /// </summary>
        /// <param name="ex"></param>
        /// <param name="controller"></param>
        public InternalServerErrorWithMessage(Exception ex, ApiController controller) : base(ex, controller)
        {
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        public override Task<HttpResponseMessage> ExecuteAsync(CancellationToken cancellationToken)
        {

            HttpError error = new HttpError(Exception, false);
            error.Add(HttpErrorKeys.ExceptionMessageKey, Exception.Message);
            if (Request.ShouldIncludeErrorDetail())
            {
                error.Add(HttpErrorKeys.ExceptionTypeKey, Exception.GetType().FullName);
                error.Add(HttpErrorKeys.StackTraceKey, Exception.StackTrace);
                if (Exception.InnerException != null)
                {
                    error.Add(HttpErrorKeys.InnerExceptionKey, new HttpError(Exception.InnerException, true));
                }
            }
            var res = new NegotiatedContentResult<HttpError>(HttpStatusCode.InternalServerError, error, ContentNegotiator, Request, Formatters);
            return res.ExecuteAsync(cancellationToken);
        }
    }
}
