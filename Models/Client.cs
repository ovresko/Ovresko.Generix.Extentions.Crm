using Ovresko.Generix.Core.Modules.Core.Data;
using Ovresko.Generix.Core.Modules.Core.Helpers;
using Ovresko.Generix.Core.Modules.Core.Module;
using Ovresko.Generix.Core.Pages.Helpers;
using Ovresko.Generix.Core.Pages.Template;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Ovresko.Generix.Core.Translations.OvTranslate;
using System.Windows;
using Ovresko.Generix.Core.Pages.Reports;
using Ovresko.Generix.Core.Modules.Base;
using Ovresko.Generix.Core.Modules;
using Ovresko.Generix.Datasource.Services.Queries;
using Ovresko.Generix.Datasource.Models;

namespace Ovresko.Generix.Extentions
{
    public class Client : ModelBase<Client>
    {

        #region SETTINGS

        public override bool Submitable { get; set; } = false;
        public override string ModuleName { get; set; } = "Clientèle";
        public override string CollectionName { get; } = _("Client");
        public override OpenMode DocOpenMod { get; set; } = OpenMode.Attach;
        public override string IconName { get; set; } = "AccountMultiple";  
        public override bool ShowInDesktop { get; set; } = true;

        #endregion

        #region NAMING

        public override string NameField { get; set; } = "NomComplet";

        [ExDisplayName("Série")]
        [Column(ModelFieldType.LienField, "MyModule()>SeriesNames")]
        [myType(typeof(ModuleErp))]
        public Guid Series { get; set; } = Guid.Empty;

        #endregion

        #region CONSTRUCTOR

        public Client()
        {
            Series = GuidParser.Convert((MyModuleBase())?.SeriesDefault); 
        }

        #endregion

        #region VALIDATION

        public override void Validate()
        {
            base.Validate();
            base.ValidateUnique();
        }

        #endregion

        #region PROPERTIES

        [Required]
        [ColumnAttribute(ModelFieldType.Text, "")]
        [ShowInTable(true)]
        [IsBold]
        [ExDisplayName("Nom complet")]
        public string NomComplet { get; set; }


        [ColumnAttribute(ModelFieldType.Text, "")]
        [ShowInTable]
        [ExDisplayName("Identifiant / Numéro interne")]
        public string Identifiant { get; set; }


        [ColumnAttribute(ModelFieldType.Select, "Sexe")]
        [ExDisplayName("Sexe")]
        public string SexeClient { get; set; }

        [ColumnAttribute(ModelFieldType.Select, "TypeClient")]
        [ExDisplayName("Type client")]
        public string TypeClient { get; set; }

       

        [ShowInTable(true)]
        [ColumnAttribute(ModelFieldType.Text, "")]
        [ExDisplayName("Mobile")]
        public string TelMob { get; set; }




        [ColumnAttribute(ModelFieldType.Separation, "")]
        [BsonIgnore]
        [ExDisplayName("Coordonées")]
        public string sepCoord { get; set; }

        [ColumnAttribute(ModelFieldType.Text, "")]
        [ExDisplayName("Région")]
        public string Region { get; set; }


        //[ExDisplayName("Est un Client ?")]
        //[Column(ModelFieldType.Check, "")]
        //public bool IsClient { get; set; }

        //[ExDisplayName("Est un Fournisseur ?")]
        //[Column(ModelFieldType.Check, "")]
        //public bool IsFournisseur { get; set; }

        [ShowInTable]
        [ExDisplayName("Groupe client")]
        [ColumnAttribute(ModelFieldType.Lien, "GroupeClient")]
        public Guid GroupeClient { get; set; } = Guid.Empty;



        [ExDisplayName("Domaine d'activité")]
        [ColumnAttribute(ModelFieldType.Lien, "DomaineActivite")]
        public Guid lDomaineActivite { get; set; } = Guid.Empty;


        [Column(ModelFieldType.Lien, "ListePrix")]
        [ExDisplayName("Liste des prix")]

        public Guid ListPrix { get; set; } = Guid.Empty;
        [ExDisplayName("Contact principal du client")]
        [ColumnAttribute(ModelFieldType.Lien, "Contact")]
        public Guid ContactPrincipal { get; set; } = Guid.Empty;

     

