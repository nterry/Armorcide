using UnityEngine;
using System.Collections;
//Note this line, if it is left out, the script won't know that the class 'Path' exists and it will throw compiler errors
//This line should always be present at the top of scripts which use %Pathfinding
using Pathfinding;
public class TestAIMotivator : MonoBehaviour {
	private bool debugMode = true;

	//The point to move to
	public Vector3 targetPosition;

	public Transform nodePrefab;
	
	private Seeker seeker;
	private CharacterController controller;
	
	//The calculated path
	public Path path;
	
	//The AI's speed per second
	public float speed = 100;
	
	//The max distance from the AI to a waypoint for it to continue to the next waypoint
	public float nextWaypointDistance = 3;
	
	//The waypoint we are currently moving towards
	private int currentWaypoint = 1;

	private float rotationFaceErrorMargin = 1.5F;

	private string searchState = "turn";

	private Vector3[] waypoints; 
	
	public void Start () {
		//transform.Rotate(new Vector3(0.0F, -AngleToTarget(waypoints[currentWaypoint]), 0.0F));
		//transform.LookAt(waypoints[currentWaypoint]);
		seeker = GetComponent<Seeker>();
		//controller = GetComponent<CharacterController>();

		//Start a new path to the targetPosition, return the result to the OnPathComplete function
		seeker.StartPath (transform.position,targetPosition, OnPathComplete);

		//waypoints = new[]
		//{
		//	new Vector3(45.0F, transform.position.y, -24.0F),
		//	new Vector3(24.0F, transform.position.y, -1.0F),
		//	new Vector3(-24.0F, transform.position.y, 0.0F),
		//	new Vector3(-45.0F, transform.position.y, -24.0F)
		//};
	}
	
	public void OnPathComplete (Path p) {
		Debug.Log ("Yay, we got a path back. Did it have an error? "+p.error);
		if (!p.error) {
			path = p;
			//Reset the waypoint counter
			//currentWaypoint = 0;
			waypoints = p.vectorPath.ToArray();

			for (int i = 0; i < path.path.Count; i++)
			{
				//Transform node = Instantiate(nodePrefab) as Transform;
				//Int3 pos = path.path[i].position;
				//node.transform.position = new Vector3(pos.x / 1000.0F, pos.y, pos.z / 1000.0F);

				//Debug.Log (string.Format ("Created node at: {0}", node.transform.position));
			}
		}
	}
	
	public void FixedUpdate () {
		Vector3 v;
		if (path == null) {
			//We have no path to move after yet
			return;
		}
		
		if (currentWaypoint > path.vectorPath.Count) {
			Debug.Log ("End Of Path Reached");
			return;
		}

		Vector3 forward = transform.TransformDirection(Vector3.forward) * 10;
		Debug.DrawRay(transform.position, forward, Color.blue);
		if (currentWaypoint <= waypoints.Length)
			v = waypoints[currentWaypoint];
		else
			return;

		Debug.DrawRay(transform.position, v - transform.position, Color.green);

		Vector3 heading = v - transform.position;
		//bool? isClockwiseFromTarget = AngleDir(transform.forward, heading, transform.up);

		Transform foo = Instantiate(nodePrefab) as Transform;
		foo.position = v;



		Debug.Log (AngleToTarget(v));

		switch (searchState)
		{
			case "turn":
				SearchStateTurn(v);
				break;
			case "move":
				SearchStateMove(v);
				break;

		}



		//Direction to the next waypoint
		//Vector3 dir = (path.vectorPath[currentWaypoint]-transform.position).normalized;
		//dir *= speed * Time.fixedDeltaTime;
		//Debug.Log (string.Format ("Moving: {0}", dir));
		//rigidbody.AddForce(dir);
		//controller.SimpleMove (dir);


		//Check if we are close enough to the next waypoint
		//If we are, proceed to follow the next waypoint
		//if (Vector3.Distance (transform.position,path.vectorPath[currentWaypoint]) < nextWaypointDistance) {
		//	currentWaypoint++;
		//	return;
		//}
	}

	public void OnGUI()
	{

	}

	float AngleToTarget(Vector3 target)
	{
		//return Vector3.Angle(transform.forward, (target - transform.position).normalized);
		Vector3 to = (target - transform.position).normalized;
		return Vector2.Angle(new Vector2(transform.forward.x, transform.forward.z), new Vector2(to.x, to.z));
	}

	bool NeedToTurn(Vector3 target)
	{
		bool doTurn = AngleToTarget(target) > rotationFaceErrorMargin + 3;
		if (debugMode) Debug.Log ("Need to turn: " + doTurn + "; Angle to target: " + AngleToTarget(target));
		return doTurn;
	}

	void SearchStateTurn(Vector3 target)
	{
		if (debugMode) Debug.Log ("Turn State");
		
		Vector3 heading = target - transform.position;
		bool? isClockwiseFromTarget = AngleDir(transform.forward, heading, transform.up);

		if (isClockwiseFromTarget.Value && AngleToTarget(target) > rotationFaceErrorMargin)
			transform.Rotate(0.0F, -100.0F * Time.deltaTime, 0.0F);
		else if (!isClockwiseFromTarget.Value && AngleToTarget(target) > rotationFaceErrorMargin)
			transform.Rotate(0.0F, 100.0F * Time.deltaTime, 0.0F);

		if (!NeedToTurn(target)) 
		{
			if (debugMode) Debug.Log ("Switching States: Turn -> Move");
			searchState = "move";
		}
	}

	void SearchStateMove(Vector3 target)
	{

		if (debugMode) 
		{
			Debug.Log ("Move State");
		}

		if (Vector3.Distance (transform.position, target) > nextWaypointDistance)
		{
			if (NeedToTurn(target))
			{
				if (debugMode) Debug.Log ("Switching States: Move -> Turn");
				searchState = "turn";
			}
			else
			{
				//Debug.Log (Vector3.Distance (transform.position, target));
				rigidbody.AddRelativeForce(0.0F, 0.0F, 50.0F);
			}
		}
		else
		{
			if (debugMode) Debug.Log ("Switching States: Move -> Turn");
			currentWaypoint += 2;
			searchState = "turn";
		}
	}

	bool? AngleDir(Vector3 fwd, Vector3 targetDir, Vector3 up) {
		Vector3 perp = Vector3.Cross(fwd, targetDir);
		float dir = Vector3.Dot(perp, up);
		
		if (dir > 0f) {
			return false;
		} else if (dir < 0f) {
			return true;
		} else {
			return null;
		}
	}
} 
