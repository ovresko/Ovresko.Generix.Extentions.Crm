using Ovresko.Generix.Core.Modules.Core.Helpers;
using Ovresko.Generix.Core.Modules.Core.Module;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using static Ovresko.Generix.Core.Translations.OvTranslate;
using System.Threading.Tasks;
using Ovresko.Generix.Datasource.Models;

namespace Ovresko.Generix.Extentions
{
    class GroupeClient : ModelBase<GroupeClient>
    {
        #region SETTINGS

        public override bool Submitable { get; set; } = false;
        public override string ModuleName { get; set; } = "Clientèle";
        public override string CollectionName { get; } = _("Groupe Client");
        public override OpenMode DocOpenMod { get; set; } = OpenMode.Attach;
        public override string IconName { get; set; } = "Gears";
        public override bool ShowInDesktop { get; set; } = false;

        public override string NameField { get; set; } = "Designiation";

        #endregion
         
         
        public override void Validate()
        {
            base.Validate();
            base.ValidateUnique();

            //   Nom
            if (string.IsNullOrWhiteSpace(Designiation))
                throw new Exception("Designiation est obligatoire");

        }
        

        public GroupeClient()
        {

        }
 
        [ColumnAttribute(ModelFieldType.Text, "")]
        [IsBoldAttribute(true)]
        [ShowInTable(true)]
        [ExDisplayName("Designation")]
        public string Designiation { get; set; }
    }
}
