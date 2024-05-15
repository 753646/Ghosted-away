using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMeshMovement : MonoBehaviour
{
    public float movementSpeed = 30f;
    private NavMeshAgent navMeshAgent;
    private Vector3 lastTargetPosition;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (movementDirection != Vector3.zero)
        {
            Vector3 targetPosition = transform.position + movementDirection * movementSpeed * Time.deltaTime;
            if (targetPosition != lastTargetPosition)
            {
                navMeshAgent.SetDestination(targetPosition);
                lastTargetPosition = targetPosition;
            }
        }
    }
}