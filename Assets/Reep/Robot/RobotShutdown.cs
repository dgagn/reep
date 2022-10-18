using UnityEngine;

namespace Reep.Robot
{
  public class RobotShutdown : MonoBehaviour
  {
    private Animator _animator;
    private static readonly int Shutdown = Animator.StringToHash("Shutdown");

    private AudioSource _shutdown;
    private AudioSource _talk;

    private GameObject _player;

    private bool _isDead = false;

    private void Awake()
    {
      _animator = GetComponent<Animator>();
      var components = GetComponents<AudioSource>();
      _player = GameObject.FindWithTag("Player");
      _shutdown = components[0];
      _talk = components[1];
    }
    
    private void OnCollisionEnter(Collision collision)
    {
      var bulletTagged = collision.transform.CompareTag("Bullet");
      if (!bulletTagged)
        return;
      if (!_isDead) _player.GetComponent<Cash>().GiveCash(10);
      _shutdown.Play();
      _talk.Stop();
      _animator.SetTrigger(Shutdown);
      _isDead = true;
    }
  }
}
