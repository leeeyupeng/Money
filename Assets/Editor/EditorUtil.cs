using UnityEngine;
using UnityEditor;
using System.IO;
using System.Collections;
using System.Collections.Generic;

using System.Text;

public class EditorUtil : EditorWindow {

//-----------------------------------------------
	//
    [MenuItem("Assets/CreateConfig")]
	//加密配置文件
	static void EncryptConfig()
	{
		//string [] files = Directory.GetFiles( dir );
		Object[] selection = Selection.GetFiltered(typeof(Object), SelectionMode.DeepAssets);
//		Debug.Log( selection[0].name );
//		Debug.Log( AssetDatabase.GetAssetPath(selection[0]) );

		//foreach( string file in files) {
		foreach( Object obj in selection)
		{
			string file = AssetDatabase.GetAssetPath(obj);
            string encryptDir = file.Replace("Assets/","Assets/Resources/");
            encryptDir = encryptDir.Replace(".csv",".txt");
            encryptDir = encryptDir.Replace(".json",".txt");
			//加密.txt后缀的文件
            if (Path.GetExtension(file).Equals(".txt") || Path.GetExtension(file).Equals(".csv") || Path.GetExtension(file).Equals(".json"))
			{
				//文件名
				string fileName = Path.GetFileName(file);

				//读取文件中的内容
				StreamReader streamReader = new StreamReader(file,System.Text.Encoding.UTF8);
				string text = streamReader.ReadToEnd();
				streamReader.Close();

				//加密读取的内容
                string encryptString;
                if (FileUtil.isEncrypt)
                    encryptString = FileUtil.Encrypt(text);
                else
                    encryptString = text;

				//写入另一个文件夹中的文件中
				string filePath = encryptDir;
                Debug.Log(filePath);
//                FileUtil.WriteText(filePath, encryptDir);
                if (!Directory.Exists(Path.GetDirectoryName(filePath)))
                {
                    Directory.CreateDirectory(Path.GetDirectoryName(filePath));
                }
                File.WriteAllText(filePath, encryptString,Encoding.UTF8);
			}
		}

		Debug.Log("文件加密完成");
	}
}
