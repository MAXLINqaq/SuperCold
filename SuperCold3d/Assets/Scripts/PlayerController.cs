using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 10f;
    
    public int isStill;
    public float moveDistance = 10f;//闪现距离

    public Animator animator;

    private Rigidbody rb;

    Vector3 movement;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.z = Input.GetAxisRaw("Vertical");
        if (movement.x == 0 && movement.z == 0)
        {
            isStill = 1;
        }
        else
        {
            isStill = 0;
        }
        Flash();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void Flash()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            Vector3 player = Camera.main.WorldToScreenPoint(transform.position);//获得角色位置
            Vector3 direction = Input.mousePosition - player;//获得方向
            direction.y = rb.position .y;
            direction = direction.normalized;//归一化
            rb.MovePosition(rb.position + direction * moveDistance);
        }
    }
    private void OnTriggerEnter2D(Collider other)
    {
        if ()
    }
    private void ontrig


}
