using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class BattleManager : Singleton<BattleManager>
{

    public GameObject[] PlayerChar;
    public GameObject[] AttackChar;
    public GameObject[] EnemyChar;
    [SerializeField] Canvas main_Canvas;
    [SerializeField] GameObject SelectPanel;
    [SerializeField] GameObject[] Fast_AttackCard;
    [SerializeField] GameObject[] Second_AttackCard;
    [SerializeField] GameObject[] Third_AttackCard;
    public GameObject targetPlayer;
    public List<int> deck = new List<int>() { 71, 71, 72, 72, 73, 81, 81, 81, 82, 83, 91, 92, 92, 93, 93 };
    public List<int> hand;

    public bool PlayerTurn = false;
    public bool EnemyTurn = false;
    public bool CardSelect = false;
    bool CardDecision = false;
    public bool ChooseableCard = false;
    public bool AttackStart = false;
    public int[] AttackType;
    public int[] CharType;
    public int AttackNum;

    float playerAT = 0;
    float targetDF = 0;
    public float[] damage;
    public int AttackCount = 0;
    
    void Start()
    {
        PlayerChar = GameObject.FindGameObjectsWithTag("Player");
        EnemyChar = GameObject.FindGameObjectsWithTag("Enemy");
        PlayerTurn = true;
        EnemyTurn = false;
    }

    void Update()
    {
        if(AttackCount == 3)
        {
            AttackCount = 0;
            CardDecision = false;
            if(PlayerTurn)
            {
                PlayerTurn = false;
                EnemyTurn = true;
                foreach (Transform child in SelectPanel.transform) { Destroy(child.gameObject); }
                hand.Clear();
                EnemyAttack();
                return;
            }
            if(EnemyTurn)
            {
                PlayerTurn = true;
                EnemyTurn = false;
                return;
            }
        }

        if (AttackNum == 3) 
        {
            AttackNum = 0;
            AttackStart = true;
            ChooseableCard = false;
            DOVirtual.DelayedCall(0.5f, () => SelectPanel.SetActive(false));//íxâÑèàóù
            Attack(); 
        }

    }
    
    public void Attack()
    {
        for (int i = 0; i < 3; i++)
        {
            if (CharType[i] == 0)
            {
                if (AttackType[i] == 0)
                {
                    playerAT = PlayerChar[0].GetComponent<Character>().charAttack;
                    targetDF = GameManager.Instance.targetEnemy.GetComponent<Enemy>().enemyDefense;
                    damage[i] = playerAT / targetDF * 50 * 1.5f;
                    damage[i] = Mathf.Floor(damage[i]);
                    DOVirtual.DelayedCall(i*3, () => PlayerChar[0].GetComponent<Character>().AttackType1 = true);
                    PlayerChar[CharType[i]].GetComponent<Character>().Attack = true;
                    AttackChar[i] = PlayerChar[CharType[i]];
                    continue;
                }
                if (AttackType[i] == 1)
                {
                    playerAT = PlayerChar[0].GetComponent<Character>().charAttack;
                    targetDF = GameManager.Instance.targetEnemy.GetComponent<Enemy>().enemyDefense;
                    damage[i] = playerAT / targetDF * 50 * 1.2f;
                    damage[i] = Mathf.Floor(damage[i]);
                    DOVirtual.DelayedCall(i * 3, () => PlayerChar[0].GetComponent<Character>().AttackType2 = true);
                    PlayerChar[CharType[i]].GetComponent<Character>().Attack = true;
                    AttackChar[i] = PlayerChar[CharType[i]];
                    continue;
                }
                if (AttackType[i] == 2)
                {
                    playerAT = PlayerChar[0].GetComponent<Character>().charAttack;
                    targetDF = GameManager.Instance.targetEnemy.GetComponent<Enemy>().enemyDefense;
                    damage[i] = playerAT / targetDF * 50 * 0.9f;
                    damage[i] = Mathf.Floor(damage[i]);
                    DOVirtual.DelayedCall(i * 3, () => PlayerChar[0].GetComponent<Character>().AttackType3 = true);
                    PlayerChar[CharType[i]].GetComponent<Character>().Attack = true;
                    AttackChar[i] = PlayerChar[CharType[i]];
                    continue;
                }
            }
            if (CharType[i] == 1)
            {
                if (AttackType[i] == 0)
                {
                    playerAT = PlayerChar[1].GetComponent<Character>().charAttack;
                    targetDF = GameManager.Instance.targetEnemy.GetComponent<Enemy>().enemyDefense;
                    damage[i] = playerAT / targetDF * 50 * 1.5f;
                    damage[i] = Mathf.Floor(damage[i]);
                    DOVirtual.DelayedCall(i * 3, () => PlayerChar[1].GetComponent<Character>().AttackType1 = true);
                    PlayerChar[CharType[i]].GetComponent<Character>().Attack = true;
                    AttackChar[i] = PlayerChar[CharType[i]];
                    continue;
                }
                if (AttackType[i] == 1)
                {
                    playerAT = PlayerChar[1].GetComponent<Character>().charAttack;
                    targetDF = GameManager.Instance.targetEnemy.GetComponent<Enemy>().enemyDefense;
                    damage[i] = playerAT / targetDF * 50 * 1.2f;
                    damage[i] = Mathf.Floor(damage[i]);
                    DOVirtual.DelayedCall(i * 3, () => PlayerChar[1].GetComponent<Character>().AttackType2 = true);
                    PlayerChar[CharType[i]].GetComponent<Character>().Attack = true;
                    AttackChar[i] = PlayerChar[CharType[i]];
                    continue;
                }
                if (AttackType[i] == 2)
                {
                    playerAT = PlayerChar[1].GetComponent<Character>().charAttack;
                    targetDF = GameManager.Instance.targetEnemy.GetComponent<Enemy>().enemyDefense;
                    damage[i] = playerAT / targetDF * 50 * 0.9f;
                    damage[i] = Mathf.Floor(damage[i]);
                    DOVirtual.DelayedCall(i * 3, () => PlayerChar[1].GetComponent<Character>().AttackType3 = true);
                    PlayerChar[CharType[i]].GetComponent<Character>().Attack = true;
                    AttackChar[i] = PlayerChar[CharType[i]];
                    continue;
                }
            }
            if (CharType[i] == 2)
            {
                if (AttackType[i] == 0)
                {
                    playerAT = PlayerChar[2].GetComponent<Character>().charAttack;
                    targetDF = GameManager.Instance.targetEnemy.GetComponent<Enemy>().enemyDefense;
                    damage[i] = playerAT / targetDF * 50 * 1.5f;
                    damage[i] = Mathf.Floor(damage[i]);
                    DOVirtual.DelayedCall(i * 3, () => PlayerChar[2].GetComponent<Character>().AttackType1 = true);
                    PlayerChar[CharType[i]].GetComponent<Character>().Attack = true;
                    AttackChar[i] = PlayerChar[CharType[i]];
                    continue;
                }
                if (AttackType[i] == 1)
                {
                    playerAT = PlayerChar[2].GetComponent<Character>().charAttack;
                    targetDF = GameManager.Instance.targetEnemy.GetComponent<Enemy>().enemyDefense;
                    damage[i] = playerAT / targetDF * 50 * 1.2f;
                    damage[i] = Mathf.Floor(damage[i]);
                    DOVirtual.DelayedCall(i * 3, () => PlayerChar[2].GetComponent<Character>().AttackType2 = true);
                    PlayerChar[CharType[i]].GetComponent<Character>().Attack = true;
                    AttackChar[i] = PlayerChar[CharType[i]];
                    continue;
                }
                if (AttackType[i] == 2)
                {
                    playerAT = PlayerChar[2].GetComponent<Character>().charAttack;
                    targetDF = GameManager.Instance.targetEnemy.GetComponent<Enemy>().enemyDefense;
                    damage[i] = playerAT / targetDF * 50 * 0.9f;
                    damage[i] = Mathf.Floor(damage[i]);
                    DOVirtual.DelayedCall(i * 3, () => PlayerChar[2].GetComponent<Character>().AttackType3 = true);
                    PlayerChar[CharType[i]].GetComponent<Character>().Attack = true;
                    AttackChar[i] = PlayerChar[CharType[i]];
                    continue;
                }
            }
        }
        
    }
    public IEnumerator AttackDelay(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }
    public void AttackSelect()
    {
        if(PlayerTurn && !EnemyTurn)
        {
            if (!CardDecision)
            {
                CardTypeDecision();
                CradDisplay();
                CardDecision = true;
                ChooseableCard = true;
            }
            if (!CardSelect)
            {
                SelectPanel.SetActive(true);
                CardSelect = true;
            }
            else
            {
                SelectPanel.SetActive(false);
                CardSelect = false;
            }
        }
    }
    public void CradDisplay()
    {
        float posx = -1800;
        for(int i = 0; i < 5; i++)
        {
            if (hand[i] == 11)
            {
                GameObject Card = Instantiate(Fast_AttackCard[0], SelectPanel.transform.position, Quaternion.identity);
                Card.transform.SetParent(SelectPanel.transform);
                Card.transform.localScale = new Vector3(1, 1, 1);
                Card.transform.localPosition = new Vector3(posx, 0f, 0f);
            }
            if (hand[i] == 12)
            {
                GameObject Card = Instantiate(Fast_AttackCard[1], SelectPanel.transform.position, Quaternion.identity);
                Card.transform.SetParent(SelectPanel.transform);
                Card.transform.localScale = new Vector3(1, 1, 1);
                Card.transform.localPosition = new Vector3(posx, 0f, 0f);
            }
            if (hand[i] == 13)
            {
                GameObject Card = Instantiate(Fast_AttackCard[2], SelectPanel.transform.position, Quaternion.identity);
                Card.transform.SetParent(SelectPanel.transform);
                Card.transform.localScale = new Vector3(1, 1, 1);
                Card.transform.localPosition = new Vector3(posx, 0f, 0f);
            }
            if (hand[i] == 21)
            {
                GameObject Card = Instantiate(Second_AttackCard[0], SelectPanel.transform.position, Quaternion.identity);
                Card.transform.SetParent(SelectPanel.transform);
                Card.transform.localScale = new Vector3(1, 1, 1);
                Card.transform.localPosition = new Vector3(posx, 0f, 0f);
            }
            if (hand[i] == 22)
            {
                GameObject Card = Instantiate(Second_AttackCard[1], SelectPanel.transform.position, Quaternion.identity);
                Card.transform.SetParent(SelectPanel.transform);
                Card.transform.localScale = new Vector3(1, 1, 1);
                Card.transform.localPosition = new Vector3(posx, 0f, 0f);
            }
            if (hand[i] == 23)
            {
                GameObject Card = Instantiate(Second_AttackCard[2], SelectPanel.transform.position, Quaternion.identity);
                Card.transform.SetParent(SelectPanel.transform);
                Card.transform.localScale = new Vector3(1, 1, 1);
                Card.transform.localPosition = new Vector3(posx, 0f, 0f);
            }
            if (hand[i] == 31)
            {
                GameObject Card = Instantiate(Third_AttackCard[0], SelectPanel.transform.position, Quaternion.identity);
                Card.transform.SetParent(SelectPanel.transform);
                Card.transform.localScale = new Vector3(1, 1, 1);
                Card.transform.localPosition = new Vector3(posx, 0f, 0f);
            }
            if (hand[i] == 32)
            {
                GameObject Card = Instantiate(Third_AttackCard[1], SelectPanel.transform.position, Quaternion.identity);
                Card.transform.SetParent(SelectPanel.transform);
                Card.transform.localScale = new Vector3(1, 1, 1);
                Card.transform.localPosition = new Vector3(posx, 0f, 0f);
            }
            if (hand[i] == 33)
            {
                GameObject Card = Instantiate(Third_AttackCard[2], SelectPanel.transform.position, Quaternion.identity);
                Card.transform.SetParent(SelectPanel.transform);
                Card.transform.localScale = new Vector3(1, 1, 1);
                Card.transform.localPosition = new Vector3(posx, 0f, 0f);
            }
            posx += 900f;
        }
        
    }
    public void CardTypeDecision()
    {
        DeckInit();
        hand.Clear();
        int i = 0;
        while(i < 5)
        {
            int cardID = deck[i];
            hand.Add(cardID);
            i++;
        }
    }
    void DeckInit()
    {
        int n = deck.Count;
        while(n > 1)
        {
            n--;

            int k = Random.Range(0, n + 1);

            int temp = deck[k];
            deck[k] = deck[n];
            deck[n] = temp;
        }
    }
    public void EnemyAttack()
    {
        int charid = 0;
        charid = Random.Range(0, 3);
        for (int i = 0; i < 3; i++)
        {
            playerAT = EnemyChar[i].GetComponent<Enemy>().enemyAttack;
            targetDF = PlayerChar[charid].GetComponent<Character>().charDefense;
            targetPlayer = PlayerChar[charid];
            damage[i] = playerAT / targetDF * 55 * 1.1f;
            damage[i] = Mathf.Floor(damage[i]);
            DOVirtual.DelayedCall( (i+1)*3,()=>EnemyChar[AttackCount].GetComponent<Enemy>().Attack = true);
            Debug.Log("www");
        }
    }
}
