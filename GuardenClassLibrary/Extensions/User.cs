using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GuardenClassLibrary.EF
{
    public class userLoginResultDTO
    {
        public bool isLoged { get; set; }

        public int userId { get; set; }
    }
    public partial class tblUser
    {
        public static bool AddClicksToArea( int id)
        {
            GuardenDB db = new GuardenDB();
            tblArea area = db.tblAreas.Where(a => a.Area_ID == id).SingleOrDefault();
            if (area != null)
            {
                area.Clicks += 1;
                db.SaveChanges();
                return true;
            }
            return false;
        }
        public static userLoginResultDTO CheckUserLogIn(string Email, string Password)
        {
            
            GuardenDB db = new GuardenDB();
            tblUser s = db.tblUsers.Where(x => x.Email.ToLower() == Email.ToLower()).SingleOrDefault();
            userLoginResultDTO user = new userLoginResultDTO() {isLoged=false,userId=-1 };
            if (s != null)
            {
                if (s.Password == Password)
                {
                    user.isLoged = true;
                    user.userId = s.ID;
                }
            }
            return user;
        }
       

        public static string CheckUserForgotPasswordAndUpdateOTP(string Email, int OTP)
        {
            string name = null;
            GuardenDB db = new GuardenDB();
            tblUser s = db.tblUsers.Where(x => x.Email.ToLower() == Email.ToLower()).SingleOrDefault();
            if (s!= null)
            {
                name = s.Name;
                s.OTP = OTP;
                db.SaveChanges();
            }
            return name;
        }
        public static bool CheckOTP(string Email,int OTP)
        {
            bool verified = false;
            GuardenDB db = new GuardenDB();
            tblUser s = db.tblUsers.Where(x => x.Email.ToLower() == Email.ToLower()).SingleOrDefault();
            if (s.OTP == OTP)
            {
                verified = true;
                s.OTP = -1;
                db.SaveChanges();
            }
            return verified;
        }

        public static bool ChangePassword(string email, string password)
        {
            
            GuardenDB db = new GuardenDB();
            tblUser u = db.tblUsers.Where(x => x.Email.ToLower() == email.ToLower()).SingleOrDefault();
            u.Password = password;
            db.SaveChanges();
            return true;
        }
    }
}
