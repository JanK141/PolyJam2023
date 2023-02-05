using StarterAssets;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimatorPassthrough : MonoBehaviour
{
    private Animator _animator;
    private ThirdPersonController _controller;

    void Awake()
    {
        _animator = GetComponent<Animator>();
        _controller = GetComponentInParent<ThirdPersonController>();
    }

    void Update()
    {
        _animator.SetBool("IsGrounded", _controller.Grounded);
        _animator.SetFloat("HorizontalVelocity", _controller._speed);
        _animator.SetFloat("VerticalVelocity", _controller._verticalVelocity);
    }
}
