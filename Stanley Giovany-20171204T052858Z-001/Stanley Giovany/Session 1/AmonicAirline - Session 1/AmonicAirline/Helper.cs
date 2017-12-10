using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace AmonicAirline
{
    class Helper
    {
        public static string GetTimeDifference(DateTime before, DateTime after, string format)
        {
            TimeSpan diff = after - before;
            return diff.ToString(format);
        }

        public static int GenerateUserId()
        {
            session1Entities entities = new session1Entities();
            User u = entities.Users.OrderByDescending(x => x.ID).FirstOrDefault();

            return u == null ? 1 : u.ID + 1;
        }

        public static string HashStringToMD5(string text)
        {
            MD5 md5 = MD5.Create();

            byte[] inputBytes = System.Text.Encoding.ASCII.GetBytes(text);
            byte[] hashedBytes = md5.ComputeHash(inputBytes);

            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < hashedBytes.Length; i++)
            {
                sb.Append(hashedBytes[i].ToString("X2"));
            }

            return sb.ToString();
        }

        public static int GetAge(DateTime birthdate)
        {
            DateTime currentTime = DateTime.Now;
            TimeSpan diff = currentTime - birthdate;

            DateTime zeroTime = new DateTime(1, 1, 1);
            zeroTime = zeroTime + diff;
            
            try
            {
                zeroTime = zeroTime.AddDays(-1);
            }catch(Exception)
            {
                return 0;
            }

            return zeroTime.Year;
        }
    }
}
