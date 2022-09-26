using System;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Project3.DeviceManagement.Data.Exceptions;

namespace Project3.DeviceManagement.WebAPP.Controllers
{
	/// <summary>
	/// BaseController
	/// </summary>
	/// <seealso cref="Microsoft.AspNetCore.Mvc.Controller" />
	public abstract class BaseController : Controller
	{
		/// <summary>
		/// Processes the success.
		/// </summary>
		/// <param name="message">The message.</param>
		/// <param name="isPrimary">if set to <c>true</c> [is primary].</param>
		protected void ProcessSuccess(string message, bool isPrimary = false)
		{
			TempData["MessageClass"] = isPrimary ? "text-primary" : "text-success";
			TempData["MessageData"] = message;
		}

		/// <summary>
		/// Processes the exception.
		/// </summary>
		/// <param name="ex">The ex.</param>
		protected void ProcessException(MyWebApiException ex)
		{
			if (ex == null)
				return;


			ProcessException(ex.StatusCode,
				ex.InnerException?.Message != null ? ex.InnerException.Message : ex.Message);
		}


		/// <summary>
		/// Processes the exception.
		/// </summary>
		/// <param name="ex">The ex.</param>
		protected void ProcessException(Exception ex)
		{
			if (ex == null)
				return;

			ProcessException(StatusCodes.Status500InternalServerError,
				ex.InnerException?.Message != null ? ex.InnerException.Message : ex.Message);
		}

		/// <summary>
		/// Processes the exception.
		/// </summary>
		/// <param name="statusCode">The status code.</param>
		/// <param name="statusMessage">The status message.</param>
		private void ProcessException(int statusCode, string statusMessage)
		{
			TempData["MessageClass"] = "text-danger";
			TempData["MessageData"] = statusMessage;
		}
	}
}

