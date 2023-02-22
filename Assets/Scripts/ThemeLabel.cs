using UnityEngine;
using IJunior.TypedScenes;
using TMPro;

public class ThemeLabel : MonoBehaviour, ISceneLoadHandler<WordConfig>
{
    private TMP_Text _themeLabel;
    private string _label;
    public void OnSceneLoaded(WordConfig wordConfig)
    {
        _label = wordConfig.GetLabel();
    }
    private void Start()
    {
        _themeLabel = GetComponent<TMP_Text>();
        _themeLabel.text = "релю: " + _label;
    }
}
