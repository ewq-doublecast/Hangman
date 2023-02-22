using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class CountOpenWordsLabel : MonoBehaviour
{
    [SerializeField] private TMP_Text _text;
    [SerializeField] private WordConfig _wordConfig;
    public void Start()
    {
        _text.text = _wordConfig.GetCorrectIndex() + "/" + _wordConfig.GetCountWords();
    }
}
