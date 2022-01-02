using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBar : MonoBehaviour
{
    [SerializeField] private PlayerMoney _player;
    [SerializeField] private TMP_Text _moneyUI;

    private void Start()
    {
        _moneyUI.text = _player.CountMoney.ToString();
        _player.OnRecive += UpdateBar;
    }

    /*private void OnEnable()
    {
        _player.OnRecive -= UpdateBar;
    }*/

    private void UpdateBar()
    {
        _moneyUI.text = _player.CountMoney.ToString();
    }
}
