using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class Card : MonoBehaviour
{

    public int charType;
    public int cardType;
    bool selected = false;

    Tween tween;

    void Start()
    {
       tween = this.transform.DOLocalMoveY(150f,5f).SetLoops(-1,LoopType.Yoyo).SetEase(Ease.OutCirc);
    }

    void Update()
    {
        if(BattleManager.Instance.AttackCount == 3) { tween.Kill(); }
    }
    public void Selected()
    {
        if (selected == true)
        {
            selected = false;
            tween.Play();
            BattleManager.Instance.AttackNum--;
            return;
        }
        if (BattleManager.Instance.ChooseableCard && !selected)
        {
            tween.Pause();
            this.transform.DOMoveY(300f, 0.5f);
            BattleManager.Instance.AttackType[BattleManager.Instance.AttackNum] = cardType;
            BattleManager.Instance.CharType[BattleManager.Instance.AttackNum++] = charType;
            selected = true;
            return;
        }
        
    }
}
