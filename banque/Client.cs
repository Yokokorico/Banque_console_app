using System.ComponentModel;

namespace banque {
    public class Client{
        public string nom{ get; set;} = "Crapaud";
        public string prenom{ get; set;} = "Theo";
        public List<CompteBancaire> comptes{get; set;}

    }
}