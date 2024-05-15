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

        if (Mathf.Abs(horizontalInput) > 0.1f || Mathf.Abs(verticalInput) > 0.1f)
        {
            Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;
            Vector3 targetPosition = transform.position + movementDirection * movementSpeed * Time.deltaTime;
            navMeshAgent.SetDestination(targetPosition);
            lastTargetPosition = targetPosition;
        }
    }
}