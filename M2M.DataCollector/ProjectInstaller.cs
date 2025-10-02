using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Configuration;

namespace M2M.DataCollector
{
	[RunInstaller(true)]
	public partial class ProjectInstaller : Installer
	{
		public ProjectInstaller()
		{
			InitializeComponent();
        //    System.Diagnostics.Debugger.Launch();
		}

        static bool isEmpty(string arg)     
        {         
            return String.IsNullOrEmpty(arg);     
        } 

        public override void Install(System.Collections.IDictionary stateSaver)
        {
            try
            {
                List<string> serviceDependencies = new List<string>();
                serviceDependencies.Add(Context.Parameters["Service1"]);
                serviceDependencies.Add(Context.Parameters["Service2"]);
                serviceDependencies.Add(Context.Parameters["Service3"]);
                serviceDependencies.RemoveAll(new Predicate<string>(isEmpty));
                
                if(serviceDependencies.Count > 0)
                    this.serviceInstaller1.ServicesDependedOn = serviceDependencies.ToArray();
                
                string dataSource = Context.Parameters["DataSource"];
                
                string assemblypath = Context.Parameters["assemblypath"];
                string appConfigPath = assemblypath + ".config";

                ExeConfigurationFileMap fileMap = new ExeConfigurationFileMap();
                fileMap.ExeConfigFilename = appConfigPath;

                Configuration config = ConfigurationManager.OpenMappedExeConfiguration(fileMap, ConfigurationUserLevel.None);
                ConnectionStringsSection connSettings = config.ConnectionStrings;

                if (connSettings.ConnectionStrings["M2M.DataCenter.System"] == null)
                    connSettings.ConnectionStrings.Add(new ConnectionStringSettings("M2M.DataCenter.System", dataSource));
                else
                   connSettings.ConnectionStrings["M2M.DataCenter.System"].ConnectionString = dataSource;
                
                config.Save(ConfigurationSaveMode.Modified);

            }
            catch (Exception )
            {
               
            }

            base.Install(stateSaver);
        }
	}
}