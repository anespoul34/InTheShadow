using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectObj : MonoBehaviour {

	[SerializeField] private RotationManager rot;

	void OnMouseOver() {
		if (Input.GetMouseButtonDown(0))
		{
			// Debug.Log("here");
			rot.selectedObject = gameObject;
		}
	}
}
