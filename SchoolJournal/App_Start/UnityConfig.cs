using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using SchoolJournal.BLL.Module;
using SchoolJournal.DAL.Module;

namespace SchoolJournal
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            DALModule.RegisterComponents(container);

            BLLModule.RegisterComponents(container);

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}