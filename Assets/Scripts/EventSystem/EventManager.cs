//Created By: Jeremy Bond
//Date: 25/03/2016

using UnityEngine;
using UnityEngine.Events;
using System.Collections.Generic;
using Utils;

public class EventManager : MonoBehaviour
{

	private Dictionary<string, UnityEvent> eventDictionary;
	private Dictionary<string, AudioEvent> audioEventDictionary;
	private Dictionary<string, LifeEvent> livesEventDictionary;
	private Dictionary<string, ConversationEvent> conversationEventDictionary;

	private static EventManager eventManager;
	private const string AUDIOEVENT = "audioEvent";
	private const string LIFEADJUSTEVENT = "LifeAdjustEvent";
	private const string CONVERSATIONEVENT = "ConversationEvent";

	public static EventManager instance
	{
		get
		{
			if (!eventManager)
			{
				eventManager = FindObjectOfType (typeof (EventManager)) as EventManager;

				if (!eventManager)
				{
					Debug.LogError ("There needs to be one active EventManager script on a GameObject in your scene.");
				}
				else
				{
					eventManager.Init ();
				}
			}

			return eventManager;
		}
	}
	/// <summary>
	/// The Init function gives the empty variables a empty value.
	/// </summary>
	private void Init ()
	{
		if (eventDictionary == null)
		{
			eventDictionary = new Dictionary<string, UnityEvent> ();
		}
		if (audioEventDictionary == null)
		{
			audioEventDictionary = new Dictionary<string, AudioEvent> ();
		}
		if (livesEventDictionary == null)
		{
			livesEventDictionary = new Dictionary<string, LifeEvent> ();
		}
		if (conversationEventDictionary == null)
		{
			conversationEventDictionary = new Dictionary<string, ConversationEvent> ();
		}
	}
	/// <summary>
	/// Add listener function.
	/// </summary>
	/// <param name="eventName"></param>
	/// <param name="listener"></param>
	public static void AddListener (string eventName, UnityAction listener)
	{
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.AddListener (listener);
		}
		else
		{
			thisEvent = new UnityEvent ();
			thisEvent.AddListener (listener);
			instance.eventDictionary.Add (eventName, thisEvent);
		}
	}
	/// <summary>
	/// Add lives decrease listener function.
	/// </summary>
	/// <param name="eventName"></param>
	/// <param name="listener"></param>
	public static void AddAdjustLifeListener (UnityAction<int> listener)
	{
		LifeEvent thisEvent = null;
		if (instance.livesEventDictionary.TryGetValue (LIFEADJUSTEVENT, out thisEvent))
		{
			thisEvent.AddListener (listener);
		}
		else
		{
			thisEvent = new LifeEvent();
			thisEvent.AddListener (listener);
			instance.livesEventDictionary.Add (LIFEADJUSTEVENT, thisEvent);
		}
	}
	/// <summary>
	/// Add conversation listener function.
	/// </summary>
	/// <param name="eventName"></param>
	/// <param name="listener"></param>
	public static void AddConversationListener (UnityAction<string> listener)
	{
		ConversationEvent thisEvent = null;
		if (instance.conversationEventDictionary.TryGetValue (CONVERSATIONEVENT, out thisEvent))
		{
			thisEvent.AddListener (listener);
		}
		else
		{
			thisEvent = new ConversationEvent ();
			thisEvent.AddListener (listener);
			instance.conversationEventDictionary.Add (CONVERSATIONEVENT, thisEvent);
		}
	}
	/// <summary>
	/// Add audio listener function.
	/// </summary>
	/// <param name="listener"></param>
	public static void AddAudioListener (UnityAction<AudioClip> listener)
	{
		AudioEvent thisEvent = null;
		if (instance.audioEventDictionary.TryGetValue (AUDIOEVENT, out thisEvent))
		{
			thisEvent.AddListener (listener);
		}
		else
		{
			thisEvent = new AudioEvent ();
			thisEvent.AddListener (listener);
			instance.audioEventDictionary.Add (AUDIOEVENT, thisEvent);
		}
	}
	/// <summary>
	/// Remove listener function.
	/// </summary>
	/// <param name="eventName"></param>
	/// <param name="listener"></param>
	public static void RemoveListener (string eventName, UnityAction listener)
	{
		if (eventManager == null)
		{
			return;
		}
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}
	/// <summary>
	/// Remove lives decrease listener function.
	/// </summary>
	/// <param name="listener"></param>
	public static void RemoveAdjustLifeListener (UnityAction<int> listener)
	{
		if (eventManager == null)
		{
			return;
		}
		LifeEvent thisEvent = null;
		if (instance.livesEventDictionary.TryGetValue (LIFEADJUSTEVENT, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}
	/// <summary>
	/// Remove conversation listener function.
	/// </summary>
	/// <param name="listener"></param>
	public static void RemoveConversationListener (UnityAction<string> listener)
	{
		if (eventManager == null)
		{
			return;
		}
		ConversationEvent thisEvent = null;
		if (instance.conversationEventDictionary.TryGetValue (CONVERSATIONEVENT, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}
	/// <summary>
	/// Remove audio listener function.
	/// </summary>
	/// <param name="listener"></param>
	public static void RemoveAudioListener (UnityAction<AudioClip> listener)
	{
		if (eventManager == null)
		{
			return;
		}
		AudioEvent thisEvent = null;
		if (instance.audioEventDictionary.TryGetValue (AUDIOEVENT, out thisEvent))
		{
			thisEvent.RemoveListener (listener);
		}
	}
	/// <summary>
	/// Trigger event function.
	/// </summary>
	/// <param name="eventName"></param>
	public static void TriggerEvent (string eventName)
	{
		UnityEvent thisEvent = null;
		if (instance.eventDictionary.TryGetValue (eventName, out thisEvent))
		{
			thisEvent.Invoke ();
		}
	}
	/// <summary>
	/// Trigger lives decrease event function.
	/// </summary>
	/// <param name="clip"></param>
	public static void TriggerAdjustLifeEvent (int damage)
	{
		LifeEvent thisEvent = null;
		if (instance.livesEventDictionary.TryGetValue (LIFEADJUSTEVENT, out thisEvent))
		{
			thisEvent.Invoke (damage);
		}
	}
	/// <summary>
	/// Trigger conversation event function.
	/// </summary>
	/// <param name="clip"></param>
	public static void TriggerConversationEvent(string sentence)
	{
		ConversationEvent thisEvent = null;
		if (instance.conversationEventDictionary.TryGetValue (CONVERSATIONEVENT, out thisEvent))
		{
			thisEvent.Invoke (sentence);
		}
	}
	/// <summary>
	/// Trigger audio event function.
	/// </summary>
	/// <param name="clip"></param>
	public static void TriggerAudioEvent (AudioClip clip)
	{
		AudioEvent thisEvent = null;
		if (instance.audioEventDictionary.TryGetValue (AUDIOEVENT, out thisEvent))
		{
			thisEvent.Invoke (clip);
		}
	}
}











