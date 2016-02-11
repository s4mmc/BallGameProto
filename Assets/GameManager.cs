using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameManager : MonoBehaviour {

    public int redScore, blueScore;
    public Text redScoreTxt, blueScoreTxt;

    // Use this for initialization
    void Start () {

        redScore = 0;
        blueScore = 0;

	}
	
	// Update is called once per frame
	void Update () {

        SetScore();

    }

    void SetScore()
    {
        redScoreTxt.text = redScore.ToString();
        blueScoreTxt.text = blueScore.ToString();
    }
}
