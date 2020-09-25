using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int speed;
    public int longShot;
    public float startX;

    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        speed = 10;
        longShot = 5;
        rb = GetComponent<Rigidbody2D>();
        rb.velocity = rb.transform.right * speed;
        startX = rb.position.x;
    }

    private void Update()
    {
        if (Mathf.Abs(startX - rb.position.x) > longShot)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.name != "Background")
        {
            Debug.Log(collision.name);
            

            if (collision.gameObject.tag == "Enemy")
            {
                Enemy enemy = collision.gameObject.GetComponent<Enemy>();
                enemy.Hurt(80);
                Destroy(gameObject);
            }


        }
    }
}
