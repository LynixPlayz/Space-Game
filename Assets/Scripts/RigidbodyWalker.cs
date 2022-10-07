using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(CapsuleCollider))]
public class RigidbodyWalker : MonoBehaviour
{

    public float speed = 5.0f;
    public bool canJump = true;
    public float jumpHeight = 2.0f;
    public Camera playerCamera;
    public float lookSpeed = 2.0f;
    public float lookXLimit = 60.0f;
    public float debug;
    public GameObject player;
    public float timesSpeed = 1.0f;
    public float sprintSpeed;
    public bool sprinting;
    public Quaternion deltaRotation;


    public bool grounded = false;
    Rigidbody r;
    public Vector2 rotation = Vector2.zero;
    float maxVelocityChange = 10.0f;

    void Awake()
    {
        r = GetComponent<Rigidbody>();
        r.freezeRotation = true;
        r.useGravity = false;
        r.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;
        rotation.y = transform.eulerAngles.y;

        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }
    void Update()
    {
        // Player and Camera rotation
        rotation.x += -Input.GetAxis("Mouse Y") * lookSpeed;
        rotation.x = Mathf.Clamp(rotation.x, -lookXLimit, lookXLimit);
        playerCamera.transform.localRotation = Quaternion.Euler(rotation.x, 0, 0);
        Quaternion localRotation = Quaternion.Euler(0f, 0f, 0f);
        if (player.GetComponent<ChildTest>().controlType != true)
        {
            localRotation = Quaternion.Euler(0f, Input.GetAxis("Horizontal") * lookSpeed, 0f);
        }
        else
        {
            localRotation = Quaternion.Euler(0f, Input.GetAxis("Mouse X") * lookSpeed, 0f);
        }
        debug = debug / 2.0f;
        transform.rotation *= localRotation;
    }

    void FixedUpdate()
    {
        if(Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)){
            if (sprinting)
            {
                if (timesSpeed <= (2.50f + sprintSpeed)){
                    timesSpeed *= 1.0005f; 
                }
            }
            else
            {
                if (timesSpeed <= (2.50f)){
                    timesSpeed = timesSpeed * 1.0005f; 
                }
            }
        }
        else {
            if (timesSpeed >= 2){
                timesSpeed /= 1.2f;
            }
        }
        if (timesSpeed <= 1){
            timesSpeed = 1;
        }

        if (Input.GetKey(KeyCode.LeftShift)) {
            if (sprinting == false){
                timesSpeed += sprintSpeed;
                sprinting = true;
            }
        }
        else
        {
            if(sprinting == true){
                timesSpeed -= sprintSpeed;
            }
        }

        if (grounded){
            if (player.GetComponent<ChildTest>().controlType != true)
            {
                // Calculate how fast we should be moving
                Vector3 forwardDir = Vector3.Cross(transform.up, -playerCamera.transform.right).normalized;
                //Vector3 rightDir = Vector3.Cross(transform.up, playerCamera.transform.forward).normalized;
                Vector3 targetVelocity = (forwardDir * Input.GetAxis("Vertical")) * (speed * timesSpeed);
                //Vector3 targetRotation = new Vector3(0f, Input.GetAxis("Horizontal") * lookSpeed * 100, 0f);


                Vector3 velocity = transform.InverseTransformDirection(r.velocity);
                velocity.y = 0;
                velocity = transform.TransformDirection(velocity);
                Vector3 velocityChange = transform.InverseTransformDirection(targetVelocity - velocity);
                velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
                velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
                velocityChange.y = 0;
                velocityChange = transform.TransformDirection(velocityChange);

                //deltaRotation = Quaternion.Euler(targetRotation * Time.fixedDeltaTime);

                Debug.Log("Rotation 1");
                r.AddForce(velocityChange, ForceMode.VelocityChange);
                ///r.MoveRotation((r.rotation * deltaRotation));

                if (Input.GetButton("Jump") && canJump)
                {
                    r.AddForce(transform.up * jumpHeight, ForceMode.VelocityChange);
                }
            }
            else
            {
                // Calculate how fast we should be moving
                Vector3 forwardDir = Vector3.Cross(transform.up, -playerCamera.transform.right).normalized;
                Vector3 rightDir = Vector3.Cross(transform.up, playerCamera.transform.forward).normalized;
                Vector3 targetVelocity = (forwardDir * Input.GetAxis("Vertical") + rightDir * Input.GetAxis("Horizontal")) * speed;

                Vector3 velocity = transform.InverseTransformDirection(r.velocity);
                velocity.y = 0;
                velocity = transform.TransformDirection(velocity);
                Vector3 velocityChange = transform.InverseTransformDirection(targetVelocity - velocity);
                velocityChange.x = Mathf.Clamp(velocityChange.x, -maxVelocityChange, maxVelocityChange);
                velocityChange.z = Mathf.Clamp(velocityChange.z, -maxVelocityChange, maxVelocityChange);
                velocityChange.y = 0;
                velocityChange = transform.TransformDirection(velocityChange);

                r.AddForce(velocityChange, ForceMode.VelocityChange);

                if (Input.GetButton("Jump") && canJump)
                {
                    r.AddForce(transform.up * jumpHeight, ForceMode.VelocityChange);
                }
            }
        }
        if (player.GetComponent<ChildTest>().controlType != true)
        {
            Vector3 targetRotation = new Vector3(0f, Input.GetAxis("Horizontal") * lookSpeed * 100, 0f);
            deltaRotation = Quaternion.Euler(targetRotation * Time.fixedDeltaTime);
            r.MoveRotation((r.rotation * deltaRotation));
        }
        grounded = false;
    }

    void OnCollisionStay()
    {
        grounded = true;
    }
}
