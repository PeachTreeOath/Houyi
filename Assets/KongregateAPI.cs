using UnityEngine;

/* 
 * WARNING: This code is provided as-is and is not guaranteed to work. You are
 * liable for any damages caused by this code. Credit is not required and this
 * code may be freely distributed with no license.
 *
 * Instructions
 *
 * Attach this script to any GameObject, and ensure that the object persists between
 * scenes. THIS SCRIPT SHOULD NOT BE MODIFIED (unless the compiler tells you otherwise)
 * to ensure that the kongregateUnitySupport object does not break.
 *
 * Usage
 *
 * To submit a stat simply call from anywhere:
 *
 *     KongregateAPI.Submit("MyStatisticName", VariableName);
 *
 * where "MyStatisticName" is a string literal of the same value you gave to Kongregate 
 * while setting up your project and VariableName is a variable instance within your
 * code holding some arbitrary value.
 *
 * Do not submit stats often. Only submit stats during discrete events such as the player
 * dying, level completion, or boss deaths. As a rule of thumb you should avoid submitting
 * a stat every frame.
 */

/// <summary>
/// Provides quick access to Kongregate's API system, allowing the submission of stats. It is best to handle setup of this class
/// as soon as possible in your application.
/// </summary>
public class KongregateAPI : MonoBehaviour
{
	/// <summary>
	/// Are we connected to Kongregate's API?
	/// </summary>
	public static bool Connected { get; private set; }
	/// <summary>
	/// The user's unique identifier.
	/// </summary>
	public static int UserId { get; private set; }
	/// <summary>
	/// The user's Kongregate username.
	/// </summary>
	public static string Username { get; private set; }
	/// <summary>
	/// The game's authentication token.
	/// </summary>
	public static string GameAuthToken { get; private set; }
	
	/// <summary>
	/// A singleton instance of the KongregateAPI.
	/// </summary>
	public static KongregateAPI Instance { get; private set; }
	
	void Start()
	{
		if (Instance == null)
		{
			Instance = this;
			Connect();
		}
	}
	
	/// <summary>
	/// Connect to Kongregate's API service.
	/// </summary>
	public void Connect()
	{
		Connect (this);
	}
	
	/// <summary>
	/// Connect to Kongregate's API service.
	/// </summary>
	public static void Connect(KongregateAPI APIInstance)
	{
		if (APIInstance == null)
		{
			Debug.LogWarning("Attempting to connect with a null KongregateAPI instance.");
			return;
		}
		
		if (Instance == null)
		{
			Instance = APIInstance;
		}
		
		if (!Connected)
		{
			Application.ExternalEval(
				"if(typeof(kongregateUnitySupport) != 'undefined') {" +
				"kongregateUnitySupport.initAPI('" + Instance.gameObject.name + "', 'OnKongregateAPILoaded');" +
				"}"
				);
		}
		else
			Debug.LogWarning("You are attempting to connect to Kongregate's API multiple times. You only need to connect once.");
	}
	
	/// <summary>
	/// Submit a value to the server.
	/// </summary>
	/// <param name="statisticName">The name of the statistic. This is the name provided in the "Statistic name" section when you fill in the API when uploading your game. See http://developers.kongregate.com/docs/kongregate-apis/stats for more details.</param>
	/// <param name="value">The value to submit (score, kills, deaths, etc...).</param>
	public static void Submit(string statisticName, int value)
	{
		if (Connected)
			Application.ExternalCall("kongregate.stats.submit", statisticName, value);
		else
			Debug.LogWarning("You are attempting to submit a statistic without being connected to Kongregate's API. Connect first, then submit.");
	}
	
	// If this is not called try changing the access modifier to public.
	private void OnKongregateAPILoaded(string userInfoString)
	{
		if (!Connected)
		{
			Connected = true;
			string[] parameters = userInfoString.Split('|');
			UserId = System.Convert.ToInt32(parameters[0]);
			Username = parameters[1];
			GameAuthToken = parameters[2];
		}
	}
}