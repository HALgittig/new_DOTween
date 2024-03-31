using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using DG.Tweening;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    
    Animator animator;

    [SerializeField] TextMeshProUGUI HP_Value;
    [SerializeField] Image HPGauge;

    public bool Attack = false;
    public bool Die = false;

    Vector3 defaultPos;
    Vector3 targetPos;
    float moveSec = 1f;

    [Header("エネミーのステータス")]
    public float HPMax;
    public float HPCurrent;
    public float enemyAttack;
    public float enemyDefense;
    public int enemyID;

    float preHP = 0;
    

    void Start()
    {
        animator = GetComponent<Animator>();
        HP_Value.text = HPMax.ToString();
        HPCurrent = HPMax;
        preHP = HPCurrent;
        HPGauge.fillAmount = 1;
        defaultPos = this.transform.position;
    }

    void Update()
    {
        HPCurrent = Mathf.Clamp(HPCurrent, 0f, HPMax);
        if (HPCurrent <= 0)
        {
            DOTween.Kill(this);
            Die = true;
            animator.SetTrigger("Die");
            GameManager.Instance.enemy_die[enemyID] = true;
        }
        if (Attack)
        {
            Attack = false;
            targetPos = BattleManager.Instance.targetPlayer.transform.position;
            targetPos.x = targetPos.x - 0.3f;
            this.transform.DOMoveX(targetPos.x, moveSec);
            animator.SetBool("Run", true);
            DOVirtual.DelayedCall(1f, () => animator.SetBool("Run", false));
            DOVirtual.DelayedCall(1.2f, () => animator.SetTrigger("Attack"));
            DOVirtual.DelayedCall(1.3f, () => BattleManager.Instance.targetPlayer.GetComponent<Character>().HPCurrent -= BattleManager.Instance.damage[BattleManager.Instance.AttackCount++]);
            StartCoroutine("Delay");
        }

        if (preHP != HPCurrent)
        {
            animator.SetTrigger("Hit");
            HP_Value.text = HPCurrent.ToString();
            preHP = HPCurrent;
            HPGauge.DOFillAmount(HPCurrent / HPMax, 1f).SetEase(Ease.OutQuad);
        }
    }
    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("Back", true);
        this.transform.DOMoveX(defaultPos.x, 1.5f);
        DOVirtual.DelayedCall(1f, () => animator.SetBool("Back", false));
    }
}
