using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    [Table("Team")]
    public class Team{
        [Key]
        public int id {get; set;}

        public string TeamName {get; set;}

        public string Owner {get; set;}

        public int NumberOfWins {get; set;}

        public string Street {get; set;}

        public string BuildingNumber {get; set;}
        

        public List<Player> Players {get; set;}

       public City City {get; set;}

        public string NameCities { get; set; }
    }
}