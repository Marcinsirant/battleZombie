using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public int hp = 100;
    protected Animator _anim;
    protected Rigidbody2D _rb;
    protected bool isDead = false;
    public GameObject hpBar;
    // Start is called before the first frame update
    [SerializeField]protected AudioSource hurtSound;
    [SerializeField]protected AudioSource deathSound;
    protected virtual void Start()
    {
        _anim = GetComponent<Animator>();
        _rb = GetComponent<Rigidbody2D>();
    }

    public void Hurt(int damage)
    {
        hurtSound.Play();
        hp -= damage;

        if (hp<=0)
        {
            deathSound.Play();
             isDead = true;
            _anim.SetTrigger("Dead");
            _rb.velocity = Vector2.zero;
            _rb.bodyType = RigidbodyType2D.Kinematic;
            GetComponent<Collider2D>().enabled = false;
            hp = 0;
        }
        hpBar.GetComponent<HealthPoints>().SetHealthPoint(hp);
    }

    // after dead animation is over, this method is called
    private void Dead()
    {
        Destroy(this.gameObject);
    }

}
