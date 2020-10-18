using Microsoft.Extensions.DependencyInjection;
using DeviceManagementPortal.Domain.Interfaces;
using DeviceManagementPortal.Services;

namespace DeviceManagementPortal.Dependencies
{
    public static class ServicesDependency
    {
        public static void AddServiceDependency(this IServiceCollection services)
        {
            services.AddTransient<IServiceDevice, ServiceDevice>();
            services.AddTransient<IServiceBackend, ServiceBackend>();
            services.AddTransient<IServiceDeviceBackend, ServiceDeviceBackend>();
        }
    }
}

