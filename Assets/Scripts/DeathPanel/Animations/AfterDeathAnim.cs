using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Core;

public class AfterDeathAnim : MonoBehaviour
{
    [SerializeField] GameObject _target;
    [SerializeField] float _duration;

    Vector3 _startPos;

    private void Start() {
        _startPos = transform.position;
        DOTween.Init();
    }
    // Start is called before the first frame update
    private void OnEnable() {
        transform.DOMove(_target.transform.position, _duration)
            .SetEase(Ease.InOutExpo);
    }

    public void SetDefaulPosition() {
        DOTween.Clear();
        transform.position = _startPos;

    }
}
