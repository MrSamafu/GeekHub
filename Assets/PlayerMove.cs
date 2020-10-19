using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed = 12f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    public float sensitivity;
    private float headRotation;
    public bool isGround;
    private bool stopMove;

    private Vector3 velocity;

    private CharacterController controller;
    public Transform cam;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        stopMove = false;
        controller = GetComponent<CharacterController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        isGround = controller.isGrounded;
        if (!stopMove)
        {
            float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime * -1f;
            transform.Rotate(0f, x, 0f);
            headRotation += y;
            headRotation = Mathf.Clamp(headRotation, -90, 90);
            cam.localEulerAngles = new Vector3(headRotation, 0f, 0f);

            if(isGround && velocity.y <= 0)
            {
                velocity.y = -2f;
            }

            x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            Vector3 move = transform.right * x + transform.forward * z;
            controller.Move(move * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.Space) && isGround)
            {
                velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
            }

            velocity.y += gravity * Time.deltaTime;
            controller.Move(velocity * Time.deltaTime);

        }
        if (Input.GetKeyDown(KeyCode.Return))
        {
            if (Cursor.visible)
            {
                Cursor.lockState = CursorLockMode.Locked;
                Cursor.visible = false;
                GetComponent<PlayerShoot>().Send();
                stopMove = false;
            }
            else
            {
                Cursor.lockState = CursorLockMode.None;
                Cursor.visible = true;
                stopMove = true;
            }


        }
    }
}
