using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Runtime;

public class enemyMovement : MonoBehaviour
{
    public float detectionRadius = 3;
    public float movementSpeed = 5;
    public bool canMove = false;
    public bool movementDirection = false; // false = down | true = up
    public bool isFollowing = false;

    private System.Random rand;

    public GameObject[] endPoints;
    public Transform playerTarget;
    private Rigidbody2D myRB;
    private CircleCollider2D detectionZone;
    private Vector2 up;
    private Vector2 down;
    private Vector2 zero;

    public int Health = 1;

    // Start is called before the first frame update
    void Start()
    {
        rand = new System.Random();

        new Vector2(0, movementSpeed);
        down = new Vector2(0, -movementSpeed);
        zero = new Vector2(0, 0);

        playerTarget = GameObject.Find("Player").transform;

        myRB = GetComponent<Rigidbody2D>();

        detectionZone = GetComponent<CircleCollider2D>();

        Health = 1;
    }

    // Update is called once per frame
    void Update()
    {
        detectionZone.radius = detectionRadius;

        if (isFollowing == false)
        {
            // Delete the comment slashes on the code below once you follow along with Day 12's Recording
            //myAnimator.SetBool("isWalking", false);
            myRB.velocity = zero;
        }

        else if (isFollowing == true)
        {
            Vector3 lookPos = playerTarget.position - transform.position;
            float angle = Mathf.Atan2(lookPos.y, lookPos.x) * Mathf.Rad2Deg;
            myRB.rotation = angle;
            lookPos.Normalize();

            // Delete the comment slashes on the code below once you follow along with Day 12's Recording
            //myAnimator.SetBool("isWalking", true);

            myRB.MovePosition(transform.position + (lookPos * movementSpeed * Time.deltaTime));
            
        }

        if (Health <= 0)
        {
            transform.SetPositionAndRotation(new Vector2(), new Quaternion());
            Health = 3;
        }


    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            playerTarget = endPoints[rand.Next(0, 2)].transform;
        }

        if (collision.gameObject.name.Contains("Wall"))
        {
           
        }

    }

    // Runs when our enemy collider is collided with OR when our enemy collides with another trigger.
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
        {
            movementSpeed = 40;
        }
    }

    // Runs when an object leaves our enemy's trigger volume OR when our enemy leaves another trigger volume.
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.name.Contains("Player"))
            movementSpeed = 28;
    }
}
