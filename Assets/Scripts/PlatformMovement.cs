using UnityEngine;

public class PlatformMovement : MonoBehaviour
{
    public GameObject[] waypoints;
    public float platformSpeed = 2f;

    private int waypointIndex = 0;

    void Update()
    {
        MovePlatform();
    }

    public void MovePlatform()
    {
        if (waypoints.Length == 0) return;

        Transform targetWaypoint = waypoints[waypointIndex].transform;

        
        transform.position = Vector3.MoveTowards(
            transform.position,
            targetWaypoint.position,
            platformSpeed * Time.deltaTime
        );

        
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.001f)
        {
            
            transform.position = targetWaypoint.position;

           
            waypointIndex++;

            if (waypointIndex >= waypoints.Length)
            {
                waypointIndex = 0;
            }
        }
    }
}