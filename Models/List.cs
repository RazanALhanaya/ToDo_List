using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace todoList.Models
{
    [Table("list")]
    public class List
    {
        //attributes 
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Display(Name = "Task number")]
        public int ListId { get; set; }


        //attributes  
        [Required]
        [Column(TypeName="varchar(50)")]
        [Display(Name = "Task")]
        public string Task { get; set; }


        //attributes  
        [Required]
        [Column(TypeName = "varchar(10)")]
        [Display(Name = "Date")]
        public String DateOfTask { get; set; } 


        [DataType(DataType.Time)]
        [Column(TypeName = "varchar(10)")]
        [Display(Name = "Time")]
        public TimeSpan TimeOfTask { get; set; }
    }
}
