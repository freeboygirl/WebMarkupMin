﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
#if DNXCORE50 || DNX451
using Microsoft.AspNet.Mvc.Rendering;
#elif NET40
using System.Web.Mvc;
#else
#error No implementation for this target
#endif

using WebMarkupMin.Core;
using WebMarkupMin.Sample.Resources;

namespace WebMarkupMin.Sample.Logic.Models
{
	/// <summary>
	/// HTML minification settings view model
	/// </summary>
	public sealed class HtmlMinificationSettingsViewModel : CommonHtmlMinificationSettingsViewModel
	{
		private static readonly IEnumerable<SelectListItem> _emptyTagRenderModes;
		private static readonly IEnumerable<SelectListItem> _attributeQuotesRemovalMode;

		[Display(Name = "DisplayName_RemoveCdataSectionsFromScriptsAndStyles", ResourceType = typeof(HtmlMinificationStrings))]
		public bool RemoveCdataSectionsFromScriptsAndStyles
		{
			get;
			set;
		}

		[Display(Name = "DisplayName_EmptyTagRenderMode", ResourceType = typeof(HtmlMinificationStrings))]
		public HtmlEmptyTagRenderMode EmptyTagRenderMode
		{
			get;
			set;
		}

		[Display(Name = "DisplayName_RemoveOptionalEndTags", ResourceType = typeof(HtmlMinificationStrings))]
		public bool RemoveOptionalEndTags
		{
			get;
			set;
		}

		[Display(Name = "DisplayName_CollapseBooleanAttributes", ResourceType = typeof(HtmlMinificationStrings))]
		public bool CollapseBooleanAttributes
		{
			get;
			set;
		}

		[Display(Name = "DisplayName_AttributeQuotesRemovalMode", ResourceType = typeof(HtmlMinificationStrings))]
		public HtmlAttributeQuotesRemovalMode AttributeQuotesRemovalMode
		{
			get;
			set;
		}

		[Display(Name = "DisplayName_RemoveJsTypeAttributes", ResourceType = typeof(HtmlMinificationStrings))]
		public bool RemoveJsTypeAttributes
		{
			get;
			set;
		}

		[Display(Name = "DisplayName_RemoveCssTypeAttributes", ResourceType = typeof(HtmlMinificationStrings))]
		public bool RemoveCssTypeAttributes
		{
			get;
			set;
		}

		public IEnumerable<SelectListItem> EmptyTagRenderModeList
		{
			get
			{
				return _emptyTagRenderModes;
			}
		}

		public IEnumerable<SelectListItem> AttributeQuotesRemovalModeList
		{
			get
			{
				return _attributeQuotesRemovalMode;
			}
		}


		static HtmlMinificationSettingsViewModel()
		{
			_emptyTagRenderModes = new List<SelectListItem>
			{
				new SelectListItem
				{
					Value = HtmlEmptyTagRenderMode.NoSlash.ToString(),
					Text = HtmlMinificationStrings.ListItem_EmptyTagRenderMode_NoSlash
				},
				new SelectListItem
				{
					Value = HtmlEmptyTagRenderMode.Slash.ToString(),
					Text = HtmlMinificationStrings.ListItem_EmptyTagRenderMode_Slash
				},
				new SelectListItem
				{
					Value = HtmlEmptyTagRenderMode.SpaceAndSlash.ToString(),
					Text = HtmlMinificationStrings.ListItem_EmptyTagRenderMode_SpaceAndSlash
				}
			};

			_attributeQuotesRemovalMode = new List<SelectListItem>
			{
				new SelectListItem
					{
						Value = HtmlAttributeQuotesRemovalMode.KeepQuotes.ToString(),
						Text = HtmlMinificationStrings.ListItem_AttributeQuotesRemovalMode_KeepQuotes
					},
				new SelectListItem
					{
						Value = HtmlAttributeQuotesRemovalMode.Html4.ToString(),
						Text = HtmlMinificationStrings.ListItem_AttributeQuotesRemovalMode_Html4
					},
				new SelectListItem
					{
						Value = HtmlAttributeQuotesRemovalMode.Html5.ToString(),
						Text = HtmlMinificationStrings.ListItem_AttributeQuotesRemovalMode_Html5
					}
			};
		}
	}
}