using Origin.ViewModel.Elements;

namespace Origin.Service.Interfaces
{
    public interface ICacheService
    {
        Localization GetLocalizations();

        Configuration GetConfiguration();
    }
}
