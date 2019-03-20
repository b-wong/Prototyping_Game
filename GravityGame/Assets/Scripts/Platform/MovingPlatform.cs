using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour, IToggleable
{
    public Transform pathHolder;

    public float speed;
    public float timeBetweenMove;

    public float PauseDuration;
    private bool pausePlatform = false;

    private void Start()
    {
        Vector3[] waypoints = new Vector3[pathHolder.childCount];
        for(int i = 0; i < waypoints.Length; i++)
        {
            waypoints[i] = pathHolder.GetChild(i).position;
        }

        StartCoroutine(FollowPath(waypoints));
    }

    //goes from waypoint to waypoint
    IEnumerator FollowPath(Vector3[] waypoints)
    {
        transform.position = waypoints[0];

        int targetWayPointIndex = 1;
        Vector3 targetWayPoint = waypoints[targetWayPointIndex];

        while (true)
        {
            if (!pausePlatform)
            {
                transform.position = Vector3.MoveTowards(transform.position, targetWayPoint, speed * Time.deltaTime);
                if (transform.position == targetWayPoint)
                {
                    targetWayPointIndex = (targetWayPointIndex + 1) % waypoints.Length;
                    targetWayPoint = waypoints[targetWayPointIndex];
                    yield return new WaitForSeconds(timeBetweenMove);
                }
            }
            yield return null;
        }
    }

    IEnumerator PlatformPauseTimer(float pauseDuration)
    {
        pausePlatform = true;
        while (pausePlatform)
        {
            yield return new WaitForSeconds(pauseDuration);
            pausePlatform = false;
        }
    }

    public void Toggle()
    {
        StartCoroutine(PlatformPauseTimer(PauseDuration));
    }
}
