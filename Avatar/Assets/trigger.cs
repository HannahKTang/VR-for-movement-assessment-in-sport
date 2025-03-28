using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trigger : MonoBehaviour
{
    public GameObject player_capsule;
    public float pos_z_capsule;
    public float pos_x_capsule;
    public GameObject trigger_indicator_false;
    public GameObject trigger_indicator_true;
    public GameObject trigger_indicator_left;
    public GameObject trigger_indicator_right;
    public float left_dist;
    public float right_dist;
    public float centre_dist;
    public float gate_pos_z;

    void Start()
    {
        trigger_indicator_false.SetActive(false);
        trigger_indicator_right.SetActive(false);
        trigger_indicator_left.SetActive(false);
        trigger_indicator_true.SetActive(false);
        centre_dist = 0.1f;
        right_dist = 0.5f;
        gate_pos_z = -2.18f;
    }

    void Update()
    {
        pos_z_capsule = player_capsule.transform.position.z;
        pos_x_capsule = player_capsule.transform.position.x;

        if (pos_z_capsule > -5.3f && pos_z_capsule < gate_pos_z && pos_x_capsule > centre_dist && pos_x_capsule < right_dist)
        {
            trigger_indicator_false.SetActive(false);
            trigger_indicator_true.SetActive(true);
            trigger_indicator_right.SetActive(false);
            trigger_indicator_left.SetActive(false);
            Debug.Log("forwards");
        }

        else if (pos_z_capsule > -5.3f && pos_z_capsule < gate_pos_z && pos_x_capsule <= centre_dist)
        {
            trigger_indicator_false.SetActive(false);
            trigger_indicator_true.SetActive(false);
            trigger_indicator_right.SetActive(true);
            trigger_indicator_left.SetActive(false);
            Debug.Log("right");
        }

        else if (pos_z_capsule > -5.3f && pos_z_capsule < gate_pos_z && pos_x_capsule >= right_dist)
        {
            trigger_indicator_false.SetActive(false);
            trigger_indicator_true.SetActive(false);
            trigger_indicator_right.SetActive(false);
            trigger_indicator_left.SetActive(true);
            Debug.Log("left");
        }

        else if (pos_z_capsule < -5.3f && pos_z_capsule < gate_pos_z)
        {
            trigger_indicator_false.SetActive(true);
            trigger_indicator_true.SetActive(false);
            trigger_indicator_right.SetActive(false);
            trigger_indicator_left.SetActive(false);
            Debug.Log("stop");
        }

        else if (pos_z_capsule > gate_pos_z)
        {
            trigger_indicator_false.SetActive(false);
            trigger_indicator_true.SetActive(false);
            trigger_indicator_right.SetActive(false);
            trigger_indicator_left.SetActive(false);
            Debug.Log("no trigger");
        }

        else
        {
            trigger_indicator_false.SetActive(false);
            trigger_indicator_true.SetActive(false);
            trigger_indicator_right.SetActive(false);
            trigger_indicator_left.SetActive(false);
            Debug.Log("no trigger");
        }

    }
}
