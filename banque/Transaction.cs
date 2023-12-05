namespace banque {
    public class Transaction{
        public string intitule{get; set;}
        public int montant{get; set;}
        public DateTime date {get; set;}

        public Transaction(string intituleTrans,int montantTrans){
            if(intitule != ""){
                intitule=intituleTrans;
            }else{
                intitule="Transaction";
            }
            montant = montantTrans;
            date = DateTime.Now;
        }
    }

    
}