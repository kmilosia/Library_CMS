using Library_Management_System.Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library_Management_System.Models.Validators
{
    public class StringValidator : Validator
    {
        public static string HasCapitalLetter(string value)
        {
            try
            {
                if (!char.IsUpper(value, 0) && value != null)
                {
                    return "Wartość powinna zaczynać się dużą literą!";
                }
                return null;
            }
            catch (Exception){}
            return null;
        }
        public static string IsYear(string value)
        {
            try
            {
                int example = 0;
                bool isNumeric = int.TryParse(value, out example);
                if(value != null && value != "" && !isNumeric)
                {
                    return "Podana wartość musi być liczbą!";
                }
                if (value != null && value != "" && value.Length != 4)
                {
                    return "Wprowadź prawidłowy rok!";
                }
                return null;
            }
            catch (Exception) { }
            return null;
        }
        public static string IsNumber(string value)
        {
            try
            {
                int example = 0;
                bool isNumber = int.TryParse(value, out example);
                if (value != null && value != "" && !isNumber)
                {
                    return "Podana wartość musi być liczbą!";
                }                
                return null;
            }
            catch (Exception) { }
            return null;
        }
        public static string IsEmail(string value)
        {
            try
            {
                if (value != null && value != "" && (!value.Contains("@") || !value.Contains(".")))
                {                 
                        return "Nieprawidłowy format adresu email!";
                }              
                return null;
            }
            catch (Exception) { }
            return null;
        }        
        public static string IsPhoneNumber(string value)
        {
            try
            {
                if (value != null && value != "")
                {
                    if (!value[0].Equals('+'))
                    {
                        return "Prawidłowy format numeru: +48xxxxxxxxx";
                    }
                    string result = value.Remove(0, 1);
                    long example = 0;
                    bool isNumber = long.TryParse(result, out example);
                    if (!isNumber)
                    {
                        return "Numer telefonu musi składać się z samych cyfr!";
                    }
                }
                return null;
            }
            catch (Exception) { }
            return null;
        }
    }
}
