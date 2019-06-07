using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightToMouse : MonoBehaviour {

	[SerializeField] private Camera mycam;

	void Update () {
         	transform.LookAt(mycam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, mycam.nearClipPlane)), Vector3.up);
	}
}
