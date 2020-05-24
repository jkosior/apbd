using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace zadanie2.Models
{
    [Table("Studies")]
    public class Study
    {
        [Key]
        public int IdStudy { get; set; }

        public string Name { get; set; }
    }
}