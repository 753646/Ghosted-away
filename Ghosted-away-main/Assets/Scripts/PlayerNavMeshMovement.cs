using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMeshMovement : MonoBehaviour
{
    public float movementSpeed = 5f;
    private NavMeshAgent navMeshAgent;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity, NavMesh.AllAreas))
            {
                navMeshAgent.SetDestination(hit.point);
            }
        }

        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        if (movementDirection != Vector3.zero)
        {
            Vector3 targetPosition = transform.position + movementDirection * movementSpeed * Time.deltaTime;
            navMeshAgent.SetDestination(targetPosition);
        }
    }
}