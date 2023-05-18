using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class startText : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            _animator.SetBool("spacePressed", true);
        }
    }
}
