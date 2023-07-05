using System.Security.Cryptography;
using System.Text;

namespace DataProtectInServer.Security
{
    /* xml veya json gibi konfigürasyon dosyalarını veya doğrudan kritik bilgileri, sunucu üzerinde kriptolayarak (encrypted) saklayabilirsiniz*/
    public class DataProtector
    {
        private string path;
        private byte[] entrophy;

        public DataProtector(string path)
        {
            this.path = path;
            entrophy = new byte[16];
            entrophy = RandomNumberGenerator.GetBytes(16);
        }

        //1. Bir girdiyi (ifade) şifeleyerek koru:
        public int EncryptedData(string secretData)
        {
            var encoded = Encoding.UTF8.GetBytes(secretData);
            FileStream fileStream = new FileStream(path, FileMode.OpenOrCreate);
            int length = encryptDataToFile(encoded, entrophy, DataProtectionScope.CurrentUser, fileStream);
            fileStream.Close();
            return length;
        }

        private int encryptDataToFile(byte[] encoded, byte[] entrophy, DataProtectionScope currentUser, FileStream fileStream)
        {
            byte[] encrypted = ProtectedData.Protect(encoded, entrophy, currentUser);
            int outputLength = 0;
            if (fileStream.CanWrite && encrypted != null)
            {
                fileStream.Write(encrypted, 0, encrypted.Length);
                outputLength = encrypted.Length;
            }

            return outputLength;

        }

        public string DecryptData(int length)
        {
            FileStream fileStream = new FileStream(path, FileMode.Open);
            byte[] decrypt = decryptDataFromFile(fileStream, entrophy, DataProtectionScope.CurrentUser, length);
            fileStream.Close();
            return Encoding.UTF8.GetString(decrypt);
        }

        private byte[] decryptDataFromFile(FileStream fileStream, byte[] entrophy, DataProtectionScope currentUser, int length)
        {
            byte[] inputBuffer = new byte[length];
            byte[] outputBuffer = new byte[length];
            if (fileStream.CanRead)
            {
                fileStream.Read(inputBuffer, 0, inputBuffer.Length);
                outputBuffer = ProtectedData.Unprotect(inputBuffer, entrophy, currentUser);
            }

            return outputBuffer;


        }
    }
}
