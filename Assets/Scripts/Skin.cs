using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Skin : MonoBehaviour
{
    [SerializeField] private string _name;
    [SerializeField] private int _cost;
    [SerializeField] private Sprite _icon;
    [SerializeField] private bool _bought;
    [SerializeField] private bool _selected;
    [SerializeField] private Sprite[] _hangman = new Sprite[8];

    public string Name => _name;
    public int Cost => _cost;
    public Sprite Icon => _icon;
    public bool Bought => _bought;
    public bool Selected => _selected;
    public Sprite[] Hangman => _hangman;

    public void Buy()
    {
        _bought = true;
    }

    public void Select()
    {
        _selected = true;
    }

    public void UnSelect()
    {
        _selected = false;
    }

    public Sprite[] SetSkin()
    {
        return _hangman;
    }
}
