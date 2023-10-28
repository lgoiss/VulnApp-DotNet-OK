using Dapper;
using brokenaccesscontrol.Models;
using System.Security.Cryptography;
using System.Text;
//using BCrypt.Net;

namespace brokenaccesscontrol.Services;

public static class UtilService
{
    // public static string ReturnMD5(string value){        
    //     var valueBytes = Encoding.UTF8.GetBytes(value);
    //     var hashmd = MD5.Create();
    //     var hash = hashmd.ComputeHash(valueBytes);
    //     return Convert.ToBase64String(hash);
    // }

    public static string EncryptHASH(string password){        
        var hashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        return hashedPassword;
    }

    public static bool DecryptHASH(string password, string hashedPassword ){        
        if (BCrypt.Net.BCrypt.Verify(password, hashedPassword))
        {
            return true;
        }
        else 
        {
            return false;
        }
    }
}
