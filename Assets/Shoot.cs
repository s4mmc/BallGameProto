using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    GameObject ball;
    Transform pos;
    public float distance, force;
    RaycastHit hit;
    PlayerControlsG2 pc;


    // Use this for initialization
    void Start () {
        ball = GameObject.FindGameObjectWithTag("Ball");
        pos = gameObject.transform;
        pc = GetComponentInParent<PlayerControlsG2>();
    }
	
	// Update is called once per frame
	void Update () {
        Shooting();


    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {

        }
    }

    void Shooting()
    {

        

                //Striker Shooting V1
                // Fire 1 pulls ball to player
                if (Input.GetButtonDown("Fire1"))
                {

                    Vector3 dir = (transform.position - ball.transform.position).normalized;


                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

                    //if (Physics.Raycast(transform.position, dir, out hit, distance))
                    if (Physics.Raycast(ray, out hit))
                    {

                        //Debug.DrawLine(transform.position, hit.point);

                        Debug.DrawRay(transform.position, -dir, Color.red, distance);
                        //Debug.Log("Hit: " + hit.collider.gameObject.name);

                        if (hit.collider.gameObject.tag == "Ball")
                        {
                            //ball.GetComponent<Rigidbody>().AddExplosionForce(force, hit.point, 2f);
                            ball.GetComponent<Rigidbody>().AddForce(dir * 75f, ForceMode.VelocityChange);
                            Debug.Log("Hit Ball");
                        }
                    }

                }
        

                // Striker Fire 2, Hits ball away from player.

        if (Input.GetButtonDown("Fire2"))
        {

            Vector3 dir = (transform.position - ball.transform.position).normalized;


            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //if (Physics.Raycast(transform.position, dir, out hit, distance))
            if (Physics.Raycast(ray, out hit))
            {

                //Debug.DrawLine(transform.position, hit.point);

                Debug.DrawRay(transform.position, -dir, Color.red, distance);
                //Debug.Log("Hit: " + hit.collider.gameObject.name);

                if (hit.collider.gameObject.tag == "Ball")
                {
                    //ball.GetComponent<Rigidbody>().AddExplosionForce(force, hit.point, 2f);
                   ball.GetComponent<Rigidbody>().AddForce(-dir * 150f, ForceMode.VelocityChange);
                    Debug.Log("Hit Ball");
                }
            }
        }




















    }//End of shooting()















}//End of .cs
