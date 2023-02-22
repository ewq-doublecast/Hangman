using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[System.Serializable]
public class PlayerInfo
{
    public List<WordConfig> WordConfigs;
    public int Money;
    public Skin Skin;
    public List<Skin> Skins;
    public int CountOpenWords;

    public int SumOpenWords()
    {
        for (int i = 0; i < WordConfigs.Count; i++)
        {
            CountOpenWords += WordConfigs[i].GetCorrectIndex();
        }

        return CountOpenWords;
    }
}
public class Progress : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void SaveExtern(string date);

    [DllImport("__Internal")]
    private static extern void LoadExtern();

    public PlayerInfo PlayerInfo;

    public static Progress Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
#if UNITY_WEBGL
                LoadExtern();
#endif
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void Save()
    {
        string jsonString = JsonUtility.ToJson(PlayerInfo);
#if UNITY_WEBGL
                SaveExtern(jsonString);
#endif
    }

    public void SetPlayerInfo(string value)
    {
        PlayerInfo = JsonUtility.FromJson<PlayerInfo>(value);
    }
}
