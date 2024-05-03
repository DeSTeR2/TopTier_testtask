using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyCollision : MonoBehaviour
{
    [Header("Effects")]
    [SerializeField] private ParticleSystem _deathPartical;
    [SerializeField] private AudioClip _deathSound;
    [SerializeField] private AudioManager _soundManger;

    [Header("Death objects")]
    [SerializeField] private GameObject _afterDeath;
    [SerializeField] private GameObject _enemyController;

    // Start is called before the first frame update
    void Start()
    {
        _deathPartical.Stop();
    }

    private void OnEnable() {
        _deathPartical.Stop();
        _enemyController.SetActive(true);
        _enemyController.GetComponent<EnemyController>().Restart();
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.transform.tag == "Enemy") {
            _soundManger.PlaySound(_deathSound);
            _deathPartical.Play();
            _enemyController.GetComponent<EnemyController>().Stop();
            GetComponent<Move>().Dead();
            StartCoroutine(Death());
        }
    }

    private IEnumerator Death() {
        _afterDeath.SetActive(true);    
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
        _enemyController.SetActive(false);
    }
}
