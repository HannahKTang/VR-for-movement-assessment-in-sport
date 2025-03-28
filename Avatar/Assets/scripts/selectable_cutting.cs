using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class selectable_cutting : MonoBehaviour
{
    public CharacterController controller;
    public Animator anim;
    private Rigidbody m_Rigidbody;
    private float playerSpeed;
    public GameObject avatar;
    private bool isrunning;
    public float avatar_speed;

    public GameObject player_capsule;
    private float pos_z_capsule;
    private float pos_x_capsule;

    public GameObject trigger_indicator_stop;
    public GameObject trigger_indicator_forwards;
    public GameObject trigger_indicator_left;
    public GameObject trigger_indicator_right;
    public GameObject trigger_indicator_diag_left;
    public GameObject trigger_indicator_diag_right;

    public float gate_pos_z;
    public bool left;
    public bool right;
    private bool forwards;
    public bool RESET;
    private bool stop;
    public GameObject block_left;
    public GameObject block_right;
    public float Player_initial_X;
    public float Player_initial_Y;
    public float Player_initial_Z;

    public float side_buffer;

    void Start()
    {
        m_Rigidbody = avatar.GetComponent<Rigidbody>();
        playerSpeed = 20.0f;
        avatar_speed = 0.1f;

        trigger_indicator_stop.SetActive(false);
        trigger_indicator_right.SetActive(false);
        trigger_indicator_left.SetActive(false);
        trigger_indicator_forwards.SetActive(true);
        trigger_indicator_diag_right.SetActive(false);
        trigger_indicator_diag_left.SetActive(false);

        block_left.SetActive(false);
        block_right.SetActive(false);

        left = true;
        right = false;
        forwards = true;
        stop = false;
        RESET = false;

        Player_initial_X = -0.253f;
        Player_initial_Y = 0.88f;
        Player_initial_Z = 1.39f;

        side_buffer = 0.15f;

        player_capsule.transform.position = new Vector3(Player_initial_X, Player_initial_Y, Player_initial_Z);

        gate_pos_z = -2.18f;
    }

    void Update()
    {
        pos_x_capsule = player_capsule.transform.position.x;
        pos_z_capsule = player_capsule.transform.position.z;

        // PUBLIC BOOL CONTROL
        if (left == true)
        {
            right = false;
            forwards = false;
            stop = false;

            if (stop == true)
            {
                left = false;
                right = false;
                forwards = false;
                stop = false;
            }
        }

        if (right == true)
        {
            left = false;
            forwards = false;
            stop = false;

            if (stop == true)
            {
                left = false;
                right = false;
                forwards = false;
                stop = false;
            }
        }

        if (forwards == true)
        {
            left = false;
            right = false;
            stop = false;

            if (stop == true)
            {
                left = false;
                right = false;
                forwards = false;
                stop = false;
            }
        }

        if (stop == true)
        {
            left = false;
            right = false;
            forwards = false;
        }

        if (RESET == true)
        {
            Application.LoadLevel(0);
        }

        // STOP
        if (pos_z_capsule < -6.5f)
        {
            trigger_indicator_stop.SetActive(true);
            trigger_indicator_forwards.SetActive(false);
            trigger_indicator_right.SetActive(false);
            trigger_indicator_left.SetActive(false);
            trigger_indicator_diag_right.SetActive(false);
            trigger_indicator_diag_left.SetActive(false);
            stop = true;
        }

        // BLOCK LEFT
        if (pos_z_capsule < -4.26f && left == true)
        {
            block_left.SetActive(true);
            block_right.SetActive(false);
            trigger_indicator_stop.SetActive(false);
            trigger_indicator_forwards.SetActive(false);
            trigger_indicator_right.SetActive(true);
            trigger_indicator_left.SetActive(false);
            trigger_indicator_diag_right.SetActive(false);
            trigger_indicator_diag_left.SetActive(false);



            // STOP
            if (pos_z_capsule < -6.5f)
            {
                trigger_indicator_stop.SetActive(true);
                trigger_indicator_forwards.SetActive(false);
                trigger_indicator_right.SetActive(false);
                trigger_indicator_left.SetActive(false);
                trigger_indicator_diag_right.SetActive(false);
                trigger_indicator_diag_left.SetActive(false);
                stop = true;
            }
        }

        // CHARACTER CONTROL
        if (pos_z_capsule < -2.69f)
        {
            anim.SetBool("run", true);

            if (avatar.transform.position.z > -6.3f)
            {
                anim.SetBool("run", false);
                avatar_speed = 0.0f;
                playerSpeed = 0.0f;
            }
            Vector3 move = new Vector3(0.0f, 0, avatar_speed);
            // ************************************************************************************************
            controller.Move(move * Time.deltaTime * playerSpeed);
            if (move != Vector3.zero)
            {
                avatar.transform.forward = move;
            }
            // ************************************************************************************************
        }

        // BLOCK RIGHT
        if (pos_z_capsule < -4.26f && right == true)
        {
            block_left.SetActive(false);
            block_right.SetActive(true);
            trigger_indicator_stop.SetActive(false);
            trigger_indicator_forwards.SetActive(false);
            trigger_indicator_right.SetActive(false);
            trigger_indicator_left.SetActive(true);
            trigger_indicator_diag_right.SetActive(false);
            trigger_indicator_diag_left.SetActive(false);


            // STOP
            if (pos_z_capsule < -6.5f)
            {
                trigger_indicator_stop.SetActive(true);
                trigger_indicator_forwards.SetActive(false);
                trigger_indicator_right.SetActive(false);
                trigger_indicator_left.SetActive(false);
                trigger_indicator_diag_right.SetActive(false);
                trigger_indicator_diag_left.SetActive(false);
                stop = true;
            }
        }

        // APPROACH DIRECTIONS
        // FORWARDS
        if (pos_z_capsule > -4.26f && pos_x_capsule > (Player_initial_X - side_buffer) && pos_x_capsule < (Player_initial_X + side_buffer))
        {
            trigger_indicator_forwards.SetActive(true);
            trigger_indicator_diag_right.SetActive(false);
            trigger_indicator_diag_left.SetActive(false);
            Debug.Log("forwards");


        }

        // LEFT DIAG
        else if (pos_z_capsule > -4.26f && pos_x_capsule < (Player_initial_X - side_buffer))
        {
            trigger_indicator_forwards.SetActive(false);
            trigger_indicator_diag_right.SetActive(false);
            trigger_indicator_diag_left.SetActive(true);
            Debug.Log("left");
        }

        // RIGHT DIAG
        else if (pos_z_capsule > -4.26f && pos_x_capsule > (Player_initial_X + side_buffer))
        {
            trigger_indicator_forwards.SetActive(false);
            trigger_indicator_diag_right.SetActive(true);
            trigger_indicator_diag_left.SetActive(false);
            Debug.Log("right");
        }



        else
        {
            trigger_indicator_forwards.SetActive(false);
            trigger_indicator_diag_right.SetActive(false);
            trigger_indicator_diag_left.SetActive(false);
        }
    }
}
      