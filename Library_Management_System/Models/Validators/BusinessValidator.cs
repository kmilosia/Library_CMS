using Library_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.Validators
{
    public class BusinessValidator : Validator
    {
        public static string IsISBN(string value)
        {
            long example = 0;
            bool isNumeric = long.TryParse(value, out example);
            if (value != null && !isNumeric)
            {
                return "Podana wartość musi być liczbą!";
            }
            if (value != null && (value.Length > 13 || value.Length < 10))
            {
                return "Numer ISBN ma 10 lub 13 cyfr!";
            }
            return null;
        }
        public static string CompareBorrowingAndReturningDate(DateTime? older, DateTime? newer)
        {
            if (older > newer)
            {
                return "Data oddania nie może być wcześniejsza niż data wypożyczenia!";
            }
            return null;
        }
        public static string CompareBorrowingAndDeadlineDate(DateTime? older, DateTime? newer)
        {
            if (older > newer)
            {
                return "Termin oddania nie może być wcześniejszy niż data wypożyczenia!";
            }
            return null;
        }
        public static string IsCorrectRate(decimal? rate)
        {
            if (rate <= 0 || rate > 10)
            {
                return "Rata powinna mieścić się w przedziale od 0.1 zł do 10 zł!";
            }
            return null;
        }
    }
}
