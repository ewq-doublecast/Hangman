using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Balance : MonoBehaviour
{
    [SerializeField] private TMP_Text _balance;

    private void Start()
    {
        _balance.text = Progress.Instance.PlayerInfo.Money.ToString();
    }

    private void OnEnable()
    {
        _balance.text = Progress.Instance.PlayerInfo.Money.ToString();
    }

    public void UpdateData()
    {
        _balance.text = Progress.Instance.PlayerInfo.Money.ToString();
    }
}
