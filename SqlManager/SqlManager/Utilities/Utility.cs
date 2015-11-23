using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Xml;
using SqlManager.Data;

namespace SqlManager.Utilities
{
    public class Utility
    {
        public static string BuildConnectString(int type,string nameServer, string database, string username = null, string password = null)
        {
            string strConnect;
            if (type == 0)
            {
                strConnect = "Data Source=" + nameServer + ";Initial Catalog = " + database + ";Integrated Security=True";
            }
            else
            {
                strConnect = "Data Source=" + nameServer + ";Initial Catalog = " + database + ";Persist Security Info=True;User ID=" + username +
                             ";Password=" + password;
            }
            return strConnect;
        }
        public static string EncryptString(string s, string p)
        {
            byte[] results;
            MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
            byte[] tdesKey = hashProvider.ComputeHash(Encoding.UTF8.GetBytes(p));
            TripleDESCryptoServiceProvider tdesAlgorithm = new TripleDESCryptoServiceProvider
            {
                Key = tdesKey,
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };
            byte[] data = Encoding.UTF8.GetBytes(s);
            try
            {
                ICryptoTransform encryptor = tdesAlgorithm.CreateEncryptor();
                results = encryptor.TransformFinalBlock(data, 0, data.Length);
            }
            finally
            {
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }
            return Convert.ToBase64String(results);
        }
        public static string DecryptString(string s, string p)
        {
            byte[] results;
            MD5CryptoServiceProvider hashProvider = new MD5CryptoServiceProvider();
            byte[] tdesKey = hashProvider.ComputeHash(Encoding.UTF8.GetBytes(p));
            TripleDESCryptoServiceProvider tdesAlgorithm = new TripleDESCryptoServiceProvider();
            tdesAlgorithm.Key = tdesKey;
            tdesAlgorithm.Mode = CipherMode.ECB;
            tdesAlgorithm.Padding = PaddingMode.PKCS7;
            byte[] data = Convert.FromBase64String(s);
            try
            {
                ICryptoTransform decryptor = tdesAlgorithm.CreateDecryptor();
                results = decryptor.TransformFinalBlock(data, 0, data.Length);
            }
            finally
            {
                tdesAlgorithm.Clear();
                hashProvider.Clear();
            }
            return Encoding.UTF8.GetString(results);
        }
        public static void SaveConfig(string nameConnection, string stringConnection)
        {
            if (!File.Exists(Directories.ConfigFilePath))
            {
                var temp = File.Create(Directories.ConfigFilePath);
                temp.Close();
            }
            XmlDocument doc = new XmlDocument();
            doc.Load(Directories.ConfigFilePath);
            XmlNode node = doc.CreateNode(XmlNodeType.Element, "Config", null);
            XmlNode nodeConnectString = doc.CreateElement(nameConnection);
            nodeConnectString.InnerText = stringConnection;
            node.AppendChild(nodeConnectString);
            if (doc.DocumentElement != null) doc.DocumentElement.AppendChild(node);
            doc.Save(Directories.ConfigFilePath);
        }
    }
}
