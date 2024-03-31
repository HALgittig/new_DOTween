using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using TMPro;

public class Character : MonoBehaviour
{

    [SerializeField] TextMeshProUGUI HP_Value;
    [SerializeField] Image HPGauge;

    [SerializeField] GameObject[] effect;
    public Transform effectPos;

    Vector3 defaultPos;
    Vector3 targetPos;
    public float moveSec = 1f;

    public float delayTime;

    public bool Attack = false;
    public bool AttackType1 = false;
    public bool AttackType2 = false;
    public bool AttackType3 = false;
    public bool Die = false;

    Animator animator;

    [Header("キャラクターのステータス")]
    public float HPMax;
    public float HPCurrent;
    public float charAttack;
    public float charDefense;
    public int charID;

    float preHP = 0;

    private void Awake()
    {
        HP_Value.text = HPMax.ToString();
        HPCurrent = HPMax;
        preHP = HPCurrent;
        defaultPos = this.transform.position;
        HPGauge.fillAmount = 1;
    }

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        HPCurrent = Mathf.Clamp(HPCurrent, 0f, HPMax);
        if (HPCurrent <= 0 && !Die)
        {
            DOTween.Kill(this);
            Die = true;
            BattleManager.Instance.deck.RemoveAll(card => card == charID+7);
            animator.SetTrigger("Die");
        }
        if (preHP != HPCurrent)
        {
            animator.SetTrigger("Damage");
            HP_Value.text = HPCurrent.ToString();
            preHP = HPCurrent;
            HPGauge.DOFillAmount(HPCurrent / HPMax, 1f).SetEase(Ease.OutQuad);
        }

        if (!Attack && (AttackType1 || AttackType2 || AttackType3)) { Attack = true; }

        if(BattleManager.Instance.AttackStart && Attack)
        {
            if(AttackType1)
            {
                AttackType1 = false;
                Attack = false;
                if (charID != 1)
                {
                    targetPos = GameManager.Instance.targetEnemy.transform.position;
                    targetPos.x = targetPos.x + 0.3f;
                    animator.SetBool("Run", true);
                    this.transform.DOMoveX(targetPos.x, moveSec);
                    DOVirtual.DelayedCall(1f, () => animator.SetBool("Run", false));
                    DOVirtual.DelayedCall(1.2f, () => animator.SetTrigger("AttackType_1"));
                    DOVirtual.DelayedCall(1.3f, () => GameManager.Instance.targetEnemy.GetComponent<Enemy>().HPCurrent -= BattleManager.Instance.damage[BattleManager.Instance.AttackCount++]);
                    StartCoroutine("Delay");
                }
                if (charID == 1)
                {
                    animator.SetTrigger("AttackType_1");
                    DOVirtual.DelayedCall(1f, () => GameManager.Instance.targetEnemy.GetComponent<Enemy>().HPCurrent -= BattleManager.Instance.damage[BattleManager.Instance.AttackCount++]);
                }
            }
            if (AttackType2)
            {
                AttackType2 = false;
                Attack = false;
                if (charID != 1)
                {
                    targetPos = GameManager.Instance.targetEnemy.transform.position;
                    targetPos.x = targetPos.x + 0.3f;
                    animator.SetBool("Run", true);
                    this.transform.DOMoveX(targetPos.x, moveSec);
                    DOVirtual.DelayedCall(1f, () => animator.SetBool("Run", false));
                    DOVirtual.DelayedCall(1.2f, () => animator.SetTrigger("AttackType_2"));
                    DOVirtual.DelayedCall(1.3f, () => GameManager.Instance.targetEnemy.GetComponent<Enemy>().HPCurrent -= BattleManager.Instance.damage[BattleManager.Instance.AttackCount++]);
                    StartCoroutine("Delay");
                }
                if (charID == 1)
                {
                    animator.SetTrigger("AttackType_2");
                    DOVirtual.DelayedCall(1f, () => GameManager.Instance.targetEnemy.GetComponent<Enemy>().HPCurrent -= BattleManager.Instance.damage[BattleManager.Instance.AttackCount++]);
                }
            }
            if (AttackType3)
            {
                targetPos = GameManager.Instance.targetEnemy.transform.position;
                targetPos.x = targetPos.x + 0.3f;
                animator.SetBool("Run", true);
                this.transform.DOMoveX(targetPos.x, moveSec);
                DOVirtual.DelayedCall(1f, () => animator.SetBool("Run", false));
                DOVirtual.DelayedCall(1.2f, () => animator.SetTrigger("AttackType_3"));
                DOVirtual.DelayedCall(1.3f, () => GameManager.Instance.targetEnemy.GetComponent<Enemy>().HPCurrent -= BattleManager.Instance.damage[BattleManager.Instance.AttackCount++]);
                AttackType3 = false;
                Attack = false;
                StartCoroutine("Delay");
            }
        }
    }
    public IEnumerator Delay()
    {
        yield return new WaitForSeconds(2f);
        animator.SetBool("Back", true);
        this.transform.DOMoveX(defaultPos.x, 1.5f);
        DOVirtual.DelayedCall(1f, () => animator.SetBool("Back", false));
    }
    /*void EffectIns()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Attack02Maintain"))
        {
            atack = true;
            GameObject atackEff = Instantiate(effect[0],effectPos.position,Quaternion.EulerAngles(0f,-90f,0f));
            Destroy(atackEff, 4f);
        }
    }*/

}
