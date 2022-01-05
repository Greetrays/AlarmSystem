using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBar : MonoBehaviour
{
    [SerializeField] private PlayerMoney _player;
    [SerializeField] private TMP_Text _moneyUI;

    private void OnEnable()
    {
        _moneyUI.text = _player.CountMoney.ToString();
        _player.Recive += UpdateBar;
    }

    private void OnDisable()
    {
        _player.Recive -= UpdateBar;
    }

    private void UpdateBar()
    {
        _moneyUI.text = _player.CountMoney.ToString();
    }
}
