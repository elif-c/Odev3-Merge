using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class characterController : MonoBehaviour
{
    [SerializeField] private float speed = 3.5f;
    [SerializeField] private float jumpForce = 340f;
    private Rigidbody2D _rigidbody2D;
    private Animator _animator;
    [SerializeField] public GameObject _camera;
    public AudioClip _audioJump;
    private AudioSource _audio;
    public AudioClip _audioLevelClear;

    private bool grounded;
    private bool gameStart;
    private bool jumping;

    

    private void Awake()
    {
        _rigidbody2D = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        _audio = GetComponent<AudioSource>();

        grounded = true;

    }

    private void FixedUpdate()
    {
        if (gameStart)
        {
            _rigidbody2D.velocity = new Vector2(speed, _rigidbody2D.velocity.y);
        }

        if (jumping)
        {
            _rigidbody2D.AddForce(new Vector2(0f, jumpForce));
            jumping = false;
        }
        if(84.1f > _rigidbody2D.transform.position.x && _rigidbody2D.transform.position.x > 84.0f)
        {
            _audio.PlayOneShot(_audioLevelClear);
        }
        

    }

    private void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            if (gameStart && grounded)
            {
                _animator.SetTrigger("jump");
                grounded = false;
                jumping = true;
                _audio.PlayOneShot(_audioJump);


            }
            else
            {
                _animator.SetBool("gameStart", true);
                gameStart = true;
            }
        }

        _animator.SetBool("grounded", grounded);
        
        

    }

    private void LateUpdate()
    {
        _camera.transform.position = new Vector3(_rigidbody2D.transform.position.x + 8.15f, 0.49f, _rigidbody2D.transform.position.z - 1.0f);
        if (_camera.transform.position.x > 85f)
        {
            _camera.transform.position = new Vector3(84.95f, 0.49f, _rigidbody2D.transform.position.z - 1.0f);


        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("ground")) 
        {
            grounded = true;
        }
    }

    
}
