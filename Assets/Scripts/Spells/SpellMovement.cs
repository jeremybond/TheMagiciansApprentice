//Created By: Jeremy Bond
//Date: 24/07/2016

using UnityEngine;

public class SpellMovement : MonoBehaviour 
{
	public LookingDirection lookDir;
	private bool givenRotation;
	private Vector3 movingDir;
	
	/// <summary>
	/// Update function that moves the spell.
	/// </summary>
	protected void Update ()
	{
		if (givenRotation)
		{
			transform.position = Vector3.Lerp(transform.position, transform.position + (movingDir / 20), Time.time);
		}
		else
		{
			givenRotation = true;
			switch (lookDir)
			{
				case LookingDirection.Up:
					movingDir = Vector3.up;
					break;
				case LookingDirection.Left:
					movingDir = Vector3.left;
					break;
				case LookingDirection.Down:
					movingDir = Vector3.down;
					break;
				case LookingDirection.Right:
					movingDir = Vector3.right;
					break;
			}
		}
	}
}
