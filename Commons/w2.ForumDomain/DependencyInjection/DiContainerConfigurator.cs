// (c) 2026 W2 Co.,Ltd.

using Unity;
using w2.ForumDomain.RdbRepositories.Forums;
using w2.ForumDomain.RdbRepositories.ForumsRes;
using w2.ForumDomain.RepositoryInterfaces.Forums;
using w2.ForumDomain.RepositoryInterfaces.ForumsRes;
using w2.FoundationDomain.DependencyInjections;

namespace w2.ForumDomain.DependencyInjection
{
	/// <summary>
	/// Di container configurator
	/// </summary>
	public sealed class DiContainerConfigurator : IDiContainerConfigurator
	{
		/// <inheritdoc />
		public UnityContainer Configure(UnityContainer container)
		{
			container.RegisterType<IForumRepository, ForumRepository>();
			container.RegisterType<IForumResRepository, ForumResRepository>();
			return container;
		}
	}
}
