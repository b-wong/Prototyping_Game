using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public float speed;
    public float timeBetweenMove;

    public Transform pathHolder;

    public Transform[] path;

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

    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
            //if (pausePlatform == false)
            //    pausePlatform = true;
            //else pausePlatform = false;
            StartCoroutine(PlatformPauseTimer(PauseDuration));
    }



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

    IEnumerator Move(Vector3 destination, float speed)
    {
        while (transform.position != destination)
        {
            transform.position = Vector3.MoveTowards(transform.position, destination, speed * Time.deltaTime);
            yield return null;
        }
    }

    IEnumerator PlatformPauseTimer(float pauseDuration)
    {
        pausePlatform = true;
        while (pausePlatform)
        {
            //Debug.Log(timer);
            yield return new WaitForSeconds(pauseDuration);
            pausePlatform = false;
        }
    }
}
