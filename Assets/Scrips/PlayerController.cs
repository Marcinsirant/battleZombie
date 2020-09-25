using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Reflection;
using System.Security.Cryptography;
using Unity.Jobs.LowLevel.Unsafe;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Tilemaps;
using UnityEngine.UI;


public class PlayerController : MonoBehaviour
{
    //Start() variables
    private Rigidbody2D _rb;
    private Animator _anim;
    private SpriteRenderer _sRenderer;
    private Collider2D _coll;
    private bool _facingRight;
    [SerializeField] private AudioSource footstep;
    [SerializeField] private AudioSource coinSound;
    [SerializeField] private AudioSource jumpSound;
    [SerializeField] private AudioSource hurtSound;

    [SerializeField] private LayerMask ground;
    [SerializeField] private float _speed = 7f;
    [SerializeField] private float _jumpHeight = 9f;
    [SerializeField] private GameObject firePoint;

    public Joystick joystick;
    protected FireButton fireButton;

    // state
    private enum State { idle, walking, jumping, falling, hurt };
    private State _state = State.idle;
    private void Start()
    {
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        _coll = GetComponent<Collider2D>();
        _sRenderer = GetComponent<SpriteRenderer>();
        _facingRight = true;

        joystick = FindObjectOfType<Joystick>();
        fireButton = FindObjectOfType<FireButton>();
    }
    private void Update()
    {
        if (_state != State.hurt) {
            Movement();
        }

        AnimationState();
        _anim.SetInteger("state", (int)_state);

    }

    private void Movement()
    {
        
        _rb.velocity = new Vector2((joystick.Horizontal + Input.GetAxis("Horizontal")) * (_speed + (float)GetComponent<Weapons>().propertiesGun.speedPlayer) , _rb.velocity.y);
        if (joystick.Horizontal + Input.GetAxis("Horizontal") < 0)
        {

            if (_facingRight == true)
            {
                firePoint.transform.Rotate(0, 180f, 0);
            }
            _facingRight = false;

            transform.localScale = new Vector2(-1, 1);
        }
        else if (joystick.Horizontal + Input.GetAxis("Horizontal") > 0) {
            if (_facingRight == false)
            {
                firePoint.transform.Rotate(0, 180f, 0);
            }
            _facingRight = true;

            transform.localScale = new Vector2(1, 1);
        }
        //float hDirection = Input.GetAxis("Horizontal");
        //if (hDirection < 0)
        //{
        //    if (_facingRight == true)
        //    {
        //        firePoint.transform.Rotate(0, 180f, 0);
        //    }
        //    _facingRight = false;
        //    // walk left
        //    _rb.velocity = new Vector2(-_speed, _rb.velocity.y);
        //    transform.localScale = new Vector2(-1, 1);
        //}
        //else if (hDirection > 0)
        //{
        //    if (_facingRight == false) {
        //        firePoint.transform.Rotate(0, 180f, 0);
        //    }
        //    _facingRight = true;
        //    // walk right
        //    _rb.velocity = new Vector2(_speed, _rb.velocity.y);
        //    transform.localScale = new Vector2(1, 1);
        //}
        if ( (joystick.Vertical>0.5f || Input.GetKeyDown(KeyCode.W)) && _coll.IsTouchingLayers(ground))
        {
            Jump();
        }
    }

    private void Jump()
    {
        //jumping
        jumpSound.Play();
        _rb.velocity = new Vector2(_rb.velocity.x, _jumpHeight);
        _state = State.jumping;
    }

    private void AnimationState()
    {
        if (_rb.velocity.y < -3f)
        {
            _state = State.falling;
        }
        if (_state == State.jumping) {
            if (_rb.velocity.y < 0.05f)
            {
                _state = State.falling;
            }
        }
        else if (_state == State.falling) {
            if (_coll.IsTouchingLayers(ground)) {
                _state = State.idle;
               
            }
        } else if (_state == State.hurt) {
            _sRenderer.color = Color.red;
            if (Mathf.Abs(_rb.velocity.x) < 3f)
            {
                _state = State.idle;
                _sRenderer.color = Color.white;
            }
        }
        else if (Mathf.Abs(_rb.velocity.x) > Mathf.Epsilon) {
            // walking right 
            _state = State.walking;
            
        }
        else {
            _state = State.idle;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Collectable") {
           if (collision.name.Contains("Coin"))
           {
                coinSound.Play();
                PermamentUI.perm.coin+=10;
                PermamentUI.perm._CoinNumberText.text = PermamentUI.perm.coin.ToString();
            }
            Debug.Log(collision.gameObject.ToString());

            Debug.Log(collision.name);
            Destroy(collision.gameObject);
        }

        if (collision.tag == "Finish")
        {
            
            DataPlayer.dataPlayer.panelNumber = 1;
            if (DataPlayer.dataPlayer.levelFinished < DataPlayer.dataPlayer.currentLevel)
            {
                 DataPlayer.dataPlayer.levelFinished =  DataPlayer.dataPlayer.currentLevel;
            }
            DataPlayer.dataPlayer.currentCollectCoins = PermamentUI.perm.coin;
            SceneManager.LoadScene("UIManager");
            
        }
    }

    private void OnCollisionEnter2D(Collision2D otherSprite)
    {
        if (otherSprite.gameObject.tag == "Enemy") {
            Enemy enemy = otherSprite.gameObject.GetComponent<Enemy>();
            if (_state == State.falling)
            {
                enemy.Hurt(35);
                Jump();
            }
            else {
                Debug.Log(otherSprite);
                hurtSound.Play();
                _state = State.hurt;

                PermamentUI.subHealthPoint(40);

                if (otherSprite.transform.position.x < transform.position.x)
                {
                    //left enemy
                    //player sptring right
                    _rb.velocity = new Vector2(5, _rb.velocity.x);
                }
                else if (otherSprite.transform.position.x > transform.position.x) {
                    // right enemy
                    _rb.velocity = new Vector2(-5, _rb.velocity.x);
                }

            }
            
            
        }
        
        if (otherSprite.gameObject.tag == "Respawn")
        {
            DataPlayer.dataPlayer.currentCollectCoins = 0;
            PermamentUI.resetStat();
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            
        }
    }

    private void FootStep()
    {
        footstep.Play();
    }
    
    private void FootStepStop()
    {
        footstep.Stop();
    }
}

