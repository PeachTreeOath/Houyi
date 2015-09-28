using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GM : MonoBehaviour {

	private Text timer;
	private TimeSpan timeSpan;
	private float startTime = -1;
	public float endTime = -1;

	void Awake()
	{
		DontDestroyOnLoad (this);
	}

	// Use this for initialization
	void Start () {
		if (startTime == -1) {
			startTime = Time.time;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (timer == null) {
			GameObject obj = GameObject.Find ("Text Time");
			if(obj != null)
			{
				timer = GameObject.Find ("Text Time").GetComponent<Text>();
			}
		}
		if (timer != null) {
			timer.text = "Time: " + (Time.time - startTime).ToString ("F3");
		}
	}

	public void setFinalTime()
	{
		endTime = Time.time - startTime;
		startTime = -1;
	}
}
