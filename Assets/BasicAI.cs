using UnityEngine;
using System.Collections;

public class BasicAI : MonoBehaviour {

    public Transform ball, player, goal;
    NavMeshAgent navAgent;

	// Use this for initialization
	void Start ()
    {
        navAgent = GetComponent<NavMeshAgent>();

        navAgent.SetDestination(ball.position);

	}
	
	// Update is called once per frame
	void Update () {

        if(BallManager.aiHasBall == false)
        {
            navAgent.SetDestination(ball.position);
        }
        else
        {
            navAgent.SetDestination(goal.position);
        }
	
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Debug.Log("BALL HIT");
            BallManager.aiHasBall = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            Debug.Log("BALL HIT");
            BallManager.aiHasBall = false;
        }
    }
}
