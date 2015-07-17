﻿using System;
using System.IO;
using System.Web;
using System.Web.Mvc;

using WebMarkupMin.AspNet.Common;
using WebMarkupMin.AspNet.Common.Compressors;
using WebMarkupMin.AspNet4.Common;

namespace WebMarkupMin.AspNet4.Mvc
{
	/// <summary>
	/// Attribute that can be added to controller methods to force content
	/// to be GZip encoded if the client supports it
	/// </summary>
	[AttributeUsage(AttributeTargets.Method)]
	public class CompressContentAttribute : ActionFilterAttribute
	{
		/// <summary>
		/// WebMarkupMin configuration
		/// </summary>
		private readonly WebMarkupMinConfiguration _configuration;

		/// <summary>
		/// HTTP compression manager
		/// </summary>
		private readonly IHttpCompressionManager _compressionManager;


		/// <summary>
		/// Constructs a instance of HTTP compressesion attribute
		/// </summary>
		public CompressContentAttribute()
		{
			_configuration = WebMarkupMinConfiguration.Instance;
			_compressionManager = HttpCompressionManager.Current;
		}


		/// <summary>
		/// Override to compress the content that is generated by an action method
		/// </summary>
		/// <param name="filterContext">Filter context</param>
		public override void OnActionExecuting(ActionExecutingContext filterContext)
		{
			if (!_configuration.IsCompressionEnabled())
			{
				return;
			}

			HttpContextBase context = filterContext.HttpContext;
			HttpRequestBase request = context.Request;
			HttpResponseBase response = context.Response;
			string mediaType = response.ContentType;

			if (_compressionManager.IsSupportedMediaType(mediaType))
			{
				context.Items["originalResponseFilter"] = context.Response.Filter;

				string acceptEncoding = request.Headers["Accept-Encoding"];

				ICompressor compressor = _compressionManager.CreateCompressor(acceptEncoding);
				response.Filter = compressor.Compress(response.Filter);
				compressor.AppendHttpHeaders((key, value) =>
				{
					response.Headers[key] = value;
				});
			}
		}

		/// <summary>
		/// Override to handle error
		/// </summary>
		/// <param name="filterContext">Filter context</param>
		public override void OnResultExecuted(ResultExecutedContext filterContext)
		{
			if (filterContext.Exception != null)
			{
				HttpContextBase context = filterContext.HttpContext;
				if (context.Items.Contains("originalResponseFilter"))
				{
					var originalResponseFilter = context.Items["originalResponseFilter"] as Stream;
					if (originalResponseFilter != null)
					{
						context.Response.Filter = originalResponseFilter;
					}
				}
			}
		}
	}
}