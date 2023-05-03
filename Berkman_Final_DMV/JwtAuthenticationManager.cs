using Berkman_Final_DMV.Controllers;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Berkman_Final_DMV
{
    public class JwtAuthenticationManager
    {
        private readonly string key;

        public List<Dictionary<String, String>> users()
        {

            List<Dictionary<String, String>> users = new List<Dictionary<string, string>>();
            SqlConnection conn = new SqlConnection("Data Source=DARBI-LAPTOP;Initial Catalog=DMV;User ID=sa;Password=********;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False;Trusted_Connection=True");
            SqlCommand query = new SqlCommand("SELECT PersonnelTitle, PersonnelUsername, PersonnelPassword FROM Personnel", conn);

            try
            {
                conn.Open();
                SqlDataReader result = query.ExecuteReader();

                while (result.Read())
                {
                    Dictionary<String, String> user = new Dictionary<String, String>();
                    user["PersonnelTitle"] = result.GetString(0);
                    user["PersonnelUsername"] = result.GetString(1);
                    user["PersonnelPassword"] = result.GetString(2);

                    users.Add(user);

                    
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return users;

        }



        public JwtAuthenticationManager(string Key)
        {
            this.key = Key;
        }

        private readonly IDictionary<string, string> _validTokens = new Dictionary<string, string>();
        public void RemoveAuthentication(string token)
        {
            var username = _validTokens.FirstOrDefault(x => x.Value == token).Key;
            if (username != null)
            {
                _validTokens.Remove(username);
            }
        }

        public string Authenticate(string username, string password)
        {
            var user = users().FirstOrDefault(u => u["PersonnelUsername"] == username && u["PersonnelPassword"] == password);
            if (user == null)
            {
                return null;
            }

            var title = user["PersonnelTitle"];

            JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
            var tokenKey = Encoding.ASCII.GetBytes(key);

            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
            new Claim(ClaimTypes.Name, username),
            new Claim(ClaimTypes.Role, title)
                }),

                Expires = DateTime.UtcNow.AddMinutes(60),
                SigningCredentials = new SigningCredentials(
                    new SymmetricSecurityKey(tokenKey),
                    SecurityAlgorithms.HmacSha256Signature)
            };

            var token = handler.CreateToken(tokenDescriptor);

            return handler.WriteToken(token);
        }

    }

}
