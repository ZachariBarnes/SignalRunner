using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SphereScript : MonoBehaviour {
    public float Velocity;
    public GameObject[] Colors;
    public Color[] ParticleColors ;
        //{ new Color(64, 171, 48,1), new Color(37, 119, 166,1), new Color(160, 172, 16,1), new Color (150,30,30,1)};
    int color = 0;
    int points;
    Material mat;
    public GameObject GameOver;
    public Text score;
    public GameObject Particle;
    ParticleSystem PS;
    // Use this for initialization
    void Start () {
        Velocity = 0.15f;
        mat = GetComponent<Material>();
        points = 0;
        score.text = points.ToString();
        ParticleColors[0] = Color.green;
        ParticleColors[1] = Color.blue;
        ParticleColors[2] = Color.yellow;
        ParticleColors[3] = Color.red;
        PS = Particle.GetComponent<ParticleSystem>();
        var main = PS.main;
        main.startColor = ParticleColors[color];
    }

    private void OnTriggerExit(Collider collision)
    {
        print("collisiondetected");
        if (collision.gameObject.CompareTag("Node"))
        {
            if(collision.gameObject.GetComponent<NodeScript>().currentIcon == color)
            {
                points++;
                score.text = points.ToString();
                //Gain Points
            }
            else
            {
                //You Lose
                Velocity = 0;
                GameOver.SetActive(true);
            }
        }
    }

    // Update is called once per frame
    void Update () {
        ///Debug.Log("HelloWorld");
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.Space))
        {
            Debug.Log("Right Arrow / D-button / Space pressed");
            Colors[color].SetActive(false);
            color++;
                    if(color > 3)
                    {
                        color = 0;
                    }
            Colors[color].SetActive(true);
            var main = PS.main;
            main.startColor = ParticleColors[color];
        } else if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("Left Arrow / A-button pressed");
            Colors[color].SetActive(false);
            color--;
                    if(color <0)
                    {
                        color = 3;
                    }
            Colors[color].SetActive(true);
            var main = PS.main;
            main.startColor = ParticleColors[color];
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {//Restart
            GameOver.SetActive(false);
            Start();

        }
    }
}
