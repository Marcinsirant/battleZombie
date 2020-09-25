using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieController : Enemy
{
    
    private Collider2D _coll;
    private bool _facingLeft = true;

    private Rigidbody2D _rb;
    private Animator _anim;

    [SerializeField] private float _leftCap;
    [SerializeField] private float _rightCap;

    [SerializeField] private float _speedLeft = 2;
    [SerializeField] private float _speedRight = 2;

    private enum State { idle, walking };
    private State _state = State.idle;
    

    protected override void Start()
    {
        base.Start();
        _coll = GetComponent<Collider2D>();
        _rb = GetComponent<Rigidbody2D>();
        _anim = GetComponent<Animator>();
        
    }
    // Update is called once per frame
    void Update()
    {
        if (isDead == false) { 
        Movement();
        }
        AnimationState();
        _anim.SetInteger("state", (int)_state);
    }

    private void Movement()
    {
        
        if (_leftCap != _rightCap)
        {
            if (_facingLeft)
            {
                if (transform.position.x > _leftCap)
                {
                    _rb.velocity = new Vector2(-_speedLeft, _rb.velocity.y);
                    transform.localScale = new Vector2(transform.localScale.x > 0 ? transform.localScale.x : -transform.localScale.x, transform.localScale.y);
                }
                else
                {
                    _facingLeft = false;
                }
            }
            else
            {
                if (transform.position.x < _rightCap)
                {
                    _rb.velocity = new Vector2(_speedRight, _rb.velocity.y);
                    transform.localScale = new Vector2(transform.localScale.x < 0 ? transform.localScale.x : -transform.localScale.x, transform.localScale.y);
                }
                else
                {
                    _facingLeft = true;
                }
            }
        }
    }

    private void AnimationState() {
        if (Mathf.Abs(_rb.velocity.x) > 0.1) {
            _state = State.walking;
        }
        else {
            _state = State.idle;
        }
    }
}