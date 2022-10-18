  using System;
  using System.Collections;
  using UnityEngine;
  using UnityEngine.AI;
  using UnityEngine.Rendering.PostProcessing;

  public class Spawner : MonoBehaviour
  {
    public GameObject zombie;
    private bool _isSpawnerScare;

    private void OnDrawGizmos()
    {
      Gizmos.color = Color.green;
      Gizmos.DrawCube(transform.position, new Vector3(1, 1, 1));
    }

    public void CreateZombie(int wave)
    {
      var agent = zombie.GetComponent<NavMeshAgent>();
      agent.speed = Math.Clamp((wave - 1) * 0.1f + 1f, 1, 3);
      Instantiate(zombie, gameObject.transform.position, Quaternion.identity);
    }

    private IEnumerator DisableProcessing()
    {
      yield return new WaitForSeconds(3);
      var volume = GameObject.FindWithTag("PostProcessing").GetComponent<PostProcessVolume>();
      volume.profile.TryGetSettings(out LensDistortion distortion);
      distortion.active = false;
      volume.profile.TryGetSettings(out ChromaticAberration aberration);
      aberration.active = false;
    }

    private void OnTriggerEnter(Collider other)
    {
      if (!_isSpawnerScare) {
        GetComponent<AudioSource>().Play();
        var volume = GameObject.FindWithTag("PostProcessing").GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out LensDistortion distortion);
        distortion.active = true;
        volume.profile.TryGetSettings(out ChromaticAberration aberration);
        aberration.active = true;
        StartCoroutine(DisableProcessing());
      }
      _isSpawnerScare = true;
    }
  }
