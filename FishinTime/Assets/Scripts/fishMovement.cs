using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fishMovement : MonoBehaviour
{
    private float dirX;
    private float moveSpeed;
    private Rigidbody2D rb;
    private bool facingRight = false;
    private Vector3 localScale;

    public int Health = 1;

    public float RandomSpeed;
    public float MaximumSpeed;


    // Start is called before the first frame update
    void Start()
    {
        localScale = transform.localScale;
        rb = GetComponent<Rigidbody2D>();
        dirX = -1f;
        moveSpeed = Random.Range(RandomSpeed, MaximumSpeed);
        
        Health = 1;

       /* this.Wait(13.5f, () =>
        {
            Destroy(gameObject);
        });*/
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        /*if (collision.gameObject.tag == "fish")
        {
            dirX *= -1f;
        }*/

        if (collision.gameObject.tag == "wall")
        {
            dirX *= -1f;
        }

    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(dirX * moveSpeed, rb.velocity.y);
    }

    void LateUpdate()
    {
        CheckWhereToFace();
    }

    void CheckWhereToFace()
    {
        if (dirX > 0)
            facingRight = true;
        else if (dirX < 0)
            facingRight = false;

        if (((facingRight) && (localScale.x < 0)) || ((!facingRight) && (localScale.x > 0)))
            localScale.x *= -1;

        transform.localScale = localScale;
    }

    // Update is called once per frame
    void Update()
    {
        if (Health <= 0)
        {
            Destroy(gameObject);
        }

    }
}
