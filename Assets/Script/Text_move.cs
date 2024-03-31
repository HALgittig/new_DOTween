using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Text_move : MonoBehaviour
{
    [SerializeField] Vector3 pos;

    [SerializeField] TextMeshProUGUI tmp;
    [SerializeField] string reText;
    [SerializeField] string beforeText = "off";

    bool change = false;

    void Start()
    {

        this.transform.DOLocalMove(pos, 1.5f).SetEase(Ease.OutElastic);
        this.tmp.DOFade(endValue: 1f, duration: 1.3f).SetEase(Ease.OutCirc).SetDelay(0.2f);

    }

    void Update()
    {
        if(tmp.alpha == 0)
        {
            change = true;
        }
        if(change)
        {
            reText = tmp.text;
            tmp.text = beforeText;
            if(beforeText == "on")
            {
                this.tmp.DOColor(Color.red, 0.5f);
            }
            else
            {
                this.tmp.DOColor(Color.black, 0.5f);
            }
            beforeText = reText;
            this.tmp.DOFade(endValue: 1f, duration: 0.5f).SetEase(Ease.InCirc);
            change = false;
        }
    }

    public void Text_Change()
    {
        this.tmp.DOFade(endValue: 0f, duration: 1.3f).SetEase(Ease.InBack).SetDelay(0.2f);
        this.transform.DOLocalJump(pos, jumpPower: 300f, numJumps: 2, duration: 2f);
    }
}
