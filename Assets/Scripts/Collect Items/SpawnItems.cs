using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using TMPro;
using UnityEngine;

public class SpawnItems : MonoBehaviour
{
    [SerializeField] GameObject _itemPrefab;
    [SerializeField] GameObject _spawnArea;
    [SerializeField] AudioSource _pickUpSource;
    [SerializeField] AudioClip _pickUpSound;

    private GameObject _currentObject;
    private RectTransform _rt;
    // Start is called before the first frame update
    void Start()
    {
        _pickUpSource = GetComponent<AudioSource>();
        _rt = _spawnArea.GetComponent<RectTransform>();
        Spawn();
    }

    private void Spawn() {
        _currentObject = _itemPrefab;
        _currentObject.transform.position = new Vector3(0, 0, 0);
        float width = _rt.rect.width / 2.0f;
        float height = _rt.rect.height / 2.0f;
        Vector3 spawnPosition = new Vector3(Random.Range(-width, width),
                  Random.Range(-height, height), 0)/120f;
        spawnPosition = new Vector3(spawnPosition.x + _rt.position.x, spawnPosition.y + _rt.position.y,0);
        Instantiate(_currentObject, spawnPosition, Quaternion.identity, transform);
    }

    public void Respawn() {
        _pickUpSource.PlayOneShot(_pickUpSound);
        Spawn();
    }
}
