using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SFXTypes
{
	button
}

public class SFX : MonoBehaviour {

	public static SFX instance;

	AudioSource mAudioSource;

	[SerializeField]
	AudioClip mButton;

	// Use this for initialization
	void Awake () {
		instance = this;
		if (!mAudioSource)
			mAudioSource = GetComponent<AudioSource> ();
	}

	//Play one of the sounds in SFXTypes
	public void PlaySound(SFXTypes aSFX){

		switch (aSFX) {
		case SFXTypes.button:
			mAudioSource.PlayOneShot (mButton);
			break;
		}

	}
}
