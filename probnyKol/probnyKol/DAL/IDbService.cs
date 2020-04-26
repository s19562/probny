using probnyKol.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probnyKol.DAL
{
    public interface IDbService
    {
        public IEnumerable<Animal> GetAnimals();
    }
}
