using UnityEngine;
using UnityEngine.UI;
using IJunior.TypedScenes;
using System.Runtime.InteropServices;
using TMPro;

public class GameOverScreen : MonoBehaviour
{
    [SerializeField] private Word _word;
    [SerializeField] private Hangman _hangman;
    [SerializeField] private GameObject _panel;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _exitButton;
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _rewardedText;
    [SerializeField] private CoinManager _coinManager;

    [DllImport("__Internal")]
    private static extern void ShowAds();

    [DllImport("__Internal")]
    private static extern void RateGame();

    private void OnEnable()
    {
        _word.WordComposed += OpenWinGameOverScreen;
        _hangman.HangmanComposed += OpenLoseGameOverScreen;
        _restartButton.onClick.AddListener(OnRestartButtonClick);
        _exitButton.onClick.AddListener(OnExitButtonClick);
    }

    private void OnDisable()
    {
        _word.WordComposed -= OpenWinGameOverScreen;
        _hangman.HangmanComposed -= OpenLoseGameOverScreen;
        _restartButton.onClick.RemoveListener(OnRestartButtonClick);
        _exitButton.onClick.RemoveListener(OnExitButtonClick);
    }

    private void OpenWinGameOverScreen()
    {
        _panel.SetActive(true);
        ShowWinLabel();
        ShowWinRewardedText("+100");
        _coinManager.AdvButton.gameObject.SetActive(true);
    }

    public void ShowWinLabel()
    {
        _label.text = "¬€ ”√¿ƒ¿À»";
    }

    public void ShowWinRewardedText(string rewardedText)
    {
        _rewardedText.text = rewardedText;
    }

    private void OpenLoseGameOverScreen()
    {
        _panel.SetActive(true);
        ShowLoseLabel();
        ShowLoseRewardedText();
        _coinManager.AdvButton.gameObject.SetActive(false);
    }
    public void ShowLoseLabel()
    {
        _label.text = "¬€ Õ≈ ”√¿ƒ¿À»";
    }

    public void ShowLoseRewardedText()
    {
        _rewardedText.text = "+0";
    }

    private void OnRestartButtonClick()
    {
#if UNITY_WEBGL
                ShowAds();
#endif
        _word.Restart();
    }

    private void OnExitButtonClick()
    {
#if UNITY_WEBGL
                ShowAds();
#endif
        Menu.Load();
    }

    public void ShowAllWordComposedLabel()
    {
        _restartButton.gameObject.SetActive(false);
        _label.text = "¬€ ”√¿ƒ¿À» ¬—≈ —ÀŒ¬¿";
    }

    public void OnRateGameButtonClick()
    {
#if UNITY_WEBGL
                RateGame();
#endif
    }
}
