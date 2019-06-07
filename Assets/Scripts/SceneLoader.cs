using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneLoader : MonoBehaviour {

	void Start () {
		PlayerPrefs.SetInt("test", 0);
	}

	public void ReloadScene () {
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void TestMode ()
	{
		PlayerPrefs.SetInt("test", 1);
		SceneManager.LoadScene(1);
	}

	public void LoadScene (int i) {
		SceneManager.LoadScene(i);
	}

	public void LeaveGame () {
		Application.Quit();
	}

	public void ResetPlayerPref () {
		PlayerPrefs.SetInt("lvl", 1);
	}
}