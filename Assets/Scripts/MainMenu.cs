using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	CanvasGroup mMainPanel; 

	public static MainMenu instance;

	void Awake(){ 
		instance = this; 
		mMainPanel = transform.Find ("MainPanel").GetComponent<CanvasGroup> (); 
	} 

	// Use this for initialization 
	void Start () { 
		mMainPanel.gameObject.SetActive (true); 
	}

	#region Change Panels

	#endregion

	public void Quit()
	{
		SFX.instance.PlaySound (SFXTypes.button);
		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif

		Application.Quit();
	}


	#region Fade utility
	IEnumerator FadeCanvasGroup(float finalAlpha, float fadeTime, CanvasGroup aCanvasGroup){
		float initAlpha = aCanvasGroup.alpha;
		for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / fadeTime) {
			aCanvasGroup.alpha = Mathf.Lerp (initAlpha, finalAlpha, t);
			yield return null;
		}
	}

	void switchCanvasGroups(CanvasGroup initGroup, CanvasGroup finGroup){

		initGroup.gameObject.SetActive (false);
		initGroup.alpha = 1.0f;
		StartCoroutine (FadeCanvasGroup(0.0f,0.5f,initGroup));

		finGroup.gameObject.SetActive (true);
		finGroup.alpha = 0.0f;
		StartCoroutine (FadeCanvasGroup(1.0f,0.5f,finGroup));
	}
	#endregion


}
