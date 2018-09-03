using AutoUpdaterDotNET;
using MongoDB.Bson.Serialization.Attributes;
using Ovresko.Generix.Core.Modules.Core.Data;
using Ovresko.Generix.Core.Modules.Core.Module;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static Ovresko.Generix.Core.Translations.OvTranslate;


namespace Ovresko.Generix.Extentions
{
    public class CrmSettings : ModelBase<CrmSettings>
    {
        [BsonIgnore]
        public override string ModuleName { get; set; } = "Clientèle";
        public override bool IsInstance { get; set; } = true;
        public override bool ShowInDesktop { get; set; } = false;
        public override string CollectionName { get; } = _("Paramétres Clientèle");

        public override string Name
        {
            get
            {
                return _("Paramétres Clientèle");
            }
            set => base.Name = value;
        }


        public CrmSettings()
        {

        }

        [BsonIgnore]
        private static CrmSettings Instance { get; set; } = null;






        public static CrmSettings getInstance()
        {
            if (Instance != null)
                return Instance;

            var instance = DS.db.Count<CrmSettings>(a => true);
            if (instance > 0)
            {
                return Instance = DS.db.GetOne<CrmSettings>(t => true);
            }
            else
            {
                DS.db.AddOne<CrmSettings>(new CrmSettings() { isLocal = false });
                return Instance = DS.db.GetOne<CrmSettings>(a => true);
            }
        }


        public override void InstallWithBootstrap()
        {
            // Load Translations



            base.InstallWithBootstrap();
            var module = getInstance();

        }


        public override void RunWithBootstrap()
        {
            base.RunWithBootstrap();

            ModuleIcons.ModuleIcon.Add(_("Clientèle"), "AccountSettingsVariant");

            //AutoUpdater.Mandatory = true;
            //AutoUpdater.AppTitle = "Plugin  CRM";

            //AutoUpdater.Start("https://ovresko.com/OvreskoUpdates/CrmModule.xml",
            //                    Assembly.LoadFrom(Path.GetFullPath("Plugins/CrmModule.dll")));

            //AutoUpdater.ApplicationExitEvent += AutoUpdater_ApplicationExitEvent;
        }
        private void AutoUpdater_ApplicationExitEvent()
        {
            Thread.Sleep(5000);
            Environment.Exit(0);// DataHelpers.Shell.showClose();//.Exit();//.Exit();
        }
    }
}
