using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shop : MonoBehaviour
{
    [SerializeField] private SkinView _template;
    [SerializeField] private GameObject _itemContainer;
    [SerializeField] private Balance _balance;
    [SerializeField] private List<Skin> _skins; 
    private void Start()
    {
        if (Progress.Instance.PlayerInfo.Skins.Count > 0)
        {
            _skins = Progress.Instance.PlayerInfo.Skins;
        }

        for (int i = 0; i < _skins.Count; i++)
        {
            AddItem(_skins[i]);
        }

        if (Progress.Instance.PlayerInfo.Skins.Count == 0)
        {
            Progress.Instance.PlayerInfo.Skins = _skins;
        }
    }

    private void AddItem(Skin skin)
    {
        var view = Instantiate(_template, _itemContainer.transform);
        view.SellButtonClick += OnSellButtonClick;

        view.Render(skin);
    }

    private void OnSellButtonClick(Skin skin, SkinView view)
    {
        TrySellSkin(skin, view);
    }

    private void TrySellSkin(Skin skin, SkinView view)
    {
        if (skin.Cost <= Progress.Instance.PlayerInfo.Money)
        {
            Progress.Instance.PlayerInfo.Money -= skin.Cost;
            skin.Buy();
            _balance.UpdateData();
            view.SellButtonClick -= OnSellButtonClick;
        }
    }
}
