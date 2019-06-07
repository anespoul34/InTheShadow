using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationManager : MonoBehaviour {

	[SerializeField] private float speed;
	
	public GameObject selectedObject;

	void Update () {
		if (!GameManager.instance.win)
		{
			float x = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
			float y = Input.GetAxis("Mouse Y") * speed * Mathf.Deg2Rad;

			if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftControl))
			{
				selectedObject.transform.Rotate(Vector3.left * -y, Space.World);
			}
			else if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.LeftControl))
			{
				selectedObject.transform.Rotate(Vector3.forward * -y, Space.World);			
			}
			else if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftShift))
			{
				selectedObject.transform.Translate(Vector3.up * y/60, Space.World);
			}
			else if (Input.GetMouseButton(0))
			{
				selectedObject.transform.Rotate(Vector3.up * -x, Space.World);
			} 
		}
	}
}
