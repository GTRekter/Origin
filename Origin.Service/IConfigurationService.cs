using Origin.Service.Models;

namespace Origin.Service
{
    public interface IConfigurationService
    {

        void Initialize();

        Configuration GetConfiguration();

    }
}
