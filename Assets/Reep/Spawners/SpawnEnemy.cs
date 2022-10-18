using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;

public class SpawnEnemy : MonoBehaviour
{
    private Spawner[] _spawners;
    public TextMeshProUGUI textMeshPro;

    private void Awake()
    {
        _spawners = GetComponentsInChildren<Spawner>();
    }

    private void Start()
    {
        StartCoroutine(WaveManager(1));
    }

    private IEnumerator WaveManager(int wave)
    {
        for (;;) {
            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (enemies.Length == 0) {
                break;
            }
            yield return new WaitForSeconds(1f);
        }

        textMeshPro.SetText(wave.ToString());
        yield return new WaitForSeconds(10f);
        Wave(wave);
        StartCoroutine(WaveManager(wave + 1));
    }

    private void Wave(int wave)
    {
        var noEnnemies = Math.Clamp(wave * 3, 3, 24);
        
        for (var i = 0; i < noEnnemies; i++) {
            _spawners[Random.Range(0, _spawners.Length)].CreateZombie(wave);
        }
    }
}
