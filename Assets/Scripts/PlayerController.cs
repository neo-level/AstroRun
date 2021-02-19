using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator _animator;

    // Start is called before the first frame update
    void Start()
    {
        _animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(key: KeyCode.Space))
        {
            IsJumping(true);
        }
        else
        {
            IsJumping(false);

        }
    }

    private void IsJumping(bool isSpacePressed)
    {
        _animator.SetBool("isJumping", isSpacePressed);
    }
}