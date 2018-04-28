using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AgentMove : MonoBehaviour {

    //public Transform destination;
    private NavMeshAgent agent;
    public Camera Camera;

	void Start () {
       // Debug.LogError("TEST Start");
        agent = GetComponent<NavMeshAgent>();
      
        //if (destination != null) {
            //agent.SetDestination(destination.position);
        //}
	}
	
	void Update () {
        Debug.LogError("TEST Update");
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
           Debug.LogError("TEST Mouse");
            RaycastHit hit;
            Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                agent.SetDestination (hit.point);
            }
        }
		
	}
}
