using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour {

    private Animator _animator;
    
    [SerializeField] private AnimatorOverrideController  _alterniteAimAnimatorContronller;
    private RuntimeAnimatorController  _cacheController;
    
    void Start() {
        _animator = GetComponent<Animator>();
        _cacheController = _animator.runtimeAnimatorController;
    }

    
    void Update()
    {
        if (Input.anyKeyDown == false) {
            _animator.SetBool("Move", false);
            _animator.SetBool("Shoot", false);
            _animator.SetBool("Aim", false);
        }
        
        
        if (Input.GetKey(KeyCode.Mouse1)) {
            if (Input.GetKey(KeyCode.LeftShift)) {
                _animator.runtimeAnimatorController = _alterniteAimAnimatorContronller;
            } else _animator.runtimeAnimatorController = _cacheController;
            
            _animator.SetBool("Aim", true);

        }
        
        if (Input.GetKey(KeyCode.Mouse0)) {
            _animator.SetBool("Shoot", true);
        }
        
        if (Input.GetKey(KeyCode.W)) {
            _animator.SetBool("Move", true);
        }
    }

    public void Shoot() {
        Debug.Log("Shoot");
    }
}
