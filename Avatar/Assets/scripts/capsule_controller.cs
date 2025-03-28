using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class capsule_controller : MonoBehaviour
{
    public Vector2 turn_caps;
    public float sensitivity_caps = .5f;
    //private CharacterController controller = null;
    public float moveSpeed = 3.0f;

    public float speed = 0.003f;
    private float translation;
    private float straffe;

    Rigidbody m_Rigidbody;
    /*
        void Start()
        {
           // controller = GetComponent<CharacterController>();
            m_Rigidbody = GetComponent<Rigidbody>();
        }


        void FixedUpdate()
        {
            // Rotation
            turn_caps.y += Input.GetAxis("Mouse X") * sensitivity_caps;
            transform.localRotation = Quaternion.Euler(0, turn_caps.y, 0);

            // Translation
            Vector3 m_Input = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
            m_Rigidbody.MovePosition(transform.position + m_Input * Time.deltaTime * moveSpeed);
        }
        */
    void FixedUpdate()
    {
        // Rotation
        turn_caps.y += Input.GetAxis("Mouse X") * sensitivity_caps;
        transform.localRotation = Quaternion.Euler(0, 180+turn_caps.y, 0);

        // Translation
        translation = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        straffe = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(straffe, 0, translation);
    }
}
