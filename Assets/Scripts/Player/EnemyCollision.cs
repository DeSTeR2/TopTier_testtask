using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [SerializeField] private ParticleSystem _deathPartical;
    [SerializeField] private AudioClip _deathSound;
    private AudioSource _source;

    // Start is called before the first frame update
    void Start()
    {
        _source = GetComponent<AudioSource>();
        _deathPartical.Stop();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Enemy") {
            _source.PlayOneShot(_deathSound);
            _deathPartical.Play();
        }
    }
}
