using System.Collections;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pathHolder;

    public float speed;
    public float timeBetweenMove;

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
            Vector3 step = Vector3.ClampMagnitude(targetWayPoint - transform.position, speed * Time.smoothDeltaTime);

            body.velocity = step / Time.deltaTime;

            distanceTravelled += step.magnitude;

            Debug.LogFormat("DistanceTravelled: {0}", distanceTravelled);

            if (transform.position == targetWayPoint)
            {
                targetWayPointIndex = (targetWayPointIndex + 1) % waypoints.Length;
                targetWayPoint = waypoints[targetWayPointIndex];
                
                distanceToTravel = (targetWayPoint - transform.position).magnitude;
                distanceTravelled = 0f;
                
                body.velocity = Vector2.zero;

                Debug.LogFormat("DistanceTOTravelled----------------------------------: {0}", distanceToTravel);

                yield return new WaitForSeconds(timeBetweenMove);
            }
            yield return new WaitForFixedUpdate();
            
        }
    }
}