        [ShowInTable(true)]
        [ColumnAttribute(ModelFieldType.Text, "")]
        [ExDisplayName("N° Téléphone")]
        public string TelFix { get; set; }

        [ShowInTable(true)]
        [ColumnAttribute(ModelFieldType.Text, "")]
        [ExDisplayName("N° Fax")]
        public string TelFax { get; set; }

        [ShowInTable(true)]
        [ColumnAttribute(ModelFieldType.Text, "")]
        [ExDisplayName("Email")]
        public string Email { get; set; }

        [ShowInTable(true)]
        [ColumnAttribute(ModelFieldType.Text, "")]
        [ExDisplayName("Site web")]
        public string Siteweb { get; set; }

        [ExDisplayName("Adresse par default")]
        [ColumnAttribute(ModelFieldType.LienField, "Adresses")]
        public Guid AdresseLivraison { get; set; } = Guid.Empty;

        [SetColumn(2)]
        [Column(ModelFieldType.ReadOnly,"")]
        [ExDisplayName("Adresse")]
        public string AdresseName { get { return AdresseLivraison.GetName<Adresse>(); } }
        //------------------------------------

        [ColumnAttribute(ModelFieldType.Separation, "false")]
        [BsonIgnore]
        [ExDisplayName("Adresses")]
        public string sepAderss { get; set; }

        [ShowInTableAttribute(false)]
        [ColumnAttribute(ModelFieldType.Table, "Adresse")]
        [ExDisplayName("Adresses")]
        [myTypeAttribute(typeof(Adresse))]
        public List<Adresse> Adresses { get; set; } = new List<Adresse>();


        // --------------------------------


        [ColumnAttribute(ModelFieldType.Separation, "false")]
        [BsonIgnore]
        [ExDisplayName("Infos compte")]
        public string sepcompte { get; set; }


        [ColumnAttribute(ModelFieldType.Text, "")]
        [ExDisplayName("NIF")]
        public string NIF { get; set; }

        [ColumnAttribute(ModelFieldType.Text, "")]
        [ExDisplayName("N° RC")]
        public string NRC { get; set; }


        // -------------------------------


        [ColumnAttribute(ModelFieldType.Separation, "false")]
        [BsonIgnore]
        [ExDisplayName("Contacts")]
        public string sepContacts { get; set; }


        [ShowInTableAttribute(false)]
        [ColumnAttribute(ModelFieldType.Table, "Contact")]
        [ExDisplayName("Contacts")]
        [myTypeAttribute(typeof(Contact))]
        public List<Contact> ClientContact { get; set; } = new List<Contact>();

        [ColumnAttribute(ModelFieldType.TextLarge, "false")]
        [ShowInTable(false)]
        [ExDisplayName("Détails du client")]
        public string Details { get; set; }

        [ColumnAttribute(ModelFieldType.ImageSide, "Image")]
        [ShowInTableAttribute(false)]
        [ExDisplayName("Image")]
        public string Logo { get; set; }


        [ColumnAttribute(ModelFieldType.Separation, "false")]
        [BsonIgnore]
        [ExDisplayName("COMPTABILITÉ")]
        public string sepCompte { get; set; }

        [ExDisplayName("Compte débiteur par default")]
        [ColumnAttribute(ModelFieldType.Lien, "CompteCompta")]
        public Guid CompteComptaDefault { get; set; } = Guid.Empty;

        [ColumnAttribute(ModelFieldType.Devise, "")]
        [ShowInTableAttribute(false)]
        [ExDisplayName("Limite de crédit")]
        public decimal MontantCreditMax { get; set; }


        //[ColumnAttribute(ModelFieldType.Table, "TaxeLigne")]
        //[ShowInTable(false)]
        //[ExDisplayName("Taxes appliquées par default")]
        //[myTypeAttribute(typeof(Taxe))]
        //public List<TaxeLigne> TaxeLigne { get; set; } = new List<TaxeLigne>();

        #endregion

        #region ACTIONS

        //[BsonIgnore]
        //[ColumnAttribute(ModelFieldType.OpsButton, "GenererRapport")]
        //[ExDisplayName("Rapport Compte")]
        //public string GenererRapportBtn { get; set; }

        //public async void GenererRapport()
        //{

