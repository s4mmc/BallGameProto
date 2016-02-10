using UnityEngine;
using System.Collections;

public class BallManager : MonoBehaviour {

    public static bool playerHasBall, aiHasBall;
    public Transform ball;

	// Use this for initialization
	void Start ()
    {
	

        
	}
	
	// Update is called once per frame
	void Update () {
        Debug.Log("playerHas: " + playerHasBall);
        Debug.Log("aiHas: " + aiHasBall);
    }


}
