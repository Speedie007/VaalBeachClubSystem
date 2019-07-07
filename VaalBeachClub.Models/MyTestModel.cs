using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace VaalBeachClub.Web.Models
{
    public class MyTestModel
    {
        public int id { get; set; }
        [Required]
        public string Name { get; set; }

    }
}
