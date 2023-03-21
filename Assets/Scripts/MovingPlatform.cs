using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    [SerializeField]
    private WaypointPath _waypointPath;

    [SerializeField]
    private float _speed;


    private int _targetWaypointIndex;

    private Transform _previousWaypoint;
    private Transform _targetWaypoint;

    private float _timeToWaypoint;
    private float _elapsedTime;
    // Start is called before the first frame update
    void Start()
    {
        TargetNextWaypoint();
    }

    // Update is called once per frame

    //FixedUpdate makes it so the platform and player move together
    void FixedUpdate()
    {
        _elapsedTime += Time.deltaTime;
        //Lerp helps the platfrom understand the previous and starting positions
        float elapsedPercentage = _elapsedTime / _timeToWaypoint;
        //This allows for the platform to slowly stop and start at the begining and end of its travel
        elapsedPercentage = Mathf.SmoothStep(0, 1, elapsedPercentage);
        //Position
        transform.position = Vector3.Lerp(_previousWaypoint.position, _targetWaypoint.position, elapsedPercentage);
        //Rotation
        transform.rotation = Quaternion.Lerp(_previousWaypoint.rotation, _targetWaypoint.rotation, elapsedPercentage);

        if (elapsedPercentage >= 1)
        {
            TargetNextWaypoint();
        }
    }

    private void TargetNextWaypoint()
    {
        _previousWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);
        _targetWaypointIndex = _waypointPath.GetNextWaypointIndex(_targetWaypointIndex);
        _targetWaypoint = _waypointPath.GetWaypoint(_targetWaypointIndex);


        _elapsedTime = 0;

        float distanceToWaypoint = Vector3.Distance(_previousWaypoint.position, _targetWaypoint.position);
        _timeToWaypoint = distanceToWaypoint / _speed;
    }

    private void OnTriggerEnter(Collider other)
    {//Allows the player to set off the trigger that the player is on the platform and should work with it
        other.transform.SetParent(transform);
    }

    private void OnTriggerExit(Collider other)
    {//turns the trigger off and lets the platform and player seperate
        other.transform.SetParent(null);
    }
}
