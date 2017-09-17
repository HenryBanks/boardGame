using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 

public class HUD : MonoBehaviour { 

	CanvasGroup mPausePanel; 
	CanvasGroup mHUDPanel; 

	bool mIsPaused; 

	public static HUD instance;

    void Awake(){ 
		instance = this; 
		mHUDPanel = transform.Find ("HUDPanel").GetComponent<CanvasGroup> (); 
		mPausePanel = transform.Find ("PausePanel").GetComponent<CanvasGroup> ();
    } 

	// Use this for initialization 
	void Start () { 
		mPausePanel.gameObject.SetActive (false); 
		mHUDPanel.gameObject.SetActive (true); 
		mIsPaused = false;
	}

    #region Pause, quit and resume
    public void Resume()
	{
		Debug.Log ("Resume");
		SFX.instance.PlaySound (SFXTypes.button);
		UnPause();
	}

	public void Quit()
	{
		SFX.instance.PlaySound (SFXTypes.button);

		#if UNITY_EDITOR
		UnityEditor.EditorApplication.isPlaying = false;
		#endif

		Application.Quit();
	}

	void TogglePause(){ 
		if (mIsPaused) { 
			UnPause (); 
		} else { 
			Pause (); 
		} 
	} 

	void Pause(){ 
		Time.timeScale = 0; 
		mPausePanel.gameObject.SetActive (true); 
		mHUDPanel.gameObject.SetActive (false); 
		mIsPaused = true; 
	} 

	void UnPause(){ 
		Time.timeScale = 1; 
		mPausePanel.gameObject.SetActive (false); 
		mHUDPanel.gameObject.SetActive (true); 
		mIsPaused = false; 
	}
    #endregion
    
    void Update () { 
		if (Input.GetKeyUp (KeyCode.Escape)) {
			TogglePause ();
		}
	}

} 