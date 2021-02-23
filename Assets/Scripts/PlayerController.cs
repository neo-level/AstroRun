using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;
    public static GameObject Player;
    public static GameObject CurrentPlatform;
    
    private static readonly int HasMagic = Animator.StringToHash("hasMagic");
    private static readonly int IsJumping = Animator.StringToHash("isJumping");

    // Start is called before the first frame update
    private void Start()
    {
        _animator = GetComponent<Animator>();
        Player = gameObject;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Input.GetKeyDown(key: KeyCode.Space) && !_animator.GetBool(HasMagic))
        {
            _animator.SetBool(IsJumping, true);
        }
        else if (Input.GetKeyDown(key: KeyCode.M) && !_animator.GetBool(IsJumping))
        {
            _animator.SetBool(HasMagic, true);
        }
        else if (Input.GetKeyDown(key: KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * 90);
        }
        else if (Input.GetKeyDown(key: KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.down * 90);
        }

        else if (Input.GetKeyDown(key: KeyCode.A))
        {
            transform.Translate(Vector3.left);
        }

        else if (Input.GetKeyDown(key: KeyCode.D))
        {
            transform.Translate(Vector3.right);
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        CurrentPlatform = other.gameObject;
    }

    /// <summary>
    /// This method is being used as an Animation event
    /// </summary>
    private void StopJumping()
    {
        _animator.SetBool(IsJumping, false);
    }

    /// <summary>
    /// This method is being used as an Animation event
    /// </summary>
    private void StopMagic()
    {
        _animator.SetBool(HasMagic, false);
    }
}