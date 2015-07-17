//------------------------------------------------------------------------------
// <auto-generated>
//	 This code was generated by a tool.
//
//	 Changes to this file may cause incorrect behavior and will be lost if
//	 the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------
namespace WebMarkupMin.Sample.Resources
{
	using System;
	using System.Globalization;
	using System.Reflection;
	using System.Resources;

	/// <summary>
	/// A strongly-typed resource class, for looking up localized strings, etc.
	/// </summary>
	public class CommonStrings
	{
		private static Lazy<ResourceManager> _resourceManager =
			new Lazy<ResourceManager>(() => new ResourceManager(
				"WebMarkupMin.Sample.Resources.CommonStrings",
#if DNXCORE50 || DNX451
				typeof(CommonStrings).GetTypeInfo().Assembly
#elif NET40
				typeof(CommonStrings).Assembly
#else
#error No implementation for this target
#endif
			));

		private static CultureInfo _resourceCulture;

		/// <summary>
		/// Returns a cached ResourceManager instance used by this class
		/// </summary>
		public static ResourceManager ResourceManager
		{
			get
			{
				return _resourceManager.Value;
			}
		}

		/// <summary>
		/// Overrides a current thread's CurrentUICulture property for all
		/// resource lookups using this strongly typed resource class
		/// </summary>
		public static CultureInfo Culture
		{
			get
			{
				return _resourceCulture;
			}
			set
			{
				_resourceCulture = value;
			}
		}

		/// <summary>
		/// Looks up a localized string similar to "File '{0}' not exist."
		/// </summary>
		public static string ErrorMessage_FileNotFound
		{
			get { return GetString("ErrorMessage_FileNotFound"); }
		}

		/// <summary>
		/// Looks up a localized string similar to "File path not specified."
		/// </summary>
		public static string ErrorMessage_FilePathNotSpecified
		{
			get { return GetString("ErrorMessage_FilePathNotSpecified"); }
		}

		/// <summary>
		/// Looks up a localized string similar to "During reading of the file '{0}' an unknown error has occurred."
		/// </summary>
		public static string ErrorMessage_FileReadingFailed
		{
			get { return GetString("ErrorMessage_FileReadingFailed"); }
		}

		private static string GetString(string name)
		{
			string value = ResourceManager.GetString(name, _resourceCulture);

			return value;
		}
	}
}