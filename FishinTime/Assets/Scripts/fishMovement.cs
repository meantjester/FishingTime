using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishMovement : MonoBehaviour
{
    public float movementSpeed = 5;
    public bool canMove = false;
    public bool movementDirection = false;
    public bool isFollowing = false;

    public Transform playerTarget;
    private Rigidbody2D myRB;
    private CircleCollider2D detectionZone;
    private Vector2 up;
    private Vector2 down;
    private Vector2 zero;

    // Start is called before the first frame update
    void Start()
    {
        up = new Vector2(0, movementSpeed);
        down = new Vector2(0, -movementSpeed);
        zero = new Vector2(0, 0);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
