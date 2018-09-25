using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ray : MonoBehaviour {

    public GameObject anchor;
    private LineRenderer line;
    
    // Use this for initialization
	void Start () {
        GameObject go = new GameObject();
        line = go.AddComponent<LineRenderer>();
        line.SetVertexCount(2);
        line.SetWidth(0.01f, 0.01f);
    }
	
	// Update is called once per frame
	void Update () {
        line.SetPosition(0, anchor.transform.position);
        line.SetPosition(1, anchor.transform.position + anchor.transform.forward * 10);
    }
}
