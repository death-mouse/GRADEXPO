using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace GRADEXPO.Models
{
    [Table("Users")]
    public class Users
    {
        [Key]
        public int userId { get; set; }
        public string role { get; set; }
        public string login { get; set; }
        public string userName { get; set; }
    }
}