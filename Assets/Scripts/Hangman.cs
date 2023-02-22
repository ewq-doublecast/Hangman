using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Hangman : MonoBehaviour
{
    [SerializeField] private Image[] _hangman = new Image[8];

    const int GALLOWSPARTS = 8;
    private int _index = 0;

    public event UnityAction HangmanComposed;
    private void Start()
    {
        if (Progress.Instance.PlayerInfo.Skin != null)
        {
            for (int i = 0; i < GALLOWSPARTS; i++)
            {
                _hangman[i].sprite = Progress.Instance.PlayerInfo.Skin.SetSkin()[i];
            }
        }

        for (int i = 0; i < GALLOWSPARTS; i++)
        {
            _hangman[i].enabled = false;
        }
    }
    public void DrawPart()
    {
        if (_index < GALLOWSPARTS)
        {
            _hangman[_index].enabled = true;
        }

        _index++;

        if (_hangman[GALLOWSPARTS - 1].enabled)
        {
            HangmanComposed?.Invoke();
        }
    }
}
