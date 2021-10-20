using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class MaHoa
    {
        //Hàm mã hóa chuỗi
        public static string EncryptString(string value, string publicKey)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            //B1: Sử dụng MD5
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(publicKey));
            //B2. Tạo đối tượng TripleDESCryptoServiceProvider mới
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            //B3. Cài đặt bộ mã hóa
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            //B4. Convert chuỗi (value) thành dạng byte[]
            byte[] DataToEncrypt = UTF8.GetBytes(value);
            //B5. Bắt đầu mã hóa chuỗi
            try
            {
                ICryptoTransform Encryptor = TDESAlgorithm.CreateEncryptor();
                Results = Encryptor.TransformFinalBlock(DataToEncrypt, 0, DataToEncrypt.Length);
            }
            finally
            {
                //Xóa mọi thông tin về Triple DES và HashProvider để đảm bảo an toàn
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            //B6. Trả về chuỗi đã mã hóa bằng thuật toán Base64
            return Convert.ToBase64String(Results);
        }

        //=========================================

        //Hàm giải mã chuỗi
        public static string DecryptString(string value, string publicKey)
        {
            byte[] Results;
            System.Text.UTF8Encoding UTF8 = new System.Text.UTF8Encoding();
            //B1. Sử dụng MD5
            MD5CryptoServiceProvider HashProvider = new MD5CryptoServiceProvider();
            byte[] TDESKey = HashProvider.ComputeHash(UTF8.GetBytes(publicKey));
            //B2. Tạo đối tượng TripleDESCryptoServiceProvider mới
            TripleDESCryptoServiceProvider TDESAlgorithm = new TripleDESCryptoServiceProvider();
            //B3. Cài đặt cho bộ giải mã
            TDESAlgorithm.Key = TDESKey;
            TDESAlgorithm.Mode = CipherMode.ECB;
            TDESAlgorithm.Padding = PaddingMode.PKCS7;
            //B4. Convert chuỗi (value) thành dạng byte[]
            byte[] DataToDecrypt = Convert.FromBase64String(value);
            //B5. Bắt đầu quá trình giải mã chuỗi
            try
            {
                ICryptoTransform Decryptor = TDESAlgorithm.CreateDecryptor();
                Results = Decryptor.TransformFinalBlock(DataToDecrypt, 0, DataToDecrypt.Length);
            }
            finally
            {
                //Xóa hết thông tin về Triple DES và HashProvider để đảm bảo an toàn
                TDESAlgorithm.Clear();
                HashProvider.Clear();
            }
            //B6. Trả về Kết quả bằng dinh dạng UTF8
            return UTF8.GetString(Results);
        }
    }
}

