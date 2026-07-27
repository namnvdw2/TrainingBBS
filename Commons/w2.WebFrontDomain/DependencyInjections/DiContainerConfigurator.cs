// (c) 2026 W2 Co.,Ltd.

using SessionDomain.Interface;
using SessionDomain.Repositories;
using Unity;
using w2.FoundationDomain.DependencyInjections;
using w2.WebFrontDomain.Interface;
using w2.WebFrontDomain.Validator;
using w2.WebFrontDomain.Validator.Forums;
using w2.WebFrontDomain.Validator.Users;

namespace w2.WebFrontDomain.DependencyInjections
{
	/// <summary>
	/// DIコンテナコンフィギュレータ
	/// </summary>
	public sealed class DiContainerConfigurator : IDiContainerConfigurator
	{
		/// <inheritdoc />
		public UnityContainer Configure(UnityContainer container)
		{
			container.RegisterType<IForumValidator, ForumValidator>();
			container.RegisterType<ILoginValidator, LoginValidator>();
			container.RegisterType<IUserRegisterValidator, UserRegisterValidator>();
			container.RegisterType<IUserRegisterSessionRepository, UserInputSessionRepository>();
			container.RegisterType<ILoginUserSessionRepository, LoginUserSessionRepository>();

			return container;
		}
	}
}
