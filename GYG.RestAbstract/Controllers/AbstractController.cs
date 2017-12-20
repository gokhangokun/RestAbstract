namespace GYG.RestAbstract.Controllers
{
    using System;
    using System.Net;
    using System.Reflection;
    using Microsoft.ApplicationInsights.AspNetCore.Extensions;
    using Microsoft.AspNetCore.Mvc;
    using Extensions;
    using Models.Responses;
    public class AbstractController : Controller
    {

        protected IActionResult InvalidRequest(string errorMessage)
        {
            return InvalidRequest(errorMessage, string.Empty);
        }

        protected IActionResult InvalidRequest(string errorMessage, string errorCode)
        {
            ErrorResponse errorResponse = new ErrorResponse { ErrorCode = errorCode };
            errorResponse.AddErrorMessage(errorMessage);

            return BadRequest(errorResponse);
        }

        protected IActionResult Created(object createdObject)
        {
            string id = GetIdFromReturnValue(createdObject);

            if (String.IsNullOrEmpty(id))
            {
                return Created(String.Empty, createdObject);
            }

            string url = Request.GetUri().AbsoluteUri;
            return Created($"{url.TrimEnd('/')}/{id}", createdObject);
        }

        protected IActionResult Deleted(object returnValue = null)
        {
            if (returnValue == null)
            {
                return NoContent();
            }

            return Ok(returnValue);
        }

        protected IActionResult InternalServerError(string errorMessage, string additionalInfo = null)
        {
            ErrorResponse errorResponse = new ErrorResponse
            {
                ErrorCode = "InternalServerError",
                AdditionalInfo = additionalInfo
            };
            errorResponse.AddErrorMessage(errorMessage);

            return StatusCode(HttpStatusCode.InternalServerError.ToInt(), errorResponse);
        }

        protected IActionResult InternalServerError<T>(T errorResponse)
        {
            return StatusCode(HttpStatusCode.InternalServerError.ToInt(), errorResponse);
        }

        private string GetIdFromReturnValue(object createdObject)
        {
            if (createdObject != null)
            {
                PropertyInfo propertyInfo = createdObject.GetType().GetProperty("Id");

                if (propertyInfo != null)
                {
                    object idValue = propertyInfo.GetValue(createdObject, null);

                    if (idValue != null)
                    {
                        return idValue.ToString();
                    }
                }
            }

            return string.Empty;
        }
    }
}
