using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 10f;
    public Transform movePoint;
    public float gridWidth = 0.5f ;
    public Animator animator;
    
    void Start()
    {
        movePoint.parent = null;
    }

    // Update is called once per frame
    void Update()
    {
        //很奇怪，为什么playmovepoint为什么直接移动到了（1000，500）的位置。只能靠moveTowards控制步长了
        //存在两个问题，一是movePoint移动得太远，而是摁一下space移动一下，如果步长舍得太短
        //使player向MovePonit的位置移动

        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.position = Vector3.MoveTowards(transform.position, movePoint.position, 0.52f);//还是搞不清楚这个函数，大概是用来从一个位置移动到另一个位置的，但是不知道最后一个空应该填什么
        }

        if (Input.GetKeyDown(KeyCode.A))
        {
            animator.SetBool("A",true );animator.SetBool("W", false); animator.SetBool("S", false); animator.SetBool("D", false);
            movePoint.position = new Vector3(-gridWidth, -gridWidth / 2, 0f) + transform.position;
        }

        if (Input.GetKeyDown(KeyCode.D))
        {
            animator.SetBool("D", true); animator.SetBool("W", false); animator.SetBool("S", false); animator.SetBool("A", false);
            movePoint.position = new Vector3(gridWidth, gridWidth / 2, 0f) + transform.position;
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            animator.SetBool("W", true); animator.SetBool("A", false); animator.SetBool("S", false); animator.SetBool("D", false);
            movePoint.position = new Vector3(-gridWidth, gridWidth / 2, 0f) + transform.position;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            animator.SetBool("S", true); animator.SetBool("W", false); animator.SetBool("A", false); animator.SetBool("D", false);
            movePoint.position = new Vector3(gridWidth, -gridWidth / 2, 0f) + transform.position;
        }

        //四个方向的面向

    }
}
