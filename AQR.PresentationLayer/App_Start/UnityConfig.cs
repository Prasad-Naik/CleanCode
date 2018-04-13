using System.Web.Mvc;
using Unity;
using Unity.Mvc5;
using AQR.BusinessLayer;
using AQR.Repository;


namespace AQR.UserManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();

            container.RegisterType<IUserRepository , UserRepository>();
            container.RegisterType<IDepartmentRepository , DepartmentRepository>();

            container.RegisterType<IUserService, UserService>();
            container.RegisterType<IDepartmentService, DepartmentService>();
            

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}