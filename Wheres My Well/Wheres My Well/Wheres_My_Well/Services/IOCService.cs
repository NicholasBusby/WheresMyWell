using Microsoft.Practices.Unity;
using System.Collections.Generic;
using Wheres_My_Well.ViewModels;
using Wheres_My_Well.Views;

namespace Wheres_My_Well.Services
{
    public class IOCService
    {
        private UnityContainer container;

        public IOCService()
        {
            container = new UnityContainer();
            container.RegisterType<IWellService, NorthDakotaWellService>("NorthDakota");
            container.RegisterType<IEnumerable<IWellService>, IWellService[]>();

            container.RegisterType<MainPageViewModel>();

            container.RegisterType<MainPage>();
        }

        public T Resolve<T>()
        {
            return container.Resolve<T>();
        }
    }
}
