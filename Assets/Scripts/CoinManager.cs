using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CoinManager : MonoBehaviour
{
    public Button AdvButton;

    [SerializeField] private GameOverScreen _gameOverScreen;

    [DllImport("__Internal")]

    private static extern void AddCoinsExtern(int value);

    public void ShowAdvButton(int value)
    {
        #if UNITY_WEBGL
                        AddCoinsExtern(value);
        #endif
    }

    public void AddCoins(int value)
    {
        Progress.Instance.PlayerInfo.Money += value;
    }

    public void UpdateScreen()
    {
        AdvButton.gameObject.SetActive(false);
        _gameOverScreen.ShowWinRewardedText("200");
        Progress.Instance.Save();
    }
}
