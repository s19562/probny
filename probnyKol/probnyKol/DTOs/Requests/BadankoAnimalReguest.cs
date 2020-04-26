using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace probnyKol.DTOs.Requests
{
    public class BadankoAnimalReguest
    {
        public int IdAnimal { get; set; }

        [Required(ErrorMessage ="Musisz podac imie")]
        [MaxLength(100)]
        public string Name { get; set; }
        public string Type { get; set; }
        public DateTime AdmissionDate { get; set; }
        public int IdOwner { get; set; }

        [Required]
        public string NazwaBadanko { get; set; }

    }
}
