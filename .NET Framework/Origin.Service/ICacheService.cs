using Origin.Service.Models;

namespace Origin.Service
{
    public interface ICacheService
    {
        Localization GetLocalizations();

        Configuration GetConfiguration();

        void Initialize();
    }
}
