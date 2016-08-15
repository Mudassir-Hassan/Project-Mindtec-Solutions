using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Mindtek.Models
{
    public class Networking
    {
         public int ID { get; set; }

        [StringLength(60,MinimumLength=3)]
        public string Name { get; set; }

        [Display(Name="OrderDate")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString="{0:yyyy-MM-dd}", ApplyFormatInEditMode=true)]
        public DateTime OrderDate { get; set; }


        [StringLength(200,MinimumLength=20)]
        public string Description { get; set; }

        [Display(Name = "OrderCompletion")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderCompletion { get; set; }

    }
    public class Networkingdbcontext : DbContext
    {
        public DbSet<Networking> Networkings { get; set; }
    }
    }
