 
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static Ovresko.Generix.Core.Translations.OvTranslate;
using System.Threading.Tasks;
using Ovresko.Generix.Core.Modules.Core.Module;
using Ovresko.Generix.Core.Modules.Core.Helpers;
using Ovresko.Generix.Datasource.Models;

namespace Ovresko.Generix.Extentions
{
   public class Adresse : ModelBase<Adresse>
    {

        #region SETTINGS

        public override bool Submitable { get; set; } = false;
        public override string ModuleName { get; set; } = "Clientèle";
        public override string CollectionName { get; } = _("Adresse");
        public override OpenMode DocOpenMod { get; set; } = OpenMode.Detach;
        public override string IconName { get; set; } = "MapMarker";
        public override bool ShowInDesktop { get; set; } = false;

        public override string NameField { get; set; } = "AdresseName";

        #endregion
          
        public override void Validate()
        {
            base.Validate();
            base.ValidateUnique();

        }

       


        public Adresse()
        {

        } 

        
        [ColumnAttribute(ModelFieldType.Text, "")]
        [ExDisplayName("Adresse")]
        public string AdresseName { get; set; }

         

    }
}
