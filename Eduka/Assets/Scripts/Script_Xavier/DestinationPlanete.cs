using UnityEngine;
using System.Collections;


public class DestinationPlanete : MonoBehaviour {

	public Transform targetLune;
	public Transform targetMars;
	NavMeshAgent agent;
	public bool testActive;

	//public AnimationClip anim;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent>();
		testActive = false;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey("space")){ //Input.GetKey(KeyCode.X);
			testActive = true;
		}
		if (testActive == true){
			//agent.SetDestination(targetLune.position); // Lune 
			agent.SetDestination(targetMars.position);	// Mars		
			//Animation.Play("Vibration_deplacement");
		}
	}
}