        //    //var repor = new ReportViewModel(new RapportCompteClient(this));
        //    //repor.DisplayName = $"Rapport client {NomComplet}"; 
        //    //DataHelpers.Shell.OpenScreen(repor, repor.DisplayName);


        //    //var report = new ReportChiffreAffaireViewModel(this);
        //    //var list = new List<IReportViewModel>() { report};

        //    //var therepor = new ReportViewModel(list);
        //    //therepor.DisplayName = _($"Solde De Stock");
        //    // var situation = new RapportCituationClient(this.Id); 
        //   var wie= await DataHelpers.GetBaseViewModelScreen(typeof(SoldeClient_report), DataHelpers.Aggre, false);//.Shell.ope(situation, situation.Name);
        //    DataHelpers.Shell.OpenScreen(wie, "Solde Client");
        //}


        #endregion

        #region LINKS

        [BsonIgnore]
        [ExDisplayName("Réservations")]
        [ColumnAttribute(ModelFieldType.LienButton, "Reservation>Client")]
        public string ReservationClient { get; }


        [BsonIgnore]
        [ExDisplayName("Projets")]
        [ColumnAttribute(ModelFieldType.LienButton, "Projet>Client")]
        public string ProjetClient { get; set; }


        [BsonIgnore]
        [ExDisplayName("Devis")]
        [ColumnAttribute(ModelFieldType.LienButton, "Devis>Client")]
        public string ClientDevis { get; set; }

        [BsonIgnore]
        [ExDisplayName("Factures de ventes")]
        [ColumnAttribute(ModelFieldType.LienButton, "Facture>Client")]
        public string lClient { get; set; }

        [BsonIgnore]
        [ExDisplayName("Commandes de ventes")]
        [ColumnAttribute(ModelFieldType.LienButton, "CommandeVente>Client")]
        public string lClientCommandeVente { get; set; }


        [BsonIgnore]
        [ExDisplayName("Bon de livraison")]
        [ColumnAttribute(ModelFieldType.LienButton, "BonLivraison>Client")]
        public string BonLivraisonClient { get; set; }


        [BsonIgnore]
        [ExDisplayName("Commande d'achat")]
        [ColumnAttribute(ModelFieldType.LienButton, "CommandeAchat>Client")]
        public string CommandeAchatClient { get; set; }


        [BsonIgnore]
        [ExDisplayName("Factures d'achat")]
        [ColumnAttribute(ModelFieldType.LienButton, "FactureAchat>Client")]
        public string FactureAchatClient { get; set; }


        [BsonIgnore]
        [ExDisplayName("Bon de reception")]
        [ColumnAttribute(ModelFieldType.LienButton, "BonReception>Client")]
        public string BonReceptionClient { get; set; }

        [BsonIgnore]
        [ExDisplayName("Écritures paiement")]
        [ColumnAttribute(ModelFieldType.LienButton, "EcriturePaiment>Client")]
        public string ClientEcriturePaiment { get; set; }





        #endregion

        // #region CARDS

             


        //public override DocCard DocCardFor
        //{
        //    get
        //    {
        //        return new DocCard()
        //        {

        //            BulletIcon = "Coin",
        //            BulletTitle = "Solde client",
        //            BulletValue = $"{String.Format("{0:N}", TauxSolde())} DA"
        //        };
        //    }
        //}

        //public override DocCard DocCardOne
        //{
        //    get
        //    {
        //        return new DocCard()
        //        {
        //            BulletIcon = "AccountCardDetails",
        //            BulletTitle = "Nom client",
        //            BulletValue = this.NomComplet
        //        };
        //    }
        //}

        //public override DocCard DocCardThree
        //{
        //    get
        //    {
        //        return new DocCard()
        //        {
        //            BulletIcon = "ChartBar",
        //            BulletTitle = "Chiffre d'affaire",
        //            BulletValue = $"{String.Format("{0:N}", ChiffreAffaire())} DA"
        //        };
        //    }
        //}

        //public override DocCard DocCardTow
        //{
        //    get
        //    {
        //        return new DocCard()
        //        {
        //            BulletIcon = "CellphoneBasic",
        //            BulletTitle = "Contact",
        //            BulletValue = (this.TelMob == "") ? this.TelFix : this.TelMob
        //        };
        //    }
        //}
         
    }
}
