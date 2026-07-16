// (c) 2026 W2 Co.,Ltd.

using Unity;
using w2.AccountDomain.RdbRepositories.Users;
using w2.AccountDomain.RepositoryInterfaces.Users;
using w2.FoundationDomain.DependencyInjections;

namespace w2.AccountDomain.DependencyInjection
{
	/// <summary>
	/// Di container configurator
	/// </summary>
	public sealed class DiContainerConfigurator : IDiContainerConfigurator
	{
		/// <inheritdoc />
		public UnityContainer Configure(UnityContainer container)
		{
			container.RegisterType<IUserRepository, UserRepository>();
			return container;
		}
	}
}
