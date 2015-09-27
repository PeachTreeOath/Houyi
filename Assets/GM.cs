using UnityEngine;
using UnityEngine.UI;
using System;
using System.Collections;

public class GM : MonoBehaviour {

	public Text timer;
	private TimeSpan timeSpan;
	private float startTime;

	// Use this for initialization
	void Start () {
		startTime = Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		timeSpan += TimeSpan.FromSeconds (Time.deltaTime);
		Debug.Log (timeSpan.Seconds);
		timer.text = "Time: " + String.Format("{0:00}:{1:00}",timeSpan.Minutes,timeSpan.Seconds);
	}
}
