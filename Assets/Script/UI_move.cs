using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class UI_move : MonoBehaviour
{
    public bool defScale = false;

    [SerializeField] Vector3 pos;

    [SerializeField]Image image;

    [SerializeField]TextMeshProUGUI tmp;

    void Awake()
    {
        this.image.DOFade(endValue:0f,duration:0f).SetEase(Ease.INTERNAL_Zero);
        this.tmp.DOFade(endValue: 0f, duration: 0f).SetEase(Ease.INTERNAL_Zero);
        if (defScale)
        {
            this.transform.DOScale(0f, 0f);
        }
        
    }

    void Start()
    {
        if (defScale)
        {
            this.transform.DOScale(1f, 1f).SetEase(Ease.OutElastic).SetDelay(0.5f);
        }
        this.transform.DOLocalMove(pos, 1.5f).SetEase(Ease.OutElastic);
        this.image.DOFade(endValue: 1f, duration: 1.3f).SetEase(Ease.OutCirc).SetDelay(0.2f);
        this.tmp.DOFade(endValue: 1f, duration: 1.3f).SetEase(Ease.OutCirc).SetDelay(0.2f);
    }

    void Update()
    {
        
    }

}
