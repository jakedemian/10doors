using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour {
    public CharacterController controller;
    public float speed = 12f;
    public float gravity = -9.81f;
    public Transform groundCheck;
    public float groundDistance = 0.4f;
    public LayerMask groundMask;
    public float jumpHeight = 3f;
    public GameObject inputField;

    private bool isGrounded;
    private Vector3 velocity;
    
    void Update() {
        if (Pause.Instance.IsPaused()) return;
        
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0) {
            velocity.y = -2f;
        }
        
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        if (!Mathf.Approximately(x, 0f) && !Mathf.Approximately(z, 0f)) {
            x /= Mathf.Sqrt(2);
            z /= Mathf.Sqrt(2);
        }

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * (speed * Time.deltaTime));

        if (Input.GetButtonDown("Jump") && isGrounded) {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }
}
