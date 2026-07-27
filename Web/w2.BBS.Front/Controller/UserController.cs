// (c) 2026 W2 Co.,Ltd.

using System.Web.Mvc;
using w2.BBS.Front.Controller.Shared;
using w2.WebFrontDomain.Configurations;
using w2.WebFrontDomain.Dto.Users;
using w2.WebFrontDomain.Services.Users;
using w2.WebFrontDomain.ViewModels;

namespace w2.BBS.Front.Controller
{
	/// <summary>
	/// User controller
	/// </summary>
	[RoutePrefix("user")]
	public sealed class UserController : BaseController
	{
		private readonly UserViewService _userService;

		/// <summary>
		/// Constructor
		/// </summary>
		public UserController(UserViewService userService,
			LoginLogoutService loginLogoutService) : base(loginLogoutService)
		{
			_userService = userService;
		}

		/// <summary>
		/// Register input
		/// </summary>
		[HttpGet]
		[Route("register/input")]
		public ActionResult RegisterInput()
		{
			var response = _userService.GetInputInformation();

			return View(
				"Account/Register/input.liquid",
				response.ToViewModel(
					ConstantsPage.LoginPageUrl,
					includePassword: true));
		}

		/// <summary>
		/// Register
		/// </summary>
		[HttpPost]
		[Route("register")]
		public ActionResult Register(UserRegisterModifyRequest request)
		{
			var response = _userService.RegisterValidate(request);
			return JsonForJs(response);
		}

		/// <summary>
		/// Register confirm view
		/// </summary>
		[HttpGet]
		[Route("register/confirm")]
		public ActionResult RegisterConfirmView()
		{
			var request = _userService.GetInputInformation();

			return View(
				"Account/Register/confirm.liquid",
				request.ToViewModel(
					ConstantsPage.UserRegisterInputPageUrl,
					includePassword: true));
		}

		/// <summary>
		/// Save user
		/// </summary>
		[HttpPost]
		[Route("register/confirm/save")]
		public ActionResult SaveUser()
		{
			var response = _userService.ExecRegister();
			return JsonForJs(response);
		}

		/// <summary>
		/// Register complete
		/// </summary>
		[HttpGet]
		[Route("register/complete")]
		public ActionResult Completed()
		{
			var viewModel = new EmptyViewModel
			{
				NextUrl = ConstantsPage.TopForumPageUrl,
			};

			return View(
				"Account/Register/complete.liquid",
				viewModel);
		}

		/// <summary>
		/// Withdrawal confirm
		/// </summary>
		[HttpGet]
		[Route("withdrawal/confirm")]
		public ActionResult WithdrawalConfirm()
		{
			return View("Account/Withdrawal/confirm.liquid");
		}

		/// <summary>
		/// Cancel confirm
		/// </summary>
		[HttpPost]
		[Route("withdrawal")]
		public ActionResult ExecCancel()
		{
			var response = _userService.ExecWithdrawal();
			return JsonForJs(response);
		}

		/// <summary>
		/// Withdrawal complete
		/// </summary>
		[HttpGet]
		[Route("withdrawal/complete")]
		public ActionResult WithdrawalComplete()
		{ 
			return View("Account/Withdrawal/complete.liquid");
		}

		/// <summary>
		/// Modify input
		/// </summary>
		[HttpGet]
		[Route("modify/input")]
		public ActionResult ModifyInput()
		{
			var response = _userService.GetLoginAccountOrInputInformation();

			return View(
				"Account/Modify/input.liquid",
				response.ToViewModel(ConstantsPage.TopForumPageUrl));
		}

		/// <summary>
		/// Modify account
		/// </summary>
		[HttpPost]
		[Route("modify")]
		public ActionResult ModifyAccount(UserRegisterModifyRequest request)
		{
			var response = _userService.ModifyValidate(request);
			return JsonForJs(response);
		}

		/// <summary>
		/// Modify confirm view
		/// </summary>
		[HttpGet]
		[Route("modify/confirm")]
		public ActionResult ModifyConfirmView()
		{
			var response = _userService.GetInputInformation();

			return View(
				"Account/Modify/confirm.liquid",
				response.ToViewModel(
					ConstantsPage.UserModifyInputPageUrl,
					includePassword: true));
		}

		/// <summary>
		/// Save modify user
		/// </summary>
		[HttpPost]
		[Route("modify/confirm/save")]
		public ActionResult SaveModifyUser()
		{
			var response = _userService.ExecModify();
			return JsonForJs(response);
		}
	}
}
