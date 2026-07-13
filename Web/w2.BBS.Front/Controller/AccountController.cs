// (c) 2026 W2 Co.,Ltd.

using System.Web.Mvc;
using w2.BBS.Front.Controller.Shared;
using w2.BBS.Front.ViewModels;
using w2.BBS.Front.ViewModels.Accounts;
using w2.WebFrontDomain.Configurations;
using w2.WebFrontDomain.Dto.Account;
using w2.WebFrontDomain.Services.Account;

namespace w2.BBS.Front.Controller
{
	/// <summary>
	/// Account controller
	/// </summary>
	[RoutePrefix("user")]
	public sealed class AccountController : BaseController
	{
		/// <summary>Account register view service</summary>
		private readonly AccountViewService _service;

		/// <summary>
		/// Constructor
		/// </summary>
		public AccountController(AccountViewService accountService)
		{
			_service = accountService;
		}

		/// <summary>
		/// Register input
		/// </summary>
		/// <returns>Action result</returns>
		[HttpGet]
		[Route("register/input")]
		public ActionResult RegisterInput()
		{
			var viewModel = new AccountRegisterModifyViewModel
			{
				BackUrl = ConstantsPage.LoginPageUrl,
			};
			var response = _service.GetInputInfor();

			if (response.ResponseObject is not null)
			{
				viewModel.LoginId = response.ResponseObject?.LoginId.AsString;
				viewModel.Name = response.ResponseObject?.Name.AsString;
			}

			return View(
				"Account/Register/input.liquid",
				viewModel);
		}

		/// <summary>
		/// Register
		/// </summary>
		/// <returns>Action result</returns>
		[HttpPost]
		[Route("register")]
		public ActionResult Register(AccountRegisterModifyRequest request)
		{
			var response = _service.RegisterValidate(request);
			return JsonForJs(response);
		}

		/// <summary>
		/// Register confirm view
		/// </summary>
		/// <returns>Action result</returns>
		[HttpGet]
		[Route("register/confirm")]
		public ActionResult RegisterConfirmView()
		{
			var viewModel = new AccountRegisterModifyViewModel
			{
				BackUrl = ConstantsPage.AccountRegisterInputPageUrl,
			};
			var response = _service.GetInputInfor();
			if (response.ResponseObject is not null)
			{
				viewModel.LoginId = response.ResponseObject?.LoginId.AsString;
				viewModel.Name = response.ResponseObject?.Name.AsString;
				viewModel.Password = response.ResponseObject?.Password.ToString();
			}
			return View("Account/Register/confirm.liquid", viewModel);
		}

		/// <summary>
		/// Confirm view
		/// </summary>
		/// <returns>Action result</returns>
		[HttpPost]
		[Route("register/confirm/save")]
		public ActionResult SaveUser()
		{
			var response = _service.ExecRegister();
			return JsonForJs(response);
		}

		/// <summary>
		/// Confirm view
		/// </summary>
		/// <returns>Action result</returns>
		[HttpGet]
		[Route("register/complete")]
		public ActionResult Completed()
		{
			var viewModel = new BaseViewModel
			{
				NextUrl = ConstantsPage.TopForumPageUrl,
			};

			return View(
				"Account/Register/complete.liquid",
				viewModel);
		}

		/// <summary>
		/// Cancel confirm
		/// </summary>
		/// <returns>Action result</returns>
		[HttpGet]
		[Route("withdrawal/confirm")]
		public ActionResult CancelConfirm()
		{
			return View("Account/Withdrawal/confirm.liquid");
		}

		/// <summary>
		/// Cancel confirm
		/// </summary>
		/// <returns>Action result</returns>
		[HttpPost]
		[Route("withdrawal")]
		public ActionResult ExcecCancel()
		{
			var response = _service.ExcecWithdrawal();
			return JsonForJs(response);
		}

		/// <summary>
		/// Cancel complete
		/// </summary>
		/// <returns>Action result</returns>
		[HttpGet]
		[Route("withdrawal/complete")]
		public ActionResult CancelComplete()
		{
			return View("Account/Withdrawal/complete.liquid");
		}

		/// <summary>
		/// Modify input
		/// </summary>
		/// <returns>Action result</returns>
		[HttpGet]
		[Route("modify/input")]
		public ActionResult ModifyInput()
		{
			var response = _service.GetLoginAccountOrInputInfor();
			var viewModel = new AccountRegisterModifyViewModel
			{
				LoginId = response.ResponseObject?.LoginId.AsString,
				Name = response.ResponseObject?.Name.AsString,
			};

			return View(
				"Account/Modify/input.liquid",
				viewModel);
		}

		/// <summary>
		/// Modify account
		/// </summary>
		/// <returns>Action result</returns>
		[HttpPost]
		[Route("modify")]
		public ActionResult ModifyAccount(AccountRegisterModifyRequest request)
		{
			var response = _service.ModifyValidate(request);
			return JsonForJs(response);
		}


		/// <summary>
		/// Modify confirm view
		/// </summary>
		/// <returns>Action result</returns>
		[HttpGet]
		[Route("modify/confirm")]
		public ActionResult ModifyConfirmView()
		{
			var viewModel = new AccountRegisterModifyViewModel
			{
				BackUrl = ConstantsPage.AccountModifyInputPageUrl,
			};
			var response = _service.GetInputInfor();
			if (response.ResponseObject is not null)
			{
				viewModel.LoginId = response.ResponseObject?.LoginId.AsString;
				viewModel.Name = response.ResponseObject?.Name.AsString;
				viewModel.Password = response.ResponseObject?.Password.ToString();
			}

			return View(
				"Account/Modify/confirm.liquid",
				viewModel);
		}

		/// <summary>
		/// Confirm modiftview
		/// </summary>
		/// <returns>Action result</returns>
		[HttpPost]
		[Route("modify/confirm/save")]
		public ActionResult SaveModifyUser()
		{
			var response = _service.ExecModify();
			return JsonForJs(response);
		}
	}
}
