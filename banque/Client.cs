using System.ComponentModel;

namespace banque {
    public class Client{
        public string nom{ get; set;}
        public string prenom{ get; set;}
        public List<CompteBancaire> comptes{get; set;} = new List<CompteBancaire>();

    }
}