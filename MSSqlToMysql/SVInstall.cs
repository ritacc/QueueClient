using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration.Install;


namespace QM.Client.UpdateDB
{
    [RunInstaller(true)]
    public partial class SVInstall : System.Configuration.Install.Installer
    {
        public SVInstall()
        {
            InitializeComponent();
        }
    }
}
