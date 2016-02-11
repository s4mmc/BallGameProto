using UnityEngine;
using System.Collections;
public enum ControlType
{
    Goalie,
    Defender,
    Mid,
    Striker
}
[RequireComponent(typeof(Rigidbody))]
public class PlayerControlsG2 : MonoBehaviour
{

    public ControlType controlType;
    Rigidbody rb;

    float speed;
    public float yRotation;
    Vector3 movement, vertical, horizontal;
    Transform tr;
    public Transform cam;
    float ySensivity = 5f;
    [SerializeField]
    float inputSpeed;
    // Use this for initialization
    void Start()
    {
        SetStats();
        rb = GetComponent<Rigidbody>();
        tr = GetComponent<Transform>();
        Screen.lockCursor = true;

    }

    // Update is called once per frame
    void Update()
    {
        

         MouseLook();
        
        PerformMove();
    }



    void FixedUpdate()
    {
        
    }



    void MouseLook()
    {
        
        if (Input.GetAxisRaw("Mouse X") != 0f)
        {
            transform.Rotate(Vector3.up * ySensivity * Input.GetAxisRaw("Mouse X"));

            yRotation += Input.GetAxis("Mouse Y") * ySensivity;
            yRotation = Mathf.Clamp(yRotation, -60, 60);

            //cam.localEulerAngles = new Vector3(-yRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);
            cam.rotation = Quaternion.Euler(-yRotation, transform.localEulerAngles.y, transform.localEulerAngles.z);
            //tr.rotation = Quaternion.Euler();
        }
    }

    void SetStats()
    {
        switch (controlType)
        {

            case ControlType.Goalie:
                inputSpeed = 10f;
                break;

            case ControlType.Defender:
                inputSpeed = 10f;
                break;

            case ControlType.Mid:
                inputSpeed = 10f;
                break;

            case ControlType.Striker:
                inputSpeed = 10f;
                break;
        }
    }


    void PerformMove()
    {
        //Mid controls WIP

        //speed seems ok for now at walk
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speed = (inputSpeed + 5f);
        }
        else
        {
            speed = inputSpeed;
        }


        //Movment vector
        //movement = new Vector3(horizontal.x, 0f, vertical.z);

        //Front and back walk vector
        if (Input.GetAxis("Vertical") != 0f)
        {
            //  rb.AddForce(Vector3.forward * speed);
            vertical = transform.forward * Input.GetAxis("Vertical");
        }

        //Strafe vector
        if (Input.GetAxis("Horizontal") != 0f)
        {
            //  rb.AddForce(Vector3.forward * speed);
            horizontal = transform.right * Input.GetAxis("Horizontal");
        }

        //movement applied to transform
        //tr.Translate(movement * speed);
        movement = (vertical + horizontal).normalized * speed;

        if (Input.GetButtonDown("Jump"))
        {
            float y = tr.position.y - 0.7f;
            Vector3 locPos = new Vector3(tr.position.x, y, tr.position.z);
            rb.AddExplosionForce(750f, locPos, 1f);
            Debug.Log("Jumping");
        }

        // Debug.Log(Input.GetAxis("Vertical"));
        // Debug.Log("speed:" + speed);

        if (movement != Vector3.zero)
        {
            //rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
            //tr.Translate(movement * Time.deltaTime);
            tr.position = Vector3.Slerp(tr.position, (tr.position + movement), Time.deltaTime);
        }
    }





}//end of .cs
