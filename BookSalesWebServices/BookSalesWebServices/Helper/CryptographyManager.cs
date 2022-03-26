using System.Security.Cryptography;
using System.Text;

namespace BookSalesWebServices.Helper
{
    public static class CryptographyManager
    {
        public static string MD5Encryp(string value)
        {
            string encryptedValue;

            using (MD5 md5Hash = MD5.Create())
            {
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(value));
                StringBuilder sBuilder = new StringBuilder();
                for (int i = 0; i < data.Length; i++)
                {
                    sBuilder.Append(data[i].ToString("x2"));
                }
                encryptedValue = sBuilder.ToString();
            }
            return encryptedValue;
        }


    }
}
