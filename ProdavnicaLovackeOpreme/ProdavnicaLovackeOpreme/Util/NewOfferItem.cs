using Org.BouncyCastle.Asn1.Mozilla;
using ProdavnicaLovackeOpreme.Commands;
using System.Collections.ObjectModel;

namespace ProdavnicaLovackeOpreme.Util
{
    public class NewOfferItem
    {
        public int OfferId { get; set; }
        public String SupplierName { get; set; }
        public String SupplierJIB {  get; set; } 
        public List<NewOfferItems> OfferItems { get; set; }

        public RelayCommand AcceptOffer {  get; set; }
        public RelayCommand DeclineOffer { get; set; }

    }
}
