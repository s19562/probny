using probnyKol.DTOs.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace probnyKol.Services
{
    public interface IAnimalDbService
    {
        void BadankoAnimal(BadankoAnimalReguest reguest); //cos powinny zwracac te metody 
        void PromoteStudents(int semester, string studies);
    }
}
