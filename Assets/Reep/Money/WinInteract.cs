using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinInteract : MonoBehaviour
{
  public TextMeshProUGUI text;
  private bool _inCollision;
  private Cash _player;
  public TextMeshProUGUI winText;
  private bool _won;
  public Image image;

  private void Awake()
  {
    _player = GameObject.FindWithTag("Player").GetComponent<Cash>();
  }

  private void OnTriggerEnter(Collider other)
  {
    if (!other.CompareTag("Player") || _won) return;
    text.enabled = true;
    _inCollision = true;
  }

  private void Update()
  {
    if (!_inCollision || !Input.GetKeyDown(KeyCode.F) ||
        _player.cash < 20_000) return;
    _player.TakeCash(20000);
    StartCoroutine(Won());
  }

  private IEnumerator Won()
  {
    GetComponent<AudioSource>().Play();
    image.enabled = true;
    _won = true;
    text.enabled = false;
    winText.enabled = true;
    yield return new WaitForSeconds(10);
    GameManager.Restart();
  }

  private void OnTriggerExit(Collider other)
  {
    if (!other.CompareTag("Player")) return;
    text.enabled = false;
    _inCollision = false;
  }
}
