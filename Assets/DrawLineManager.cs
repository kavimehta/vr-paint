using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineManager : MonoBehaviour {

    public Material lmat;
    public OVRInput.Controller device;
    private MeshLineRenderer currLine;
    private int numClicks = 0;

	// Use this for initialization
	void Start () {
    }
	
	// Update is called once per frame
	void Update () {
        if (OVRInput.GetDown(OVRInput.RawButton.RIndexTrigger, device)) { //initial press
            GameObject go = new GameObject();
            go.AddComponent<MeshFilter>();
            go.AddComponent<MeshRenderer>();
            currLine = go.AddComponent<MeshLineRenderer>();
            currLine.lmat = new Material(lmat);
            currLine.setWidth(.1f);
        } else if (OVRInput.Get(OVRInput.RawButton.RIndexTrigger, device)) { //held down
            currLine.AddPoint(OVRInput.GetLocalControllerPosition(device));
            numClicks++;
        } else if (OVRInput.GetUp(OVRInput.RawButton.RIndexTrigger, device)) { //release
            numClicks = 0;
            currLine = null;
        }

        if (currLine != null) {
            currLine.lmat.color = ColorManager.Instance.GetCurrentColor();
        }
	}
}
