using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Model
{
    [Table("City")]
    public class City{
        [Key]
        public int id {get; set;}

        public string NameCity {get; set;}

       public List<Team> Teams {get; set;}

        
    }
    
}