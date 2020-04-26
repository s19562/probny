using probnyKol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probnyKol.DAL
{
    public class MockDbService : IDbService
    {

        private static IEnumerable<Animal> _animals;

        static MockDbService() {
            _animals = new List<Animal>
            {
                new Animal{IdAnimal = 1 ,Name = "Laki", Type = "pies",AdmissionDate = new DateTime(2020,01,20),  IdOwner = 10  },
                new Animal{IdAnimal = 2 ,Name = "Luk", Type = "ptak", AdmissionDate = new DateTime(2000,02,09) ,  IdOwner = 11 }

            };
                }
        public IEnumerable<Animal> GetAnimals()
        {
            return _animals;
        }
    }
}
