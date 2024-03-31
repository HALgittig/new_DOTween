using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using DG.Tweening;

public class GameManager : Singleton<GameManager>
{

    public bool targetChange = false;
    public bool current_TargetEnemy = false;
    public bool clear = false;
    public bool over = false;
    bool mainGame = false;

    public bool[] char_die;
    public bool[] enemy_die;

    [SerializeField] Canvas[] canvas;

    [SerializeField] GameObject target_Marker;
    public GameObject targetEnemy;

    [SerializeField] GameObject winText;
    [SerializeField] GameObject loseText;

    [SerializeField] private EventSystem eventSystem;

    public GameObject button_obj;

    public GameObject[] Player;
    public GameObject[] Enemy;


    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        targetEnemy = Enemy[0];
        winText.SetActive(false);
        loseText.SetActive(false);
        mainGame = true;
        clear = false;
        over = false;
    }

    void Update()
    {
        GameClear();
        GameOver();
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            DOTween.KillAll();
            SceneManager.LoadScene(0);
        }
    }

    public void GameClear()
    {
        if(mainGame && enemy_die[0] && enemy_die[1] && enemy_die[2])
        {
            mainGame = false;
            clear = true;
            winText.SetActive(true);
            winText.transform.DOBlendableScaleBy(new Vector3(1.2f, 1f, 0f), 1f).SetEase(Ease.InOutBack);
        }
    }
    public void GameOver()
    {
        if(mainGame && char_die[0] && char_die[1] && char_die[2])
        {
            mainGame = false;
            over = true;
            loseText.SetActive(true);
            loseText.transform.DORotate(new Vector3(0f, 0f, -10f), 1f,RotateMode.FastBeyond360).SetEase(Ease.OutBounce);
        }
    }
    public void TargetChange(int id)
    {
        targetChange = true;
        eventSystem = EventSystem.current;
        button_obj = eventSystem.currentSelectedGameObject;
        Vector3 targetPos = button_obj.transform.position;
        target_Marker.transform.position = targetPos;
        targetEnemy = Enemy[id];
    }
}
