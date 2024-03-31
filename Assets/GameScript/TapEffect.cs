using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TapEffect : MonoBehaviour
{
    [SerializeField] GameObject TouchEffect;
    [SerializeField] Camera main_Camera;
    [SerializeField] Canvas game_Canvas;

    public Vector3 cursor_point;

    private void Start()
    {

    }
    private void Update()
    {
        OnClick();
    }
    public void OnClick()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Vector3 tmp = Input.mousePosition;
            tmp.z = Vector3.Distance(new Vector3(0f,0f,game_Canvas.transform.position.z),main_Camera.transform.position);
            cursor_point = main_Camera.ScreenToWorldPoint(tmp);
            GameObject obj = Instantiate(TouchEffect, cursor_point,Quaternion.identity);
            obj.transform.SetParent(transform);
            Destroy(obj, 1f);
        }
    }
}
