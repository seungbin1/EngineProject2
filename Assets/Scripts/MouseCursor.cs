using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseCursor : MonoBehaviour
{
    private void Awake()
    {
        GameManager.Instance.mouseClick += CursorMove;
    }
    private void CursorMove(Vector3 targetPos)
    {
        transform.position = targetPos;
    }
}
