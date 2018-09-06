using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLineManager : MonoBehaviour {

    public Material lmat;
    public OVRTrackedRemote device;
    private MeshLineRenderer currLine;
    private int numClicks = 0;

	// Use this for initialization
	void Start () {
        device = GetComponent<RTrackedRemote>();
    }
	
	// Update is called once per frame
	void Update () {
        device = OVRInput.Get;
        if (device.getTouchDown(OVRTrackedRemote.ButtonMask.Trigger)) { //initial press
            GameObject go = new GameObject();
            go.AddComponent<MeshFilter>();
            go.AddComponent<MeshRenderer>();
            currLine = go.AddComponent<MeshLineRenderer>();
            currLine.lmat = new Material(lmat);
            currLine.setWidth(.1f);
        } else if (device.getTouch(OVRTrackedRemote.ButtonMask.Trigger)) { //held down
            currLine.AddPoint(device.transform.position);
            numClicks++;
        } else if (device.getTouchUp(OVRTrackedRemote.ButtonMask.Trigger)) { //release
            numClicks = 0;
            currLine = null;
        }

        if (currLine != null) {
            currLine.lmat.color = ColorManager.Instance.GetCurrentColor();
        }
	}
}
