using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    Player[] players;
    private static GameManager instance;
    public static GameManager Instance { get { return instance; } }

    //스크린 터치 사이즈
    private float screensize=2;
    //스크린 터치 위치
    public Vector3 mousePostion;

    public delegate void MouseClick(Vector3 targetPos);
    public MouseClick mouseClick = (mousePostion) => { };


    //싱글톤
    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void OnDestroy()
    {
        if (instance == this)
        {
            instance = null;
        }
    }
    private void Update()
    {
        if (Input.GetMouseButton(0))
        {
            if(Input.mousePosition.x> Screen.width / screensize)
            {
                mousePostion = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                mouseClick(mousePostion);
            }
        }
    }
    //메뉴 메니저로 옮길 예정임
    public void StartButton()
    {

        //씬 이동
        Instantiate(SelectPlayer(), Vector3.zero, Quaternion.identity);
    }

    public GameObject SelectPlayer()
    {
        players = FindObjectsOfType<Player>();
        foreach (var item in players)
        {
            if (item.bOnSelect)
            {
                return item.gameObject;
            }
        }
        return null;
    }

}