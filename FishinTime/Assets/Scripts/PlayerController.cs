using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    public MoneyHandler wallet;

    public GameObject hook;
    public GameObject projectile;
    private Rigidbody2D myRB;
    public Sprite invicibility;

    private bool canShoot = true;
    public float shootCooldownTime;
    public float hookSpeed;
    private float timeDifference;
    public bool invincible = false;
    public float invinicbleCooldownTime;
    private float timeDifference2;
    public float firerate = 0.5f;
    private float nextFire = 0.5f;

    public bool canspawnF;
    public bool canspawnS;
    public float spawnrateF = 3.5f;
    public float spawnrateS = 5.5f;
    //private float nextspawn = 0.5f;

    public float speed = 10;
    public int playerHealth = 10000000;

    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();

        //playerHealth = 3;
    }

    // Update is called once per frame
    void Update()
    {

        if (playerHealth <= 0)
        {
            //transform.SetPositionAndRotation(new Vector2(), new Quaternion());
            Destroy(gameObject);
        }

        Vector2 velocity = myRB.velocity;

        velocity.x = Input.GetAxisRaw("Horizontal") * speed;
        velocity.y = Input.GetAxisRaw("Vertical") * speed;



        if (canShoot)
        {
            if (Input.GetKey(KeyCode.Space) && Time.time > nextFire)
            {
                nextFire = Time.time + firerate;
                Instantiate(projectile, new Vector3(transform.position.x, transform.position.y - 1, transform.position.z), transform.rotation);

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
                timeDifference = 3;
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

        myRB.velocity = velocity;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name.Contains("Shark") && !invincible)
        {
            // Delete the comment slashes on the code below once you follow along with Day 13's Recording
            //mySpeaker.clip = punchSound;
            //mySpeaker.Play();

            //playerHealth--;

            wallet.money -= 100;
        }

        else if (collision.gameObject.name.Contains("Fish"))
        {
            // This also means playerHealth = playerHealth + 1;
            //playerHealth++;

            // Delete the comment slashes on the code below once you follow along with Day 13's Recording
            //mySpeaker.clip = pickupSound;
            //mySpeaker.Play();

            wallet.money += 100;
            wallet.score += 1;
            

            invincible = true;

            GetComponent<SpriteRenderer>().color = UnityEngine.Color.yellow;

            myRB = collision.gameObject.GetComponent<Rigidbody2D>();


            collision.gameObject.SetActive(false);

            myRB = GetComponent<Rigidbody2D>();

            Destroy(gameObject);

            MainMenu.instance.AddPoint();

        }
    }
}
