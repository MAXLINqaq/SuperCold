using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatfromController : MonoBehaviour
{
    public GameObject player;
    public float moveSpeed = 10f;
    public Vector3 MovementDirection;
    public Transform Point1;


    public int isPlayerStill;


    // Start is called before the first frame update
    void Start()
    {
        Point1.parent = null;
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        Movement();
    }


    void Movement()
    {
        if (player.GetComponent<PlayerController>().isStill == 1)
        {
            transform.position = Vector3.MoveTowards(transform.position, Point1.position, moveSpeed * Time.deltaTime / 100);
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, Point1.position, moveSpeed * Time.deltaTime);

        }
        if (Vector3.Distance(transform.position, Point1.position) <= 1f && Point1.position.x >= transform.position.x)
        {
            Point1.position -= MovementDirection;
        }
        else if (Vector3.Distance(transform.position, Point1.position) <= 1f && Point1.position.x < transform.position.x)
        {
            Point1.position += MovementDirection;
        }
    }
}
