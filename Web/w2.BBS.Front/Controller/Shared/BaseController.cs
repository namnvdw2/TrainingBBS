// (c) 2026 W2 Co.,Ltd.

using Newtonsoft.Json;
using System;
using System.Text;
using System.Web.Mvc;
using w2.BBS.Front.Codes.Helper;
using w2.FoundationDomain.Domains.DateStrings;
using w2.FoundationDomain.Domains.Numeric;
using w2.TemplateEngine.TemplateEngines;
using w2.TemplateEngine.TemplateEngines.Fluid;
using w2.TemplateEngine.TemplateEngines.PhysicalPathRoutes;
using w2.WebFrontDomain.Services.Users;
using w2.WebFrontDomain.ViewModels;

namespace w2.BBS.Front.Controller.Shared
{
	/// <summary>
	/// Base controller
	/// </summary>
	public abstract class BaseController : System.Web.Mvc.Controller
	{
		protected readonly LoginLogoutService _service;

		protected BaseController(LoginLogoutService service)
		{
			_service = service;
		}

		protected new ActionResult View(string viewFileVirtualPath, object model = null)
		{
			Response.ContentEncoding = Encoding.UTF8;

			ITemplateRenderer templateRenderer = new FluidRenderer(new ThemeTemplatePhysicalPathRoute());

			var optionData = FluidOptionData.Create(
				NumericFormat.GetJpDefault(),
				NumericFormat.GetAll(),
				DateStringFormat.GetJpDefault(),
				DateStringFormat.GetAll(),
				DateTime.Now,
				TempData.Get<string>(TempDataKey.AntiCsrfFormToken));

			model = model ?? new EmptyViewModel();
			if (model is BaseViewModel vm) _service.SetLoginUserToViewModel(vm);

			return new ContentResult
			{
				Content = templateRenderer.RenderByFile(viewFileVirtualPath, model, optionData),
				ContentEncoding = Encoding.UTF8,
				ContentType = "text/html",
			};
		}

		protected ActionResult JsonForJs(object obj)
		{
			var json = JsonConvert.SerializeObject(obj);
			return Content(json, "application/json", Encoding.UTF8);
		}
	}
}
