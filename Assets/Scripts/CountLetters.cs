using IJunior.TypedScenes;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountLetters : MonoBehaviour
{
    [SerializeField] private Word _word;

    private TMP_Text _countLettersLabel;
    private void Start()
    {
        _countLettersLabel = GetComponent<TMP_Text>();
        _countLettersLabel.text = "йнк-бн асйб: " + _word.GetCountLettersInWord();
    }
}
