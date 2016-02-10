using UnityEngine;
using System.Collections;

public class BallScript : MonoBehaviour {

    Rigidbody rb;
    public Transform playerBallHold;

    void Awake()
    {
        
    }

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        rb = GetComponent<Rigidbody>();

	}
	
	// Update is called once per frame
	void Update () {
        transform.localScale = Vector3.one;
        if (BallManager.playerHasBall == true)
        {
            transform.parent = playerBallHold;
            transform.position = playerBallHold.position;
            
        }

	}

    void FixedUpdate()
    {

    }


    public void Shoot(float speed)
    {
        transform.parent = null;
        rb.AddForce(Vector3.forward * speed);
    }


    void OnCollisionEnter(Collision coll)
    {
      /*  if(coll.gameObject.tag == "Player")
        {
            for (int i = 0; i < coll.contacts.Length; i++)
            {
                if(coll.contacts[i].thisCollider.gameObject.tag == "Player")
                {
                    rb.velocity = coll.contacts[i].normal * 10f;
                }
                i++;
            }
            
            
        }*/
    }
}
