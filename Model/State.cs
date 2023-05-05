using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    [Table("State")]

    public class State{
        [Key]

        public int Id {get; set;}

        public int Score {get; set;}

        public int Shoot {get; set;}

        public int Asissitance {get; set;}

        public string Match {get; set;}

        public Player Player {get; set;}

        
    }
    
}