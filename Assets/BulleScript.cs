using UnityEngine;
using System.Collections;


[RequireComponent(typeof(Rigidbody))]
public class BulleScript : MonoBehaviour {

    Rigidbody rb;
    Transform t;
    public float force;
	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
        t = GetComponent<Transform>();
        rb.AddForce(Vector3.forward * force);

    }
	
	// Update is called once per frame
	void Update () {

        rb.AddForce(t.position * force);
        t.localScale += Vector3.one / 10 * Time.deltaTime;


	}
}
