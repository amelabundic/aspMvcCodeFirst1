using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace aspMvcCodeFirst1.Models
{
    [Table("Osoba")]
   
        public class Osoba
        {
            public int OsobaId { get; set; }

            [Required(ErrorMessage = "Unesite ime")]
            [StringLength(30, ErrorMessage = "Najvise 30 karaktera")]
            public string Ime { get; set; }

            [Required(ErrorMessage = "Unesite prezime")]
            [StringLength(30, ErrorMessage = "Najvise 30 karaktera")]
            public string Prezime { get; set; }

            [Required(ErrorMessage = "Unesite adresu")]
            [StringLength(60, ErrorMessage = "Najvise 60 karaktera")]
            public string Adresa { get; set; }
        }
    
}
