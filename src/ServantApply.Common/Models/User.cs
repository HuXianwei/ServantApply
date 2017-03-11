using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ServantApply.Common.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "没有什么")]
        [StringLength(30, ErrorMessage = "名字太长")]
        public string Name { get; set; }

        [MaxLength(50)]
        public string Last_name { get; set; }

        public List<Test> Tests { get; set; } 
    }
}
