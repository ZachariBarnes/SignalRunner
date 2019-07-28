using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TubeScript : MonoBehaviour
{
    Rigidbody RG;
    Transform T;
    SphereScript SS;
    public GameObject Node;
    NodeScript NS;
    public float velocity;
    public float resetLength;
    // Use this for initialization
    void Start()
    {
        RG = GetComponent<Rigidbody>();
        T = RG.transform;
        SS = GameObject.FindGameObjectWithTag("Sphere").GetComponent<SphereScript>();
        if (Node != null)
        {
            NS = Node.GetComponent<NodeScript>();
        }
    }



    // Update is called once per frame
    void FixedUpdate()
    {
        velocity = SS.Velocity;
        Vector3 newPos = new Vector3(T.position.x - velocity, 0, 0);
        T.position = newPos;

        //T.up = T.up + (new Vector3(0.01f, 0, 0));
        //T.Translate(new Vector3(0.01f, 0, 0));
        if (T.position.x <= -resetLength)
        {
            T.position = (new Vector3(40, 0, 0));
            SS.Velocity =/*+ velocity+*/(velocity + 0.01f);
            if (Node != null)
            {
                NS.Randomize();
            }
        }

    }
}
