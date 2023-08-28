using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] public GameObject[] waypoints;
    private int currentWaypoint = 0;

    [SerializeField] private float speed = 2f;

    private void Start()
    {
        //for (int i = 0; i < waypoints.Length; i++)
        //    Debug.Log(waypoints[i]);
    }
    private void Update()
    {
        if (Vector2.Distance(waypoints[currentWaypoint].transform.position, transform.position) < .1f)
        {
            currentWaypoint++;
            if (currentWaypoint >= waypoints.Length)
                currentWaypoint = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].transform.position, Time.deltaTime * speed);
    }
}
