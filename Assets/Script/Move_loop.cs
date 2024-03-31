using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Move_loop : MonoBehaviour
{
    void Start()
    {
        this.transform.DOMoveX(5f, 2f).SetLoops(-1, LoopType.Yoyo).SetEase(Ease.InElastic);
    }

    void Update()
    {
        //this.transform.DOMoveX(5f, 2f).SetEase(Ease.OutElastic);
        
    }
}
