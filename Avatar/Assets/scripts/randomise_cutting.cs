using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class randomise_cutting : MonoBehaviour
{
    public GameObject player_capsule;
    public float pos_z_capsule;

    public GameObject trigger_indicator_false;
    public GameObject trigger_indicator_true;
    public GameObject trigger_indicator_left;
    public GameObject trigger_indicator_right;

    public float gate_pos_z;
    public bool left;
    public bool right;
    public bool True;
    public bool False;



    void Start()
    {
        trigger_indicator_false.SetActive(false);
        trigger_indicator_right.SetActive(false);
        trigger_indicator_left.SetActive(false);
        trigger_indicator_true.SetActive(false);

        gate_pos_z = -2.18f;
    }

    void Update()
    {
        pos_z_capsule = player_capsule.transform.position.z;


        if (pos_z_capsule > -5.3f && pos_z_capsule < gate_pos_z)
        {
            trigger_indicator_false.SetActive(False);
            trigger_indicator_true.SetActive(True);
            trigger_indicator_right.SetActive(right);
            trigger_indicator_left.SetActive(left);
            Debug.Log("forwards");
        }

        else if (pos_z_capsule < -5.3f && pos_z_capsule < gate_pos_z)
        {
            trigger_indicator_false.SetActive(False);
            trigger_indicator_true.SetActive(false);
            trigger_indicator_right.SetActive(false);
            trigger_indicator_left.SetActive(false);
            Debug.Log("stop");
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
