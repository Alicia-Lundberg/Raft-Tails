using UnityEngine;

public class FoxController : MonoBehaviour
{
    public float speed = 3.0f;
    public float turnSpeed = 90f;
    public float gravity = 9.81f;

    private CharacterController controller;
    private Vector3 velocity;

    void Start(){
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update(){
        // Keyboard movement for testing
        if (Input.GetKey(KeyCode.W)){ // Move forward
            controller.Move(transform.forward * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S)){ // Move backward
            controller.Move(-transform.forward * speed * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.A)){ // Turn left
            transform.Rotate(Vector3.up, -turnSpeed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D)){ // Turn right
            transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime);
        }

        // Add gravity
        if (!controller.isGrounded){
            velocity.y -= gravity * Time.deltaTime;
        }
        controller.Move(velocity * Time.deltaTime);
    }
}
