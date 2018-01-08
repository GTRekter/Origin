using Origin.Service.Models;

namespace Origin.Service
{
    public interface ILocalizationService
    {

        void Initialize();

        Localization GetLocalizations();

    }
}
