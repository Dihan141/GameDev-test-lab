using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{
    public Health healthh;
    public int health = 10;
    public int damage = 2;
    public Rigidbody2D rb;
    public BoxCollider2D bc;
    public float speed = 15f;
    public float humanTime = 3f;
    private float lastHuman;
    private float lastZombie;
    public float zombieTime = 8f;
    public bool movingLeft = false;
    public bool movingRight = true;
    public SpriteRenderer spriteRenderer;
    public Sprite human;
    public Sprite zombie;
    public bool isHuman = false;
    public bool isZombie = true;

    public void Start()
    {
        lastHuman = Time.time;
        lastZombie = Time.time;
        healthh.SetMaxHealth(health);
    }

    public void Update()
    {
        if(Time.time - lastZombie > zombieTime && isZombie)
        {
            spriteRenderer.sprite = human;
            isZombie = false;
            isHuman = true;
            lastZombie = Time.time;
            lastHuman = Time.time;
        }
        if(Time.time - lastHuman > humanTime && isHuman)
        {
            spriteRenderer.sprite = zombie;
            isHuman = false;
            isZombie =true;
            lastHuman = Time.time;
            lastZombie = Time.time;
        }
    }
    public void FixedUpdate()
    {
        if(!movingLeft && movingRight)
        {
            Move(new Vector2(speed, 0));
            transform.localScale = new Vector3(2, 2, 2);
        }
        else if(!movingRight && movingLeft)
        {
            Move(new Vector2(-speed, 0));
            transform.localScale = new Vector3(-2, 2, 2);
        }
    }

    public void Move(Vector2 dir)
    {
        rb.velocity = dir * Time.deltaTime;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.name == "CollisionWall" || collision.collider.tag == "Zombie")
        {
            if (movingRight)
            {
                movingRight = false;
                movingLeft = true;
            }
            else if(movingLeft)
            {
                movingLeft = false;
                movingRight = true;
            }
        }

        if(collision.collider.tag == "Bullet")
        {
            if(isHuman)
            {
                Death();
            }
        }
    }

    public void Death()
    {

        health -= 3;
        healthh.SetHealth(health);
        if(health <= 0)
        {
            FindObjectOfType<AudioManager>().Play("Death");
            Destroy(gameObject);
            FindObjectOfType<Score>().UpdateScore(10);
        }
    }
}
