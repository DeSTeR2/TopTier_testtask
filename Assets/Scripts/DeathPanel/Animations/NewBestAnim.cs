using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBestAnim : MonoBehaviour
{
    [SerializeField] private float _duration;
    void Start()
    {
        DOTween.Init(this);
        transform.DOScale(new Vector3(1.1f, 1.1f, 1.1f),_duration)
            .SetEase(Ease.InOutSine)
            .SetLoops(-1, LoopType.Yoyo);
    }

    private void OnDisable() {
        gameObject.SetActive(false);
    }
}
