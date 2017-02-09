using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace SuperZapatos.InventoryControl.WebUI.Helpers
{
    public static class DIGlobalRegister
    {

        public enum EnumRegistrationType { justWithDecoratedClasses, withAllClasses };

        static private List<Type> _interfaceNamesToBeCustomRegistered = new List<Type>();

        private static void customRegistration(ContainerBuilder builder)
        {
            RegisterControllers(builder);


        }

        public static void RegisterWithBuilder(ContainerBuilder builder, AppDomain currentDomain, EnumRegistrationType enumRegistrationType)
        {

            List<Assembly> inventoryControlAssemblyList = new List<Assembly>();
            Assembly[] assembliesArray;

            customRegistration(builder);

            List<Assembly> assemblies = System.Web.Compilation.BuildManager.GetReferencedAssemblies().Cast<Assembly>().ToList();

            foreach (var assembly in assemblies)
            {

                if (assembly.GetName().Name.ToLower().Contains("superzapatos"))
                    inventoryControlAssemblyList.Add(Assembly.Load(assembly.GetName().Name));

            }
            assembliesArray = inventoryControlAssemblyList.ToArray<Assembly>();
            RegisterAssemblyTypes(builder, assembliesArray);

        }



        private static void RegisterAssemblyTypes(ContainerBuilder builder, Assembly[] inventoryControlAssemblies)
        {

            var inventoryControlTypes = inventoryControlAssemblies.SelectMany(a => a.GetTypes())
                .Where(t => !t.IsInterface && !t.IsAbstract).OrderBy(t => t.Name).ToList();
            var interfacesImplements = new Dictionary<Type, Type>();


            Assembly.GetExecutingAssembly().GetTypes().Where(t => !t.IsAbstract).ToList()
                .ForEach(c => RegisterTypeDependencies(c, inventoryControlTypes, interfacesImplements));

            interfacesImplements.ToList().ForEach(
                delegate (KeyValuePair<Type, Type> ii)
                {

                    builder.RegisterType(ii.Value).As(ii.Key).AsImplementedInterfaces();

                });

        }

        private static void RegisterTypeDependencies(Type registerComponenttype, IEnumerable<Type> inventoryControlTypes, IDictionary<Type, Type> typesInterfaces)
        {
            var paramInterfaces = registerComponenttype.GetConstructors().SelectMany(
                c => c.GetParameters()).Select(p => p.ParameterType).Where(
                pt => pt.IsInterface).ToList();

            foreach (var paramInterface in paramInterfaces)
            {

                var types = inventoryControlTypes.Where(paramInterface.IsAssignableFrom).ToList();

                if (!types.Any())
                {

                    break;
                }

                if (types.Count() > 1)
                {

                    break;
                }

                RegisterTypeDependencies(types[0], inventoryControlTypes, typesInterfaces);

                AddComponentType(paramInterface, types[0], typesInterfaces);

            }

        }

        private static void AddComponentType(Type interfaze, Type type, IDictionary<Type, Type> interfacesImplements)
        {
            if (interfacesImplements != null && interfaze != null && type != null &&
                    interfaze.IsInterface &&
                    interfaze.IsAssignableFrom(type) &&
                    !interfacesImplements.ContainsKey(interfaze) &&
                    !_interfaceNamesToBeCustomRegistered.Contains(interfaze))
            {
                interfacesImplements.Add(interfaze, type);
            }

        }



        private static void RegisterControllers(ContainerBuilder builder)
        {

            builder.RegisterControllers(Assembly.GetExecutingAssembly());

        }
    }
}