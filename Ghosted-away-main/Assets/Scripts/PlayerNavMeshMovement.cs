using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMeshMovement : MonoBehaviour
{
    public float movementSpeed = 30f;
    private NavMeshAgent navMeshAgent;
    private Animator animator;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
        Vector3 moveVelocity = movementDirection * movementSpeed;

        if (moveVelocity.magnitude > 0.1f)
        {
            navMeshAgent.SetDestination(transform.position + moveVelocity * Time.deltaTime);
            animator.SetBool("IsWalking", true);
        }
        else
        {
            navMeshAgent.ResetPath();
            animator.SetBool("IsWalking", false);
        }
    }
}