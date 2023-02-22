using UnityEngine;
using IJunior.TypedScenes;
using System.Runtime.InteropServices;

public class MenuButton : MonoBehaviour
{
    [DllImport("__Internal")]
    private static extern void ShowAds();

    public void LoadMenu()
    {
        #if UNITY_WEBGL
                                ShowAds();
        #endif
        Menu.Load();
    }
}
