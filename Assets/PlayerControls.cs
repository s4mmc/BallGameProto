using UnityEngine;
using System.Collections;

public class PlayerControls : MonoBehaviour
{

    /*public*/
    Rigidbody rb;
    public float speed, runSpeed, sphereRadMin, sphereRadMax, shootSpeed, jumpForce;
    float currentSpeed;
    SphereCollider sph;
    public BallScript bs;
    public GameObject bullet;

    //Vector3 eulerAngleVelocity;

    // Use this for initialization
    void Start()
    {

        rb = GetComponent<Rigidbody>();
        sph = GetComponent<SphereCollider>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftShift))
        {
            currentSpeed = runSpeed;
        }
        else
        {
            currentSpeed = speed;
        }


    }

    void FixedUpdate()
    {
        MovePlayer();
        RotatePlayer();
    }

    void MovePlayer()
    {
        rb.velocity = (Input.GetAxis("Horizontal") * transform.right + Input.GetAxis("Vertical") * transform.forward).normalized * currentSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.VelocityChange);
        }
    }

    void RotatePlayer()
    {
        Quaternion deltaRotation = Quaternion.Euler(Vector3.up * Input.GetAxis("Mouse X"));
        rb.MoveRotation(rb.rotation * deltaRotation);
    }

    void LeftClick()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            shootSpeed += 2f;
            sph.enabled = false;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            bs.Shoot(shootSpeed);
            StartCoroutine(Wait());
            
        }
    }

    void RightClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            Instantiate(bullet, transform.position, Quaternion.identity); 
        }
    }


        void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball")
        {
            Debug.Log("BALL HIT");
            BallManager.playerHasBall = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Ball")
        {
            Debug.Log("BALL HIT");
            BallManager.playerHasBall = false;
        }
    }

    IEnumerator Wait()
    {

        yield return new WaitForSeconds(1.2f);

    }
}
