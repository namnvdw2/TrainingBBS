// (c) 2025 W2 Co.,Ltd.

using Unity;
using SessionDomain.Interface;
using SessionDomain.Repositories;
using w2.FoundationDomain.DependencyInjections;

namespace SessionDomain.DependencyInjections
{
	/// <summary>
	/// DIコンテナコンフィギュレータ
	/// </summary>
	public sealed class DiContainerConfigurator : IDiContainerConfigurator
	{
		/// <inheritdoc />
		public UnityContainer Configure(UnityContainer container)
		{
			container.RegisterType<ISessionRepository, SessionRepository>();
			container.RegisterType<ISessionErrorRepository, SessionErrorRepository>();
			return container;
		}
	}
}
