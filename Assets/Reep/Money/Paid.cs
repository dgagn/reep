using System;
using System.Collections;
using System.Collections.Generic;
using AuroraFPSRuntime.SystemModules;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class Paid : MonoBehaviour
{
    private GameObject _player;
    private Cash _playerCash;
    private LootWeapon _loot;

    public int amount = 1;

    public Text text;

    private void Awake()
    {
        _player = GameObject.FindWithTag("Player");
        _playerCash = _player.GetComponent<Cash>();
        _loot = GetComponent<LootWeapon>();
        text.text = $"{amount:C0}";
    }

    private void Update()
    {
        _loot.Interactable(CanPay());
    }

    public bool CanPay()
    {
        return _playerCash.cash >= amount;
    }

    public void Pay()
    {
        _player.GetComponent<Cash>().TakeCash(amount);
    }
}
