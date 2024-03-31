using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class TargetEnemy : MonoBehaviour
{
    public float time;
    public Transform target;
    Vector3 pos;

    void Start()
    {
        Vector3 targetPos = target.position;
        targetPos.y += 1.5f;
        pos = targetPos;
        targetPos.y += 0.3f;
        this.transform.position = targetPos;
        this.transform.DOMove(pos, 1.5f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.OutSine);
        this.transform.DORotate(new Vector3(0,360,0),time, mode: RotateMode.FastBeyond360).SetLoops(-1);
    }
    void Update()
    {
        

    }
}
