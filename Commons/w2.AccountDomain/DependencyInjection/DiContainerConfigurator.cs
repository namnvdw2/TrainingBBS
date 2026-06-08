// (c) 2025 W2 Co.,Ltd.

using Unity;
using w2.AccountDomain.RdbRepositories.Account;
using w2.AccountDomain.RepositoryInterfaces.Account;
using w2.FoundationDomain.DependencyInjections;

namespace w2.AccountDomain.DependencyInjection
{
	/// <summary>
	/// Di container configurator
	/// </summary>
	public class DiContainerConfigurator : IDiContainerConfigurator
	{
		/// <inheritdoc />
		public UnityContainer Configure(UnityContainer container)
		{
			container.RegisterType<IAccountRepository, AccountRepository>();
			return container;
		}
	}
}
