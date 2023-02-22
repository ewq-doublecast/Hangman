using UnityEngine;
using IJunior.TypedScenes;
using System.Runtime.InteropServices;

public class ThemeButton : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAds();

    [SerializeField] private WordConfig _wordConfig;
    public void LoadGame()
    {
        #if UNITY_WEBGL
                        ShowAds();
        #endif
        Game.Load(_wordConfig);
    }
}
