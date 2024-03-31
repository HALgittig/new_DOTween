using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class UI_Flip : MonoBehaviour
{
    public float time;

    void Start()
    {
        this.transform.DORotate(new Vector3(0,0,720), time, mode: RotateMode.FastBeyond360).SetLoops(-1);
    }

    void Update()
    {
        
    }
}
