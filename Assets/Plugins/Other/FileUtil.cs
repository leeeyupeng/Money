using System;
using System.Collections;

using System.IO;
using System.Security.Cryptography;
using System.Text;

using UnityEngine;

public class FileUtil 
{
    public static bool isEncrypt = false; 
    public static string ReadText(string fileName)
    {
        string filePath = System.IO.Path.Combine(Application.persistentDataPath, fileName);
        if ( File.Exists(filePath) )
        {
            return ReadFromFile( filePath );
        }
        return ReadTextResources(fileName);
    }
    static string ReadTextResources(string fileName)
    {
        string filePath = "ConfigData/" + fileName;
        filePath = (filePath.Split('.'))[0];
        Debug.Log(filePath);
        TextAsset textAsset = (TextAsset)Resources.Load(filePath, typeof(TextAsset));

        if (textAsset == null)
        {
            Debug.LogError("Null");
            return null;
        }

        return textAsset.text;
    }
    // 从文件中读取信息
    static string ReadFromFile(string filePath)
    {
        StreamReader streamReader = new StreamReader(filePath,System.Text.Encoding.UTF8);
        string text = streamReader.ReadToEnd();
        streamReader.Close();

        if (FileUtil.isEncrypt)
        {
//            text = text.Replace("\n", "");
//            text = text.Substring(1, text.Length - 1);
            text = FileUtil.Decrypt( text ); //解密
        }

        return text;
    }
	//向文件fileName中写入信息s
	public static void WriteText( string fileName, string s)
	{
        if (FileUtil.isEncrypt)
        {
            s = FileUtil.Encrypt(s);
        }
		string filePath = System.IO.Path.Combine(Application.persistentDataPath, fileName);
        Debug.Log(Path.GetDirectoryName(filePath));
        if (!Directory.Exists(Path.GetDirectoryName(filePath)))
        {
            Directory.CreateDirectory(Path.GetDirectoryName(filePath));
        }
		File.WriteAllText(filePath, s, Encoding.UTF8);
	}

    //--------------------------------------------------------------------------------------------------------------
    private static string sKey = "Money";
    private static string sIV = "esnefeDe";
    //解密
    public static string Decrypt(string pToDecrypt)
    {
        if ( string.IsNullOrEmpty(pToDecrypt) )
        {
            return null;
        }
        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        {

            byte[] inputByteArray = new byte[pToDecrypt.Length / 2];
            //反转
            for (int x = 0; x < pToDecrypt.Length / 2; x++)
            {
                int i = (Convert.ToInt32(pToDecrypt.Substring(x * 2, 2), 16));
                inputByteArray[x] = (byte)i;
            }
            //设定加密金钥(转为Byte)
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            //设定初始化向量(转为Byte)
            des.IV = ASCIIEncoding.ASCII.GetBytes(sIV);
            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateDecryptor(), CryptoStreamMode.Write))
                {
                    //异常处理
                    try
                    {
                        cs.Write(inputByteArray, 0, inputByteArray.Length);
                        cs.FlushFinalBlock();
                        //输出
                        return System.Text.Encoding.Default.GetString(ms.ToArray());
                    }
                    catch (CryptographicException)
                    {
                        //若金钥或向量错误
                        return "0";
                    }
                }
            }
        }
    }

    //加密
    public static string Encrypt(string pToEncrypt)
    {
        StringBuilder ret = new StringBuilder();
        using (DESCryptoServiceProvider des = new DESCryptoServiceProvider())
        {
            //将字元转换为Byte
            byte[] inputByteArray = Encoding.Default.GetBytes(pToEncrypt);
            //设定加密金钥(转为Byte)
            des.Key = ASCIIEncoding.ASCII.GetBytes(sKey);
            //设定初始化向量(转为Byte)
            des.IV = ASCIIEncoding.ASCII.GetBytes(sIV);

            using (MemoryStream ms = new MemoryStream())
            {
                using (CryptoStream cs = new CryptoStream(ms, des.CreateEncryptor(), CryptoStreamMode.Write))
                {
                    cs.Write(inputByteArray, 0, inputByteArray.Length);
                    cs.FlushFinalBlock();
                }
                //输出
                foreach (byte b in ms.ToArray())
                    ret.AppendFormat("{0:X2}", b);
            }
        }
        //传回
        return ret.ToString();
    }
    //--------------------------------------------------------------------------------------------------------------
}
