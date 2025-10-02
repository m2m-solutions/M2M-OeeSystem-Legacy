using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;
using System.Linq;
using System.Configuration;


namespace M2M.Integrator.Lexit
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

                if (serviceDependencies.Count > 0)
                    this.serviceInstaller1.ServicesDependedOn = serviceDependencies.ToArray();

            }
            catch (Exception)
            {

            }

            base.Install(stateSaver);
        }
    }
}