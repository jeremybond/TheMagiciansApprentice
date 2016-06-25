// Created by: Jeremy Bond
// Date: 06/06/2016

using UnityEngine;

[RequireComponent(typeof(LookAtPlayer))]
public class Conversation : MonoBehaviour
{
	[SerializeField] private string[] conversation;
	private string playerTag = "Player";
	private int currentText = 0;
	private bool inRange = false;

	private LookAtPlayer lookAtPlayer;
	private GameObject character;

	protected void Awake ()
	{
		lookAtPlayer = GetComponent<LookAtPlayer>();
	}

	/// <summary>
	/// The update function is used to call the conversation check.
	/// </summary>
	protected void Update ()
	{
		ConversationCheck ();
	}
	/// <summary>
	/// This function deals with the input from the player while in or starting a conversation.
	/// </summary>
	private void ConversationCheck ()
	{
		if (inRange)
		{
			if (Input.GetKeyDown (KeyCode.F))
			{
				UpdateRotation ();

				currentText++;
				if (currentText != conversation.Length)
				{
					EventManager.TriggerConversationEvent (conversation[currentText]);
				}
				else
				{
					currentText = 0;
					EventManager.TriggerEvent (StaticEvents.EXITCONVERSATION);
				}
			}
		}
	}
	/// <summary>
	/// The characters direction is updated.
	/// </summary>
	private void UpdateRotation ()
	{
		if (character != null)
		{
			float diffX = transform.position.x - character.transform.position.x;
			float diffY = transform.position.y - character.transform.position.y;
		
			if (Mathf.Abs(diffX) >= Mathf.Abs (diffY))
			{
				if (diffX < 0)
				{
					lookAtPlayer.UpdateRotation (LookingDirection.Left);
				}
				else
				{
					lookAtPlayer.UpdateRotation (LookingDirection.Right);
				}
			}
			else
			{
				if (diffY > 0)
				{
					lookAtPlayer.UpdateRotation (LookingDirection.Up);
				}
				else
				{
					lookAtPlayer.UpdateRotation (LookingDirection.Down);
				}
			}

		}
	}
	/// <summary>
	/// The OnTriggerEnter function enables the conversation function when in range.
	/// </summary>
	/// <param name="col"></param>
	protected void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == playerTag)
		{
			if (character == null)
			{
				character = col.gameObject;
			}
			UpdateRotation ();
			inRange = true;
		}
	}
	/// <summary>
	/// The OnTriggerExit function will disable the conversation function when out of range.
	/// </summary>
	/// <param name="col"></param>
	protected void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.tag == playerTag)
		{
			currentText = 0;
			inRange = false;
			EventManager.TriggerEvent (StaticEvents.EXITCONVERSATION);
		}
	}
}
