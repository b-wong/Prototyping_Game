using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pathHolder;

    public float speed;
    public float timeBetweenMove;

    public float PauseDuration;
    private bool pausePlatform = false;

    Rigidbody2D body;

    Vector2 velocity;

    private void Start()
    {
        body = GetComponent<Rigidbody2D>();

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
        float distanceTravelled = 0f;
        float distanceToTravel;

        transform.position = waypoints[0];

        int targetWayPointIndex = 1;
        Vector3 targetWayPoint = waypoints[targetWayPointIndex];

        distanceToTravel = (targetWayPoint - transform.position).magnitude;

        while (true)
        {
            Vector3 step = Vector3.ClampMagnitude(targetWayPoint - transform.position, speed * Time.deltaTime);

            transform.position += step;

            //body.velocity = step / Time.deltaTime;

            distanceTravelled += step.magnitude;
                
            if (/* distanceTravelled >= distanceToTravel*/ transform.position == targetWayPoint)
            {
                targetWayPointIndex = (targetWayPointIndex + 1) % waypoints.Length;
                targetWayPoint = waypoints[targetWayPointIndex];

                //distanceToTravel = (targetWayPoint - transform.position).magnitude;
                //distanceTravelled = 0f;

                yield return new WaitForSeconds(timeBetweenMove);
            }
            yield return null;
        }
    }

    //IEnumerator timer()
    //{
    //    float timer = timeBetweenMove; 
    //    while(timer > 0)
    //    {
    //        timer -= Time.deltaTime;
    //        pausePlatform = true;
    //        yield return null;
    //    }
    //    pausePlatform = false;
    //}

    //IEnumerator PlatformPauseTimer(float pauseDuration)
    //{
    //    pausePlatform = true;
    //    while (pausePlatform)
    //    {
    //        yield return new WaitForSeconds(pauseDuration);
    //        pausePlatform = false;
    //    }
    //}

    //public void Toggle()
    //{
    //    StartCoroutine(PlatformPauseTimer(PauseDuration));
    //}
}
