using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace ThreeAmigos_Corp.Data
{
    public class Customer
    {
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string CustomerName { get; set; }

        [Required]
        public string DeliveryAddress { get; set; }

        [Required]
        public int TelephoneNumber { get; set; }


    }
}
