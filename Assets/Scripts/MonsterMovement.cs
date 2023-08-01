using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterMovement : MonoBehaviour
{
 public float speed = 2f;
    public Transform[] waypoints;
    private int currentWaypointIndex = 0;

    private void Start()
    {
        // Get references to all waypoints in the scene
        waypoints = GameObject.FindGameObjectsWithTag("Waypoint")
            .Select(wp => wp.transform)
            .OrderBy(wp => wp.GetSiblingIndex())
            .ToArray();
    }

    private void Update()
    {
        if (currentWaypointIndex < waypoints.Length)
        {
            // Move towards the current waypoint
            Vector3 targetPosition = waypoints[currentWaypointIndex].position;
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            // Check if the enemy has reached the current waypoint
            if (transform.position == targetPosition)
            {
                // Move to the next waypoint
                currentWaypointIndex++;
            }
        }
        else
        {
            // The enemy has reached the last waypoint (Point B)
            // Destroy the enemy or implement other logic (e.g., base attack)
            Destroy(gameObject);
        }
    }
}
