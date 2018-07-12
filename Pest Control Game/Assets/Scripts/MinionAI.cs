using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class MinionAI : MonoBehaviour {
	private NavMeshAgent agent;
	private Animator anim;
	public GameObject[] waypoints;
	public int currWaypoint;
	public AIState aiState;
	public GameObject movingWayPoint;
	public VelocityReporter vr;
	public Vector3 velocity;
	public Vector3 pos;
	public Vector3 agentVelocity;
	public float distance;
	public float threshold;
	public float multiplier;
	public float offset;
	public NavMeshHit hit;
	public float agentSpeed;
	public enum AIState
	{
		Patrol,
		//GoToAmmoDepot,
		//AttackPlayerWithProjectile,
		//InterceptPlayer,
		//AttackPlayerWithMelee,
		ChasePlayer
		//TODO more? states…
	};
	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		anim = GetComponent<Animator> ();
		currWaypoint = -1;
		setNextWaypoint ();
		aiState = AIState.Patrol;
		vr = movingWayPoint.GetComponent<VelocityReporter> ();
		velocity = vr.prevVelocity;
		pos = movingWayPoint.transform.position;
		agentSpeed = agent.speed;
	}
	
	// Update is called once per frame
	void Update () {
		velocity = vr.velocity;
		pos = movingWayPoint.transform.position;
		distance = Vector3.Distance(pos,this.transform.position);

		switch (aiState) {
		case AIState.Patrol:
			//if(ammoCount == 0)
			// aiState = AIState.GoToAmmoDepot;
			//else
			// SteerTo(nextWaypoint);
			if (distance < threshold) 
			{
				aiState = AIState.ChasePlayer;
			} else {
				if (agent.remainingDistance <= 1 && !agent.pathPending) {
					setNextWaypoint ();
				}
				anim.SetFloat ("vely", agent.velocity.magnitude / agent.speed);
			}
			break;
		case AIState.ChasePlayer:
			//SteerToClosestAmmoDepot()
			if (NavMesh.Raycast (this.transform.position, this.transform.position + agentVelocity*multiplier, out hit, 0)) {
				agent.speed = 0f;
			} else {
				agent.speed = agentSpeed;
			}
			if (distance >= threshold) 
			{
				aiState = AIState.Patrol;
			}
			else 
			{
				agent.SetDestination (pos + velocity * multiplier);
				anim.SetFloat ("vely", agent.velocity.magnitude / agent.speed);
			}
			break;
			//... TODO handle other states
		default:
			break;
		}

	}

	private void setNextWaypoint() {
		if (waypoints.Length == 0) {
			Debug.Log ("invalid waypoints");
		} else {
			int l = waypoints.Length;
			currWaypoint = currWaypoint + 1;
			if (currWaypoint >= l) {
				currWaypoint = 0;
			}
			agent.SetDestination (waypoints [currWaypoint].transform.position);
		}
	}
}
