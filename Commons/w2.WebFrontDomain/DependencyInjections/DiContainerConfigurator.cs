// (c) 2026 W2 Co.,Ltd.

using Unity;
using w2.FoundationDomain.DependencyInjections;
using w2.WebFrontDomain.Interface;
using w2.WebFrontDomain.Validator.Forums;

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
			return container;
		}
	}
}
