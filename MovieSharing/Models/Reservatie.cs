using VideotheekWebApp.Models;

namespace MovieSharing.Models
{
    public class Reservatie
    {
        public int Id { get; set; }
        public String LidId { get; set; }
        public int FilmId { get; set; }
        public Lid? lid { get; set; }
        public Film? film { get; set; }
        public bool Deleted { get; set; }

        public Reservatie()
        {
            Deleted = false;
        }
    }
}
