//Created By: Jeremy Bond
//Date: 24/07/2016

using UnityEngine;

public class SpellMovement : MonoBehaviour 
{
	/// <summary>
	/// Update function that moves the spell.
	/// </summary>
	protected void Update ()
	{
		transform.position = Vector3.Lerp(transform.position, transform.position + (Vector3.up / 20), Time.time);
	}
}
