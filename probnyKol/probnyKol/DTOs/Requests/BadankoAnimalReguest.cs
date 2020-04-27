using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace probnyKol.DTOs.Requests
{
    public class BadankoAnimalReguest
    {
        [Required]
        public int IdAnimal { get; set; }

        [Required(ErrorMessage ="Musisz podac imie")]
        [MaxLength(100)]
        public string Name { get; set; }

        [Required]
        public int IdOwner { get; set; }

        [Required] //to jest blad 400 
        public string NazwaBadanko { get; set; }

      



    }
}
