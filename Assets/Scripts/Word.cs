using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using IJunior.TypedScenes;
using System.Runtime.InteropServices;

[RequireComponent(typeof(TMP_Text))]
public class Word : MonoBehaviour, ISceneLoadHandler<WordConfig>
{
    [DllImport("__Internal")]

    private static extern void SetToLeaderboard(int value);

    [SerializeField] private Hangman _hangman;
    [SerializeField] private GameOverScreen _gameOverScreen;

    private string _correctWord;
    private string _closeWord;
    private TMP_Text _wordLabel;
    private WordConfig _wordConfig;

    public event UnityAction WordComposed;
    public void OnSceneLoaded(WordConfig wordConfig)
    {
        _wordConfig = wordConfig;
        _correctWord = wordConfig.GetCorrectWord();
    }
    private void Start()
    {  
        _wordLabel = GetComponent<TMP_Text>();
        
        for (int i = 0; i < _correctWord.Length; i++)
        {
            _closeWord += "_";
        }

        _wordLabel.text = _closeWord;
    }

    public void TryLetterOpen(char letter)
    {
        StringBuilder stringBuilder = new StringBuilder(_closeWord);

        bool IsFound = false;

        for (int i = 0; i < _correctWord.Length; i++)
        {
            if (letter == _correctWord[i])
            {
                stringBuilder[i] = letter;
                IsFound = true;
            }
        }

        if (!IsFound)
        {
            _hangman.DrawPart();
        }

        _closeWord = stringBuilder.ToString();
        _wordLabel.text = stringBuilder.ToString();

        TryGuessWord();
    }

    public void TryGuessWord()
    {
        if (_closeWord == _correctWord)
        {
            WordComposed?.Invoke();
            _wordConfig.IncreaseCorrectIndex();

            #if UNITY_WEBGL
                                        SetToLeaderboard(Progress.Instance.PlayerInfo.SumOpenWords());
            #endif

            if (_wordConfig.CheckAllWordsComposed())
            {
                _gameOverScreen.ShowAllWordComposedLabel();
            }

            Progress.Instance.PlayerInfo.Money += 100;
            Progress.Instance.Save();
        }
    }

    public void Restart()
    {
        Game.Load(_wordConfig);
    }

    public int GetCountLettersInWord()
    {
        return _correctWord.Length;
    }
}
