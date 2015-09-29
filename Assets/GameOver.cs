using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameOver : MonoBehaviour {

	public Text timer;
	
	// Use this for initialization
	void Start () {
		GameObject obj = GameObject.Find ("Game Manager");
		if (obj != null) {
			GM gm = obj.GetComponent<GM>();
			gm.setFinalTime ();
			timer.text = "TIME: " + gm.endTime.ToString("F3") + " SECONDS";
			int ms = (int)(gm.endTime * 1000);
			KongregateAPI.Submit("Time", ms);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Reset()
	{		
		GameObject obj = GameObject.Find ("Game Manager");
		if (obj != null) {
			Destroy (obj);
		}
		Application.LoadLevel ("s1");
	}
}

