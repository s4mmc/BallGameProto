using UnityEngine;
using System.Collections;

public class IgnoreFloor : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
    Physics.IgnoreLayerCollision(10, 9, true);
}
}
