using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UserRegistrationAPI.Entities.Models
{
    public class User
    {
        [Key]
        public int USER_ID { get; set; }
        public string FRST_NAME { get; set; }
        public string LAST_NAME { get; set; }
        public string EMAL { get; set; }
        public string PWRD { get; set; }
        public string? ROLE { get; set; }
        public string? TOKN { get; set; }
    }
}
