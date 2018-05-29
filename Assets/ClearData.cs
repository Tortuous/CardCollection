using UnityEditor;
using UnityEngine;

public class ClearData : MonoBehaviour {
    [MenuItem("Utils/Delete All PlayerPrefs")]
    static public void DeleteAllPlayerPrefs()
    {
        PlayerPrefs.DeleteAll();
    }
}