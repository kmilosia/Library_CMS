using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.Validators
{
    public class NumericValidator : Validator
    {
        public static string IsCorrectNumber(int? value)
        {
            try
            {                
                    if (value < 0 || value > 1000)
                    {
                        return "Wprowadzono nieprawidłową liczbę!";
                    }                
                return null;
            }
            catch (Exception) { }
            return null;
        }      
    }
}
