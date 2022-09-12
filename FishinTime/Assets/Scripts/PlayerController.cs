using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject hook;
    private Rigidbody2D myRB;
    public Sprite invicibility;

    private bool canShoot = true;
    public float shootCooldownTime;
    public float hookSpeed;
    private float timeDifference;
    public bool invincible = false;
    public float invinicbleCooldownTime;
    private float timeDifference2;

    public float speed = 10;
    public int playerHealth = 3;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();

        playerHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {
        if (playerHealth <= 0)
        {
            transform.SetPositionAndRotation(new Vector2(), new Quaternion());
            playerHealth = 3;
        }

        Vector2 velocity = myRB.velocity;

        velocity.x = Input.GetAxisRaw("Horizontal") * speed;
        velocity.y = Input.GetAxisRaw("Vertical") * speed;

        myRB.velocity = velocity;

        if (canShoot)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                GameObject b = Instantiate(hook, new Vector2(transform.position.x, transform.position.y + 1), transform.rotation);
                b.GetComponent<Rigidbody2D>().velocity = new Vector2(0, hookSpeed);

                // Delete the comment slashes on the code below once you follow along with Day 13's Recording
                //mySpeaker.clip = shootSound;
                //mySpeaker.Play();



                canShoot = false;
            }
        }

        if(canShoot == false)
        {
            timeDifference += Time.deltaTime;

            if (timeDifference >= shootCooldownTime)
            {
                canShoot = true;
                timeDifference = 0;
            }
        }

        if (invincible == true)
        {
            timeDifference2 += Time.deltaTime;

            if (timeDifference2 >= invinicbleCooldownTime)
            {
                invincible = false;
                timeDifference2 = 0;
                GetComponent<SpriteRenderer>().color = UnityEngine.Color.white;
            }
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Shark") && !invincible)
        {
            // Delete the comment slashes on the code below once you follow along with Day 13's Recording
            //mySpeaker.clip = punchSound;
            //mySpeaker.Play();

            playerHealth--;


        }

        else if (collision.gameObject.name.Contains("Fish"))
        {
            // This also means playerHealth = playerHealth + 1;
            //playerHealth++;

            // Delete the comment slashes on the code below once you follow along with Day 13's Recording
            //mySpeaker.clip = pickupSound;
            //mySpeaker.Play();

            invincible = true;

            GetComponent<SpriteRenderer>().color = UnityEngine.Color.yellow;

            myRB = collision.gameObject.GetComponent<Rigidbody2D>();


            collision.gameObject.SetActive(false);

            myRB = GetComponent<Rigidbody2D>();
        }
    }
}
