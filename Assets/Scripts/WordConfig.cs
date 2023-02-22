using UnityEngine;

[CreateAssetMenu(fileName = "NewWords", menuName = "Create New Array Words")]
public class WordConfig : ScriptableObject
{
    [SerializeField] private string[] _words;
    [SerializeField] private string _label;

    private int _correctIndex;

    public void IncreaseCorrectIndex()
    {
        _correctIndex++;
    }

    public int GetCorrectIndex()
    {
        return _correctIndex;
    }

    public int GetCountWords()
    {
        return _words.Length;
    }

    public string GetCorrectWord()
    {
        return _words[_correctIndex];
    }

    public bool CheckAllWordsComposed()
    {
        if (_correctIndex == _words.Length - 1)
            return true;
        return false;
    }

    public string GetLabel()
    {
        return _label;
    }
}
