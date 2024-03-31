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

    [SerializeField] Canvas[] canvas;

    [SerializeField] GameObject target_Marker;
    public GameObject targetEnemy;

    [SerializeField] private EventSystem eventSystem;

    public GameObject button_obj;

    public GameObject[] Player;
    public GameObject[] Enemy;

    void Start()
    {
        Player = GameObject.FindGameObjectsWithTag("Player");
        Enemy = GameObject.FindGameObjectsWithTag("Enemy");
        targetEnemy = Enemy[0];

    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Tab))
        {
            DOTween.KillAll();
            SceneManager.LoadScene(0);
        }
        if(Input.GetKeyDown(KeyCode.F1))
        {
            Time.timeScale = 2;
        }
        if (Input.GetKeyDown(KeyCode.F2))
        {
            Time.timeScale = 1;
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
