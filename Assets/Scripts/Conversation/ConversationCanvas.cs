// Created by: Jeremy Bond
// Date: 06/06/2016

using UnityEngine;
using UnityEngine.UI;

public class ConversationCanvas : MonoBehaviour 
{
	[SerializeField] private GameObject background;
	[SerializeField] private Text textArea;

	/// <summary>
	/// OnEnable will add a listener to the Conversation event;
	/// </summary>
	protected void OnEnable ()
	{
		EventManager.AddConversationListener(ConversationTriggered);
		EventManager.AddListener(GeneralEvents.EXITCONVERSATION, DisableConversation);
	}
	/// <summary>
	/// OnDisable will remove a listener to the Conversation event;
	/// </summary>
	protected void OnDisable ()
	{
		EventManager.RemoveConversationListener(ConversationTriggered);
		EventManager.RemoveListener(GeneralEvents.EXITCONVERSATION, DisableConversation);
	}
	/// <summary>
	/// Here the conversation objects are set active and the text is updated.
	/// </summary>
	/// <param name="nextSentence"></param>
	private void ConversationTriggered (string nextSentence)
	{
		SetConversationArea(true);
		textArea.text = nextSentence;
	}
	/// <summary>
	/// Function triggered when the conversation exit event is send, and will disable the conversation area.
	/// </summary>
	private void DisableConversation ()
	{
		SetConversationArea(false);	
	}
	/// <summary>
	/// This function lets you enable and disable the conversation area with the enable parameter.
	/// </summary>
	/// <param name="enable"></param>
	private void SetConversationArea (bool enable)
	{
		background.SetActive (enable);
	}
}
