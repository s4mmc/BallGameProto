using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {

    GameObject ball;
    Transform pos;
    public float distance, force;
    RaycastHit hit;
    PlayerControlsG2 pc;
    public GameObject ballHit, muzFlashB;
    public Transform cam, arm, muzFlashSpwn;


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

        
        if (pc.controlType == ControlType.Striker)
        {
            StrikerShoot();               
        }
        else if (pc.controlType == ControlType.Mid)
        {
            MidShoot();
        }




        



    }//End of shooting()


    void StrikerShoot()
    {
        //Striker Shooting V1
        // Fire 1 pulls ball to player
        if (Input.GetButtonDown("Fire1"))
        {

            Vector3 dir = (transform.position - ball.transform.position).normalized;


            Ray ray = new Ray(cam.position, cam.forward);

            //if (Physics.Raycast(transform.position, dir, out hit, distance))
            if (Physics.Raycast(ray, out hit))
            {

                //Debug.DrawLine(transform.position, hit.point);

                Debug.DrawRay(cam.position, cam.forward, Color.red, distance);
                Instantiate(muzFlashB, muzFlashSpwn.position, muzFlashSpwn.rotation);
                //Debug.Log("Hit: " + hit.collider.gameObject.name);


                if (hit.collider.gameObject.tag == "Ball")
                {
                    //ball.GetComponent<Rigidbody>().AddExplosionForce(force, hit.point, 2f);
                    ball.GetComponent<Rigidbody>().AddForce(dir * 75f, ForceMode.VelocityChange);
                    Debug.Log("Hit Ball");
                    Instantiate(ballHit, hit.point, Quaternion.identity);
                }
            }

        }


        // Striker Fire 2, Hits ball away from player.

        if (Input.GetButtonDown("Fire2"))
        {

            Vector3 dir = (transform.position - ball.transform.position).normalized;


            Ray ray = new Ray(cam.position, cam.forward);

            //if (Physics.Raycast(transform.position, dir, out hit, distance))
            if (Physics.Raycast(ray, out hit))
            {

                //Debug.DrawLine(transform.position, hit.point);

                Debug.DrawRay(cam.position, cam.forward, Color.red, distance);
                Instantiate(muzFlashB, muzFlashSpwn.position, muzFlashSpwn.rotation);
                //Debug.Log("Hit: " + hit.collider.gameObject.name);

                if (hit.collider.gameObject.tag == "Ball")
                {
                    //ball.GetComponent<Rigidbody>().AddExplosionForce(force, hit.point, 2f);
                    ball.GetComponent<Rigidbody>().AddForce(-dir * 150f, ForceMode.VelocityChange);
                    Instantiate(ballHit, hit.point, Quaternion.LookRotation(-dir, -dir));
                    Debug.Log("Hit Ball");
                }
            }
        }
    }//EndStrikerShooting

    void MidShoot()
    {
        //Striker Shooting V1
        // Fire 1 pulls ball to player
        if (Input.GetButtonDown("Fire1"))
        {

            Vector3 dir = (transform.position - ball.transform.position).normalized;


            //Ray ray = new Ray(cam.position, cam.forward);

            //if (Physics.Raycast(transform.position, dir, out hit, distance))
            //if (Physics.Raycast(ray, out hit))
            //{

                //Debug.DrawLine(transform.position, hit.point);

                //Debug.DrawRay(cam.position, cam.forward, Color.red, distance);
                Instantiate(muzFlashB, muzFlashSpwn.position, Quaternion.identity);
                //Debug.Log("Hit: " + hit.collider.gameObject.name);


              //  if (hit.collider.gameObject.tag == "Ball")
                //{
                    //ball.GetComponent<Rigidbody>().AddExplosionForce(force, hit.point, 2f);
                    //ball.GetComponent<Rigidbody>().AddForce(dir * 75f, ForceMode.VelocityChange);
                    //Debug.Log("Hit Ball");
                    //Instantiate(ballHit, hit.point, Quaternion.identity);
               // }
            //}

        }


        // Striker Fire 2, Hits ball away from player.

        if (Input.GetButtonDown("Fire2"))
        {

            //Vector3 dir = (transform.position - ball.transform.position).normalized;


            //Ray ray = new Ray(cam.position, cam.forward);

            //if (Physics.Raycast(transform.position, dir, out hit, distance))
            //if (Physics.Raycast(ray, out hit))
            //{

                //Debug.DrawLine(transform.position, hit.point);

               // Debug.DrawRay(cam.position, cam.forward, Color.red, distance);
                Instantiate(muzFlashB, muzFlashSpwn.position, muzFlashSpwn.rotation);
                //Debug.Log("Hit: " + hit.collider.gameObject.name);

                //if (hit.collider.gameObject.tag == "Ball")
                //{
                    //ball.GetComponent<Rigidbody>().AddExplosionForce(force, hit.point, 2f);
                    //ball.GetComponent<Rigidbody>().AddForce(-dir * 150f, ForceMode.VelocityChange);
                    //Instantiate(ballHit, hit.point, Quaternion.LookRotation(-dir, -dir));
                   // Debug.Log("Hit Ball");
               // }
            //}
        }
    }//EndStrikerShooting









}//End of .cs
