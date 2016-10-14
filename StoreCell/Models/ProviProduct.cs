using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;


namespace StoreCell.Models
{
    public class ProviProduct
    {
        public ProviProduct()
        {

        }

        [Key]
        public int IDPP { get; set; }

        public int IDProvider { get; set; }

        public int IDProduct { get; set; }

        public string Date { get; set; }

        public int Amount { get; set; }

        public virtual RegisterProv RegisterProvs { get; set; }

        public virtual RegisterProduct RegisterProducts { get; set; }

    }
}