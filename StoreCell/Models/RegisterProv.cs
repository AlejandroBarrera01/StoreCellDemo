using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace StoreCell.Models
{
    public class RegisterProv
    {
        public RegisterProv ()
        {

        }

        [Key]
        public int ProvID { get; set; }

        public string ProvName{ get; set; }

        public string ProvEmail { get; set; }

        public string ProvPhone { get; set; }

        public virtual ICollection<ProviProduct> ProviProducts { get; set; }
    }
}