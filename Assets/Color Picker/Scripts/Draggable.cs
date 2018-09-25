using UnityEngine;

public class Draggable : MonoBehaviour
{
    public OVRInput.Controller device;

    public bool fixX;
	public bool fixY;
	public Transform thumb;	
	bool dragging;

    public GameObject anchor;

	void FixedUpdate()
	{

        if (OVRInput.GetDown(OVRInput.RawButton.LIndexTrigger, device))
        { //initial press

            print("Left index press");
        
			dragging = false;
            // Get a raycast from position and rotation
            Ray ray = new Ray(anchor.transform.position, anchor.transform.forward);
			RaycastHit hit;
            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity)) {
				dragging = true;
                print(dragging);
			}
		}
		if (OVRInput.GetUp(OVRInput.RawButton.LIndexTrigger, device)) dragging = false;
		if (dragging && OVRInput.Get(OVRInput.RawButton.LIndexTrigger, device)) {

            Ray ray = new Ray(anchor.transform.position, anchor.transform.forward);
            RaycastHit hit;
            if (GetComponent<Collider>().Raycast(ray, out hit, Mathf.Infinity))
            {
                var point = hit.point;
                point = GetComponent<Collider>().ClosestPointOnBounds(point);
                SetThumbPosition(point);
                SendMessage("OnDrag", Vector3.one - (thumb.position - GetComponent<Collider>().bounds.min) / GetComponent<Collider>().bounds.size.x);
            }

		}
	}

	void SetDragPoint(Vector3 point)
	{
		point = (Vector3.one - point) * GetComponent<Collider>().bounds.size.x + GetComponent<Collider>().bounds.min;
		SetThumbPosition(point);
	}

	void SetThumbPosition(Vector3 point)
	{
		thumb.position = new Vector3(fixX ? thumb.position.x : point.x, fixY ? thumb.position.y : point.y, thumb.position.z);
	}
}
