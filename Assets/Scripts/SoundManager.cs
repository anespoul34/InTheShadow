using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour {

	private AudioSource source;

	private static SoundManager instance = null;
	public static SoundManager Instance {
		get { return instance; }
	}
	void Awake() {
		if (instance != null && instance != this) {
			Destroy(this.gameObject);
			return;
		} else {
			instance = this;
		}
	}

	void Start() {
		source = GetComponent<AudioSource>();
		source.volume = PlayerPrefs.GetFloat("volume");
	}
}
