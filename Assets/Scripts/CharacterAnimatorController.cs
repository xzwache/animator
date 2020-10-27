using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterAnimatorController : MonoBehaviour {

    [SerializeField] private Animator _animator;

    private bool _crouching;
    
    void Update()
    {
        if (Input.anyKeyDown == false) {
            _animator.SetBool("Jump", false);
            _animator.SetBool("Crouch", false);

            _crouching = false;
            
            _animator.SetFloat("Speed", 0.0f);
        }
        
        // Jumping
        if (Input.GetKey(KeyCode.UpArrow)) _animator.SetBool("Jump", true);
        // Crouching
        if (Input.GetKey(KeyCode.DownArrow)) {
            _crouching = true;
            _animator.SetBool("Crouch", true);
        }

        // Walking
        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
            _animator.SetFloat("Speed", 0.3f);
            
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift)) {
                _animator.SetFloat("Speed", 0.6f);
            }

            if (_crouching) {
                _animator.SetFloat("Speed", 0.1f);
            }
        }
        
        Debug.Log(_animator.GetFloat("Speed"));
    }
}
