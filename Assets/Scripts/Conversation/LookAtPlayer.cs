// Created by: Jeremy Bond
// Date: 08/06/2016

using UnityEngine;

[RequireComponent (typeof (SpriteRenderer))]
public class LookAtPlayer : MonoBehaviour
{
	[SerializeField] private Sprite Up;
	[SerializeField] private Sprite Down;
	[SerializeField] private Sprite Left;
	[SerializeField] private Sprite Right;
	private SpriteRenderer render;

	/// <summary>
	/// The variables get a value assigned.
	/// </summary>
	protected void Awake ()
	{
		render = GetComponent<SpriteRenderer> ();
	}
	/// <summary>
	/// Updates the looking sprite of the character.
	/// </summary>
	/// <param name="dir"></param>
	public void UpdateRotation (LookingDirection dir)
	{
		switch (dir)
		{
			case LookingDirection.Down:
			render.sprite = Up;
			break;
			case LookingDirection.Up:
			render.sprite = Down;
			break;
			case LookingDirection.Left:
			render.sprite = Right;
			break;
			case LookingDirection.Right:
			render.sprite = Left;
			break;
		}
	}
}
