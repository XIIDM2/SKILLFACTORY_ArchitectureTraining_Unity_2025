using Assets.CodeBase.Infrustructure.DependencyInjection.DIContainer;
using CodeBase.DATA;

namespace CodeBase.Infrastructure.Services.ProgressProviders
{
    public interface IProgressProvider : IService
    {
        PlayerProgress PlayerProgress { get; set; }
    }
}