using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace StoreCell.Models
{
    public class RegisterProduct
    {
        public RegisterProduct ()
        {

        }

        [Key]
        public int ProductID { get; set; }
        
        public string Nmae { get; set; }
        public string Brand { get; set; }

        public string Version { get; set; }

        public virtual ICollection<RegisterProv> RegisterProvs { get; set; }



    }
}