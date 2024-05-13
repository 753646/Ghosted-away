using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavMeshMovement : MonoBehaviour
{
    public float movementSpeed = 5f; // Adjustable movement speed

    private NavMeshAgent navMeshAgent; // Reference to the NavMeshAgent component

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>(); // Get reference to the NavMeshAgent component attached to this GameObject
    }

    void Update()
    {
        // Check if the player has clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Create a ray from the camera to the mouse position
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray hits the NavMesh
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, NavMesh.AllAreas))
            {
                // Move the player to the clicked position
                navMeshAgent.SetDestination(hit.point);
            }
        }

        // Check for keyboard input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Combine the keyboard input to get the movement direction
        Vector3 movementDirection = new Vector3(horizontalInput, 0f, verticalInput).normalized;

        // Check if there is any movement input
        if (movementDirection != Vector3.zero)
        {
            // Calculate the target position based on the current position and movement direction
            Vector3 targetPosition = transform.position + movementDirection * movementSpeed * Time.deltaTime;

            // Move the player to the target position
            navMeshAgent.SetDestination(targetPosition);
        }
    }
}