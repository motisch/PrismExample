using Microsoft.Practices.ServiceLocation;
using Prism.Unity;
using System;
using System.Windows;
using Microsoft.Practices.Unity;
using Prism.Logging;
using Prism.Modularity;

namespace Lightning.Shell
{
    public class Bootstrapper : UnityBootstrapper
    {
        private readonly CallbackLogger callbackLogger = new CallbackLogger();

        protected override DependencyObject CreateShell()
        {
            return ServiceLocator.Current.GetInstance<Shell>();
        }

        protected override void InitializeShell()
        {
            base.InitializeShell();
            Application.Current.MainWindow = (Window)this.Shell;
            Application.Current.MainWindow.Show();
        }
        protected override ILoggerFacade CreateLogger()
        {
            return callbackLogger;
        }

        protected override void ConfigureContainer()
        {
            base.ConfigureContainer();

            //this.RegisterTypeIfMissing(typeof(IModuleTracker), typeof(ModuleTracker), true);

            //this.Container.RegisterInstance<CallbackLogger>(this.callbackLogger);
        }
        
        /// </remarks>
        protected override IModuleCatalog CreateModuleCatalog()
        {
            return new AggregateModuleCatalog();
        }

        protected override void ConfigureModuleCatalog()
        {
            //// Module A is defined in the code.
            //Type moduleAType = typeof(ModuleA);
            //ModuleCatalog.AddModule(new ModuleInfo(moduleAType.Name, moduleAType.AssemblyQualifiedName));

            //// Module C is defined in the code.
            //Type moduleCType = typeof(ModuleC);
            //ModuleCatalog.AddModule(new ModuleInfo()
            //{
            //    ModuleName = moduleCType.Name,
            //    ModuleType = moduleCType.AssemblyQualifiedName,
            //    InitializationMode = InitializationMode.OnDemand
            //});

            //// Module B and Module D are copied to a directory as part of a post-build step.
            //// These modules are not referenced in the project and are discovered by inspecting a directory.
            //// Both projects have a post-build step to copy themselves into that directory.
            //DirectoryModuleCatalog directoryCatalog = new DirectoryModuleCatalog() { ModulePath = @".\DirectoryModules" };
            //((AggregateModuleCatalog)ModuleCatalog).AddCatalog(directoryCatalog);

            //// Module E and Module F are defined in configuration.
            //ConfigurationModuleCatalog configurationCatalog = new ConfigurationModuleCatalog();
            //((AggregateModuleCatalog)ModuleCatalog).AddCatalog(configurationCatalog);

        }
    }
}