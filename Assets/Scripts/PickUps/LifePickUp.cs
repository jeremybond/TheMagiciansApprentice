//Created By: Jeremy Bond
//Date: 27/07/2016

using UnityEngine;

public class LifePickUp : MonoBehaviour
{
	[SerializeField] private int livesGained;
	[SerializeField] private Collider2D[] colliders;

	/// <summary>
	/// When colliding with the player, the adjust life event is triggered.
	/// </summary>
	/// <param name="col">reference to the collider2d that hit this object.</param>
	protected void OnTriggerEnter2D (Collider2D col) 
	{
		if (col.transform.tag == ConstStrings.PLAYERTAG)
		{
			EventManager.TriggerAdjustLifeEvent(livesGained);
			foreach (Collider2D coll in colliders)
			{
				coll.enabled = false;
			}
			Destroy (gameObject, 0.1f);
		}
	}
}
