using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NodeScript : MonoBehaviour {
    public GameObject[] Icons;
    public int currentIcon;

	// Use this for initialization
	void Start () {
        Randomize();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

   public void Randomize()
    {
        foreach(GameObject Icon in Icons)
        {
            Icon.SetActive(false);
        }
        int i = Random.Range(0, 4);
        Icons[i].SetActive(true);
        currentIcon = i;
    }

}
