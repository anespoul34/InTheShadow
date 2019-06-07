using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class RotateObject : MonoBehaviour {

	[SerializeField] private float speed;
	[SerializeField] private int lvl;

	void Update () {	

		if (!GameManager.instance.win)
		{
			// Debug.Log("LocalRotation = " + transform.localRotation.eulerAngles);

			float x = Input.GetAxis("Mouse X") * speed * Mathf.Deg2Rad;
			float y = Input.GetAxis("Mouse Y") * speed * Mathf.Deg2Rad;

			// Debug.Log("x = " + x);
			// Debug.Log("y = " + y);
			if (!EventSystem.current.IsPointerOverGameObject()) {
				if (lvl == 1)
				{
					if (Input.GetMouseButton(0))
					{
						transform.Rotate(Vector3.up * -x, Space.World);
					}			
				} else {
					if (Input.GetMouseButton(0) && Input.GetKey(KeyCode.LeftControl))
					{
						transform.Rotate(Vector3.left * -y, Space.World);
					}
					else if (Input.GetMouseButton(1) && Input.GetKey(KeyCode.LeftControl))
					{
						transform.Rotate(Vector3.forward * -y, Space.World);			
					}
					else if (Input.GetMouseButton(0))
					{
						transform.Rotate(Vector3.up * -x, Space.World);
					}
				}	
			}	
		}
	}
}