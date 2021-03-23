using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;

public class FileManager : MonoBehaviour
{
    public static void WriteData(string _filename, Dictionary<string, int> _saveDic)
    {
        string path = PathForDocumentsFile(_filename);
        FileStream f = new FileStream(path, FileMode.Create, FileAccess.Write);

        StreamWriter writer = new StreamWriter(f);

        foreach (KeyValuePair<string, int> items in _saveDic)
            writer.WriteLine(items.Key + "," + items.Value);
        writer.Close();
        f.Close();
    }

    private static string PathForDocumentsFile(string _filename) // 플랫폼의 데이터 저장 경로에 파일이름을 추가해주는 함수
    {
        if (Application.platform == RuntimePlatform.Android) // 안드로이드 플랫폼이면
            return Application.persistentDataPath + "/" + _filename; // persistentDataPath = /storage/emulated/0/Android/data/번들이름/files
        return null;
    }

    public static List<string> ReadData_oldFile(string _filePath)
    {
        FileStream fileStream = new FileStream(_filePath, FileMode.Open, FileAccess.Read);
        StreamReader streamReader = new StreamReader(fileStream);

        string source = "";
        List<string> divList = new List<string>();

        source = streamReader.ReadLine();

        while (source != null)
        {
            divList.Add(source);
            source = streamReader.ReadLine();
        }

        streamReader.Close();
        fileStream.Close();

        return divList;
    }

    public static List<string> ReadFile_TXT(string _filename, string _filepath = "", bool _isTitle = false)
    {
        // LastIndexOf(char) : 뒤에서부터 검색하면서 첫 char 포함 뒤 문자열을 짤라준다.
        // SubString(index1, index2) : index1부터 index2의 직전 텍스트까지만 잘라서 반환한다.
        TextAsset data = Resources.Load<TextAsset>(_filepath + _filename.Substring(0, _filename.LastIndexOf('.')));
        if (data == null)
            return null;
        StringReader stringReader = new StringReader(data.text);

        string source = "";
        List<string> divList = new List<string>();

        source = stringReader.ReadLine();
        if(_isTitle)
            source = stringReader.ReadLine();
        while (source != null)
        {
            divList.Add(source);
            source = stringReader.ReadLine();
        }

        stringReader.Close();

        return divList;
    }

    public static string ReadTextOneLine(string _filename, string _filepath = "")
    {
        // LastIndexOf(char) : 뒤에서부터 검색하면서 첫 char 포함 뒤 문자열을 짤라준다.
        // SubString(index1, index2) : index1부터 index2의 직전 텍스트까지만 잘라서 반환한다.
        TextAsset data = Resources.Load<TextAsset>(_filepath + _filename.Substring(0, _filename.LastIndexOf('.')));
        if (data == null)
            return null;
        StringReader stringReader = new StringReader(data.text);
        
        return stringReader.ReadLine();
    }
}
