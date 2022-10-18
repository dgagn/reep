using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using AuroraFPSRuntime.AIModules;
using AuroraFPSRuntime.SystemModules.HealthModules;
using UnityEngine;
using Random = UnityEngine.Random;

public class DeathWish : MonoBehaviour
{
    private Animator _animator;
    private static readonly int IsAttacking = Animator.StringToHash("IsAttacking");
    private GameObject _player;
    private BoxCollider[] _colliders;
    private bool _isDead;
    public GameObject ammunition;
    
    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _player = GameObject.FindWithTag("Player");
        _colliders = GetComponents<BoxCollider>();

        StartCoroutine(Damage());
    }

    public void DestroyZombie()
    {
        foreach (var boxCollider in _colliders) boxCollider.enabled = false;
        _isDead = true;
        Instantiate(ammunition, gameObject.transform.position, Quaternion.identity);
        Destroy(gameObject, 2f);
        _player.GetComponent<Cash>().GiveCash(50);
    }

    public void HeadShot(Single single, DamageInfo info)
    {
        if (!(info.point.y > 1.7)) return;
        _player.GetComponent<Cash>().GiveCash(100);
        var hp = GetComponent<AICharacterHealth>();
        hp.TakeDamage(30, new DamageInfo());
    }

    private IEnumerator Damage()
    {
        for (;;) {
            if (Vector3.Distance(gameObject.transform.position,
                    _player.transform.position) <= 1.25 && !_isDead) {
                SetAttackAnimation();
                var hp = _player.GetComponent<CharacterHealth>();
                hp.TakeDamage(40, new DamageInfo());
            }
            else
                SetUnAttackAnimation();

            yield return new WaitForSeconds(1f);
        }
    }
    
    private void SetAttackAnimation() => _animator.SetBool(IsAttacking, true);

    private void SetUnAttackAnimation() => _animator.SetBool(IsAttacking, false);
}
