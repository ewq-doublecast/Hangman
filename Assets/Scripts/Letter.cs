using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Button))]
public class Letter : MonoBehaviour
{
    [SerializeField] private Word _word;
    [SerializeField] private char _letter;

    private Button _button;
    private Image _image;

    private void Start()
    {
        _button = GetComponent<Button>();
        _image = GetComponent<Image>();
    }

    public void OnClick()
    {
        _word.TryLetterOpen(_letter);
        _button.enabled = false;
        _image.color = Color.red;
    }
}
