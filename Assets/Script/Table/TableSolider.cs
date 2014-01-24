using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TableSolider : TableBase
{
    static Hashtable m_solider = null;
    public static DataBase.Solider Solider(int id)
    {
        if (m_solider == null)
            m_solider = GetSoliderInfo();
        return m_solider[id] as DataBase.Solider;
    }
    static Hashtable GetSoliderInfo()
	{
		//分隔符
        string readTextName = "solider.csv";
        string text = FileUtil.ReadText (readTextName);
		string[] lines = text.Replace ("\r", "").Split ('\n');
		int cnt = lines.Length;

		//索引,名字对应的列
		Dictionary<string, int> name_col = new Dictionary<string, int> ();
        string[] firstRow = lines [0].Split (Static.sepChar);
		int count = firstRow.Length;

		for (int i = 0; i < count; i++) {
			name_col.Add (firstRow [i], i);
		}

        Hashtable list1 = new Hashtable ();
		int col = 0;
		//处理每一行
		for (int i = 1; i < cnt; i++) 
        {
            string[] words = lines [i].Split (Static.sepChar);

			//填补空缺
			for (int j = 0; j < words.Length; j++) {   
				if (words [j] == null || words [j] == string.Empty || words [j] == "")
					words [j] = "0";
			}

			if (words.Length == count) 
            {
                DataBase.Solider solider = new DataBase.Solider();
                col = name_col["id"];
                solider.id = int.Parse(words[col]);
                col = name_col["name"];
                solider.name = words[col];
				col = name_col["health"];
                solider.health = int.Parse( words[col] );
                col = name_col["attack"];
                solider.attack = int.Parse( words[col] );
                col = name_col["defense"];
                solider.defense = int.Parse( words[col] );

                list1.Add(solider.id,solider);
			}
		}
        return list1;
	}
}
