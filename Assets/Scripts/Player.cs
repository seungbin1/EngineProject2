using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5;
    public bool bOnSelect=false;
    Player[] players;
    private void Awake()
    {
        bOnSelect = false;
        GameManager.Instance.mouseClick+=MovePlayer;
    }
    
    private void MovePlayer(Vector3 targetPos)
    {
        transform.position = Vector3.MoveTowards(transform.position, targetPos, speed * Time.deltaTime);
        print(targetPos);
    }

    public void OnSelect()
    {
        players = FindObjectsOfType<Player>();
        foreach (var item in players)
        {
            item.bOnSelect = false;
        }
        bOnSelect = true;
    }
}
