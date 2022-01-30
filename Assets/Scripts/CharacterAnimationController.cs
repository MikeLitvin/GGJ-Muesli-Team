using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class CharacterAnimationController : MonoBehaviour
{
    private NavMeshAgent _character;
    private Animator _animator;
    void Start()
    {
        _character = GetComponent<NavMeshAgent>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (_character.velocity.magnitude > 1)
        {
            _animator.Play("Armature_Walk");
        } 
    }
}
