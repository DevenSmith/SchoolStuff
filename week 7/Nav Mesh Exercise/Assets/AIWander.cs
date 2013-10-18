using UnityEngine;
using System.Collections;

public class AIWander : MonoBehaviour {
	
	public float fMaxWalkDistance = 1.0f;
	public Vector3 finalPosition = new Vector3(1.674304f,7.711049f,0.240002f);
	public float fMoveSpeed = 1.0f;
	public NavMeshAgent navAgent;
	//public GameObject target;
	public bool boolhit = false;

	// Use this for initialization
	void Start () {
	//	target.transform.position = finalPosition;
		navAgent.SetDestination(finalPosition);
		//navAgent.SetDestination(finalPosition);
		RandomPosition();
	}
	
	// Update is called once per frame
	void Update () {
		if(Vector3.Distance(transform.position, finalPosition) < 5)
			RandomPosition();
		//target.transform.position = finalPosition;
		navAgent.SetDestination(finalPosition);
		//transform.LookAt(finalPosition);
		//transform.Translate(Vector3.forward * Time.deltaTime * fMoveSpeed );
	
	}
	
	void RandomPosition()
	{

		Vector3 randomDirection = Random.insideUnitSphere * fMaxWalkDistance;	
		randomDirection += transform.position;
		NavMeshHit hit = new NavMeshHit();
		boolhit = NavMesh.SamplePosition(randomDirection, out hit, fMaxWalkDistance+5, 1);
		if(boolhit)
			finalPosition = hit.position;
		//navAgent.SetDestination(finalPosition);
	}
}
