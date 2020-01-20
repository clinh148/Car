using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class MyEditor 
{
    
    [MenuItem("Tools/Delete Data")]
    public static void DeleteAllData()
    {
        PlayerPrefs.DeleteAll();
    }

}
