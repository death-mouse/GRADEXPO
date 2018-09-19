using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;

namespace GRADEXPO.Models
{
    [Table("Users")]
    public class Users
    {
        public class User
        {
            [Key]
            public int role { get; set; }
            public string phone { get; set; }
            public string login { get; set; }
            public string userName { get; set; }
            public int userId { get; set; }
            public string email { get; set; }
        }

        public class RootObject
        {
            public List<User> value { get; set; }
        }
    }

   
}