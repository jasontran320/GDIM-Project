using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SidewaysEnemy : MonoBehaviour
{
    [SerializeField]
    private float movementDist;
    [SerializeField]
    private float speed;
    [SerializeField]
    private int dmg;

    private bool moveLeft;
    private float leftEdge;
    private float rightEdge;

    private void Awake()
    {
        leftEdge = transform.position.x - movementDist;
        rightEdge = transform.position.x + movementDist;
    }

    // Update is called once per frame
    void Update()
    {
        if (moveLeft)
        {
            if (transform.position.x > leftEdge)
            {
                transform.position = new Vector3(transform.position.x - speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                moveLeft = false;
        }
        else
        {
            if (transform.position.x < rightEdge)
            {
                transform.position = new Vector3(transform.position.x + speed * Time.deltaTime, transform.position.y, transform.position.z);
            }
            else
                moveLeft = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            collision.GetComponent<PlayerHealth>().TakeDamage(dmg);
        }
    }
}
