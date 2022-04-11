using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Salot.Helpers
{
    public class UserHelper
    {
        public bool ValidateInsertedUserData(Salot.Data.User insertedUser, out ArgumentException argumentException)
        {
            if (insertedUser.Password.Length < 8)
            {
                argumentException = new ArgumentException("Inserted password not long enough");
                return false;
            }
            if (!Regex.Match(insertedUser.Password, "(?=^.{8,255}$)((?=.*d)(?=.*[A-Z])(?=.*[a-z])|(?=.*)(?=.*[^A-Za-z0-9ÄÖäö])(?=.*[a-z])|(?=.*[^A-Za-z0-9ÄÖäö])(?=.*[A-Z])(?=.*[a-z])|(?=.*)(?=.*[A-Z])(?=.*[^A-Za-z0-9ÄÖäö]))^.*").Success)
            {
                argumentException = new ArgumentException("Inserted password has to contain at least one special character");
                return false;
            }
            if (insertedUser.Email == null || !Regex.Match(insertedUser.Email, "(?=[^A-Za-z0-9ÄÖäö]|(^@)|(.))").Success || insertedUser.Email.Length < 5)
            {
                argumentException = new ArgumentException("Insert valid Email address");
                return false;
            }
            if (insertedUser.Phone != null && (insertedUser.Phone.Length < 10 || !Regex.Match(insertedUser.Phone, "(?=[^0-9]|(?=.*[-])|(^+))").Success))
            {
                argumentException = new ArgumentException("Insert valid phone number");
                return false;
            }
       
            argumentException = null;
            return true;
        }
        public bool ValidateInsertedCredentials(string email, string password, out ArgumentException argumentException)
        {
            if (email == null || !Regex.Match(email, "(?=[^A-Za-z0-9ÄÖäö]|(^@)|(.))").Success || email.Length < 5)
            {
                argumentException = new ArgumentException("Insert valid Email address");
                return false;
            }
            argumentException = null;
            return true;
        }
    }
}
