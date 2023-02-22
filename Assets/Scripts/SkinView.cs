using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class SkinView : MonoBehaviour
{
    [SerializeField] private TMP_Text _label;
    [SerializeField] private TMP_Text _price;
    [SerializeField] private Image _icon;
    [SerializeField] private Button _sellButton;
    [SerializeField] private Button _selectButton;

    private Skin _skin;

    public event UnityAction<Skin, SkinView> SellButtonClick;
    public event UnityAction<Skin, SkinView> SelectButtonClick;

    private void OnEnable()
    {
        _sellButton.onClick.AddListener(OnSellButtonClick);
        _sellButton.onClick.AddListener(TryLockItem);
        _selectButton.onClick.AddListener(OnSelectButtonClick);
        _selectButton.onClick.AddListener(TrySelectSkin);
    }

    private void Update()
    {
        if (_skin.Selected)
            _selectButton.interactable = false;
        else
            _selectButton.interactable = true;

        if (_skin.Bought)
            _sellButton.interactable = false;
        else
            _sellButton.interactable = true;
    }

    private void OnDisable()
    {
        _sellButton.onClick.RemoveListener(TryLockItem);
        _selectButton.onClick.RemoveListener(TrySelectSkin);
    }

    private void TryLockItem()
    {
        if (_skin.Bought)
        {
            _sellButton.interactable = false;
        }
    }

    private void TrySelectSkin()
    {
        if (_skin.Bought)
        {
            if (Progress.Instance.PlayerInfo.Skin != null)
                Progress.Instance.PlayerInfo.Skin.UnSelect();
            _skin.Select();
            Progress.Instance.PlayerInfo.Skin = _skin;
        }
    }

    public void Render(Skin skin)
    {
        _skin = skin;

        _label.text = _skin.Name;
        _price.text = _skin.Cost.ToString();
        _icon.sprite = _skin.Icon;

    }

    private void OnSellButtonClick()
    {
        SellButtonClick?.Invoke(_skin, this);
    }

    private void OnSelectButtonClick()
    {
        SelectButtonClick?.Invoke(_skin, this);
    }
}
