using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class validLvlSelection : MonoBehaviour {

	[SerializeField] private int lvl;
	[SerializeField] private GameObject mainMenu;

	private bool hasExit;
	private bool isActive = false;
	private Quaternion startRot;

	void Awake () {
		startRot = transform.rotation;
	}

	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape))
		{
			MenuDisplayer();
		}
		if (hasExit && transform.rotation != startRot)
		{
			transform.rotation = Quaternion.Slerp(transform.rotation, startRot, Time.deltaTime * 2f);
			if (transform.rotation == startRot)
			{
				hasExit = false;
			}
		}
	}

	void OnMouseOver()
	{
		hasExit = false;
		transform.Rotate(Vector3.forward * 2f);		
		if (Input.GetMouseButton(0))
		{
			if (!EventSystem.current.IsPointerOverGameObject())
				SceneManager.LoadScene(lvl + 1);
		}
	}

	void OnMouseExit()
	{
		hasExit = true;
	}

	public void MenuDisplayer() {
		isActive = isActive ? false : true;
		mainMenu.SetActive(isActive);		
	}
}
