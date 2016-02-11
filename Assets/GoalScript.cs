using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public enum Team
{
    Red,
    Blue
}

public class GoalScript : MonoBehaviour {

    public GameObject ball;
    public Team team;
    public GameManager gm;
    

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            AddGoal();
        }

    }

    void AddGoal()
    {
        if(team == Team.Red)
        {
            gm.redScore += 1;
        }
        else if (team == Team.Blue)
        {
            gm.blueScore += 1;
        }
    }








}// end .cs file
