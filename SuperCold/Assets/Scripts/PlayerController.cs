using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Start is called before the first frame update
    public float moveSpeed = 10f;
    public int isStill;
    public float moveDistance = 10f;//闪现距离
    public Animator animator;

    private Rigidbody2D rb;

    Vector2 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (movement.x == 0 && movement.y == 0)
        {
            isStill = 1;
        }
        else
        {
            isStill = 0;
        }
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);

        if (movement.x < 0 && movement.y < 0)
        {
            animator.SetBool("A", true); animator.SetBool("W", false); animator.SetBool("S", false); animator.SetBool("D", false);
        }
        else if (movement.x > 0 && movement.y > 0)
        {
            animator.SetBool("D", true); animator.SetBool("W", false); animator.SetBool("S", false); animator.SetBool("A", false);
        }
        else if (movement.x < 0 && movement.y > 0)
        {
            animator.SetBool("W", true); animator.SetBool("A", false); animator.SetBool("S", false); animator.SetBool("D", false);
        }
        else if (movement.x > 0 && movement.y < 0)
        {
            animator.SetBool("S", true); animator.SetBool("W", false); animator.SetBool("A", false); animator.SetBool("D", false);
        }
        else if (movement.x > 0 && movement.y == 0)
        {
            animator.SetBool("S", true); animator.SetBool("W", false); animator.SetBool("A", false); animator.SetBool("D", false);
        }
        else if (movement.x < 0 && movement.y == 0)
        {
            animator.SetBool("A", true); animator.SetBool("W", false); animator.SetBool("S", false); animator.SetBool("D", false);
        }
        //四个方向的面向
        Flash();
    }
    private void Flash()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 player = Camera.main.WorldToScreenPoint(transform.position);//获得鼠标位置
            Vector2 direction = Input.mousePosition - player;//获得方向
            direction = direction.normalized;//归一化
            rb.MovePosition(rb.position + direction * moveDistance);
        }
    }
}
