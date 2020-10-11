using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float speed;
    public float forceJump;
    public float sensitivity;
    private float headRotation;
    public bool isGrounded;
    private bool stopMove;
    
    private Rigidbody rb;
    public Transform cam;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        rb = GetComponent<Rigidbody>();
        stopMove = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (!stopMove)
        {
            float x = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
            float y = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime * -1f;
            transform.Rotate(0f, x, 0f);
            headRotation += y;
            headRotation = Mathf.Clamp(headRotation, -90, 90);
            cam.localEulerAngles = new Vector3(headRotation, 0f, 0f);

            x = Input.GetAxisRaw("Horizontal");
            float z = Input.GetAxisRaw("Vertical");

            Vector3 moveBy = transform.right * x + transform.forward * z;
            rb.MovePosition(transform.position + moveBy.normalized * speed * Time.deltaTime);

            if (Input.GetKey(KeyCode.Space) && isGrounded)
            {
                rb.AddForce(Vector3.up * forceJump * Time.deltaTime, ForceMode.Impulse);
            }
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
