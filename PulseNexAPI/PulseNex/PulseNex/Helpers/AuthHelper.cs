using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using PulseNex.Main;
using PulseNex.Model;
using System.Buffers.Text;
using System.Collections;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using static System.Net.Mime.MediaTypeNames;

namespace PulseNex.Helpers
{
    public class AuthHelper
    {
        public AuthHelper()
        {

        }

        public static bool CheckIfUserAlreadyExists()
        {
            var loginDataFromFile = JsonConvert.DeserializeObject<LoginDataModel>(File.ReadAllText(CommonHelper.GetLoginDataFileLocation()));

            if(loginDataFromFile.Username == "" || loginDataFromFile.Salt == "" || loginDataFromFile.Key == "")
            {
                return false;
            }
            else
            {
                return true;
            }
        }

        public static bool LoginUser(LoginModel model)
        {
            try
            {
                var loginDataFromFile = JsonConvert.DeserializeObject<LoginDataModel>(File.ReadAllText(CommonHelper.GetLoginDataFileLocation()));

                using (var deriveBytes = new Rfc2898DeriveBytes(model.Password, Convert.FromBase64String(loginDataFromFile.Salt)))
                {
                    byte[] newKey = deriveBytes.GetBytes(20);

                    if (!newKey.SequenceEqual(Convert.FromBase64String(loginDataFromFile.Key)))
                        return false;
                    else
                        return true;
                }
            }
            catch 
            {
                return false;
            }
        }

        public static bool RegisterUser(LoginModel model)
        {
            try
            {
                using (var deriveBytes = new Rfc2898DeriveBytes(model.Password, 20))
                {
                    byte[] salt = deriveBytes.Salt;
                    byte[] key = deriveBytes.GetBytes(20);

                    var LoginData = new LoginDataModel()
                    {
                        Username = model.Username,
                        Key = Convert.ToBase64String(key),
                        Salt = Convert.ToBase64String(salt),
                    };

                    var LoginDataString = JsonConvert.SerializeObject(LoginData);
                    File.WriteAllText(CommonHelper.GetLoginDataFileLocation(), LoginDataString);
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public static string CreateJWTToken(LoginModel model)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(MainClass.GetAppSettingsData().Jwt.Secret));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new[]
            {
                new Claim(ClaimTypes.Name,model.Username),
            };

            var token = new JwtSecurityToken(MainClass.GetAppSettingsData().Jwt.ValidIssuer,
                MainClass.GetAppSettingsData().Jwt.ValidAudience,
                claims,
                expires: DateTime.Now.AddMinutes(15),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
