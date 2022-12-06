using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;
using System;

public class SaveToTxt : MonoBehaviour
{

    internal static void preveriCeObstajaTXTdatoteka() {
        if (!System.IO.File.Exists(Application.persistentDataPath + "myfile.txt"))
        {
            string datoteka = Application.persistentDataPath + "myfile.txt";
            File.WriteAllText(datoteka, "Seznam");
        }
    }

    internal static void WriteString(string zapis)
    {
        string path = Application.persistentDataPath +"/test.txt";

        StreamWriter writer = new StreamWriter(path, true);

        writer.WriteLine(zapis);

        writer.Close();
    }

    internal static String ReadString()

    {

        string path = Application.persistentDataPath +"/test.txt";

        //Read the text from directly from the test.txt file

        StreamReader reader = new StreamReader(path);

        String celText=reader.ReadToEnd();

        reader.Close();
        Debug.Log(celText);
        return celText;

    }
    internal static void replacePart(string newPart, string oldPart)

    {

        string path = Application.persistentDataPath + "/test.txt";


        //StreamReader reader = new StreamReader(path);

        string[] celText = File.ReadAllLines(path);
        for (int i = 0; i < celText.Length; i++) {
            Debug.Log("old part " + oldPart + " cel string[i] " + celText[i]);
            if (celText[i].Contains(oldPart)) {               
                celText[i] = newPart; 
            }
        }
        File.WriteAllLines(path, celText);
        //reader.Close();

    }
    internal static string[] stringByRows()

    {

        string path = Application.persistentDataPath + "/test.txt";
        string[] celText = File.ReadAllLines(path);
        //reader.Close();
        return celText;

    }
    internal static void emptyTXT() {
        string path = Application.persistentDataPath + "/test.txt";
        string[] celText = new string[1];
        celText[0] = "";
        File.WriteAllLines(path, celText);
    }
    internal static string emso() {
        string path = Application.persistentDataPath + "/test.txt";
        string[] celText = File.ReadAllLines(path);
        return celText[celText.Length-1];
    }
}
