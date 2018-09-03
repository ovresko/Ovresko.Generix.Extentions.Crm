
using MongoDB.Bson.Serialization.Attributes;
using Ovresko.Generix.Core.Modules.Core.Helpers;
using Ovresko.Generix.Core.Modules.Core.Module;
using Ovresko.Generix.Datasource.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ovresko.Generix.Core.Translations.OvTranslate;
namespace Ovresko.Generix.Extentions
{
    class DomaineActivite : ModelBase<DomaineActivite>
    {
        public override bool Submitable { get; set; } = false;
        public override string ModuleName { get; set; } = "Clientèle";
        public override string CollectionName { get; } = _("Secteurs d’activité");
        public override OpenMode DocOpenMod { get; set; } = OpenMode.Attach;
        public override string IconName { get; set; } = "BriefcaseCheck";
        public override bool ShowInDesktop { get; set; } = false;
        public override string NameField => "Domaine";
        public override int MenuIndex => 21;
        
        public DomaineActivite()
        {

        }


        [ColumnAttribute(ModelFieldType.Text, "")]
        [ExDisplayName("Libellé")]
        [IsBold] 
        public string Domaine { get; set; }


        public override void Validate()
        {
            base.Validate();
            base.ValidateUnique();

             
        }

         
        [BsonIgnore]
        [ExDisplayName("Clients opérant")]
        [ColumnAttribute(ModelFieldType.LienButton, "Client>lDomaineActivite")]
        public string ClientDomeine { get; set; }

    }
}
