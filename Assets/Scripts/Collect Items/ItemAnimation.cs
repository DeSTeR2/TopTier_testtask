using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ItemAnimation : MonoBehaviour
{
    [SerializeField] float _animTime;
    void Start()
    {
        //_particles.Stop();
        DOTween.Init();
        transform.DOLocalRotate(new Vector3(0, 0, 360), _animTime, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart)
            .SetRelative()
            .SetEase(Ease.Linear);
    }

    public void Delete() {
        this.gameObject.SetActive(false);
    }
}
