namespace VideotheekWebApp.Models
{
    public class Film
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Regisseur { get; set; }
        public String Acteurs { get; set; }
        public String Genre { get; set; }
        public float Prijs { get; set; }
        public bool Deleted { get; set; }
        public int Aantal { get; set; }


        public Film()
        {
            Deleted = false;
            Aantal = 1; 
        }

    }
}
