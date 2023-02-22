using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopButton : MonoBehaviour
{
    [SerializeField] private GameObject _shop;

    public void OpenShop()
    {
        _shop.SetActive(true);
    }

    public void CloseShop()
    {
        _shop.SetActive(false);
    }
}
