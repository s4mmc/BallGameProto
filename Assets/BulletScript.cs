using UnityEngine;
using System.Collections;

public class BulletScript : MonoBehaviour {

    Rigidbody rb;

	// Use this for initialization
	void Start () {

        rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {

        rb.AddForce(Vector3.forward * 25f);

	}

    void OnCollisionEnter(Collision other)
    {
        Vector3 point = other.contacts[1].point;
        if(other.transform.tag == "Player")
        {
            other.rigidbody.AddExplosionForce(25f, point, 2f);
        }
        else if (other.transform.tag == "AI")
        {
            other.rigidbody.AddExplosionForce(25f, point, 2f);
        }
        else if (other.transform.tag == "Ball")
        {
            other.rigidbody.AddExplosionForce(25f, point, 2f);
        }
        else if (other.transform.tag == "Wall")
        {
            other.rigidbody.AddExplosionForce(25f, point, 2f);
        }
    }
}
