using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiMove : MonoBehaviour
{
    [SerializeField]
    Rigidbody rb;
    Vector2 movement;
    public float moveSpeed = 500f;
     
    void Awake ()
    {
        rb = GetComponent<Rigidbody>();
    }
     
    void Update ()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate ()
    {
        Movement();
    }

    void Movement ()
    {
        Vector2 currentPos = rb.position;
        Vector2 adjustedMovement = movement * moveSpeed;
        Vector2 newPos = currentPos + adjustedMovement * Time.fixedDeltaTime;
        rb.MovePosition(newPos);
    }
}
