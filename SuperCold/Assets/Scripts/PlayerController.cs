using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 1000f;
    public Transform movePoint;
    public int gridWidth = 64 ;
    
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //使player向MovePonit的位置移动
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, 5);//还是搞不清楚这个函数，大概是用来从一个位置移动到另一个位置的，但是不知道最后一个空应该填什么
        }

        //四个方向的面向
        if (Input.GetKeyDown(KeyCode.A))
        {
            movePoint.position = new Vector3(-gridWidth, -gridWidth / 2, 0f) + transform.position;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            movePoint.position = new Vector3(gridWidth, gridWidth / 2, 0f) + transform.position;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            movePoint.position = new Vector3(-gridWidth, gridWidth / 2, 0f) + transform.position;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            movePoint.position = new Vector3(gridWidth, -gridWidth / 2, 0f) + transform.position;
        }
    }

}
