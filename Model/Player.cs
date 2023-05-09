using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    [Table("Player")]

    public class Player{
        [Key]
        public int Id {get; set;}

        public string FirstName {get; set;}

        public string LastName {get; set;}

        public int Age {get; set;}

        public double Height {get; set;}

        public int Jersey {get; set;}

        public int Position {get; set;}

        public Team Team {get; set;}

        public string PlayForTeam {get; set;}

        public List<State> States {get; set;}

        [NotMapped]
        public int Counter { get; set; }

    }
    
}