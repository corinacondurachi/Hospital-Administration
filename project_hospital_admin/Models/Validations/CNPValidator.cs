using System;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using project_hospital_admin.Areas.Identity.Pages.Account;

namespace project_hospital_admin.Models.Validations
{
    public class CNPValidator :  ValidationAttribute
    {
        
        private ValidationResult validateCNP(string cnp)
        {
            if (cnp == null)
                return new ValidationResult("CNP field is required!");

            Regex regex = new Regex(@"^([1-9]\d+)$");
            if (!regex.IsMatch(cnp))
                return new ValidationResult("CNP must contain only digits!");

            if (cnp.Length != 13)
                return new ValidationResult("CNP must contain 13 digits!");
            

            char s = cnp.ElementAt(0);
            string aa = cnp.Substring(1, 2);
            string ll = cnp.Substring(3, 2);
            string zz = cnp.Substring(5, 2);
            string jj = cnp.Substring(7, 2);
            string nnn = cnp.Substring(9, 3);
            char c = cnp.ElementAt(12);
            
            if (s - '0' > 8)
            {
                return new ValidationResult("S part is not valid!");
            }

            int luna = Int32.Parse(ll);
            if (luna > 13 || luna == 0)
                return new ValidationResult("LL part is not valid!");

            int ziua = Int32.Parse(zz);
            if (ziua > 31 || ziua == 0)
                return new ValidationResult("ZZ part is not valid!");
            

            regex = new Regex(@"^((00[1-9])|(0[1-9]\d)|([1-9]\d{2}))$");
            if (!regex.IsMatch(nnn))
                return new ValidationResult("NNN part is not valid!");

            // validam componenta C
            int rez = (s - '0') * 2;
            rez += (aa.ElementAt(0) - '0') * 7 + (aa.ElementAt(1) - '0') * 9;
            rez += (ll.ElementAt(0) - '0') * 1 + (ll.ElementAt(1) - '0') * 4;
            rez += (zz.ElementAt(0) - '0') * 6 + (zz.ElementAt(1) - '0') * 3;
            rez += (jj.ElementAt(0) - '0') * 5 + (jj.ElementAt(1) - '0') * 8;
            rez += (nnn.ElementAt(0) - '0') * 2 + (nnn.ElementAt(1) - '0') * 7 + (nnn.ElementAt(2) - '0') * 9;
            rez %= 11;
            if (rez == 10)
            {
                if (!c.Equals('1'))
                    return new ValidationResult("C part is not valid!");
            }
            else
            {
                if ((c - '0') != rez)
                    return new ValidationResult("C part is not valid!");
            }
            return ValidationResult.Success;
        }
        
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            return validateCNP(value.ToString());
        }
    }
}
    