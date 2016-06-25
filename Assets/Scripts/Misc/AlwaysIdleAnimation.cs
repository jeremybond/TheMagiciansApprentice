// Created by: Jeremy Bond
// Date: 09/06/2016

using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SpriteRenderer))]
public class AlwaysIdleAnimation : MonoBehaviour 
{
	[SerializeField] private float SwitchSpritesTime;
	[SerializeField] private Sprite[] spriteAnimation;
	private SpriteRenderer render;
	private int currentSprite;

	/// <summary>
	/// The awake function gives some empty variables a value.
	/// </summary>
	protected void Awake () 
	{
		render = GetComponent<SpriteRenderer>();
		StartCoroutine(NextSprite());
	}
	/// <summary>
	/// Coroutine that switches the players sprite like an animation would do.
	/// </summary>
	/// <returns></returns>
	private IEnumerator NextSprite ()
	{
		while (1 != 2)
		{
			currentSprite ++;
			if (currentSprite == spriteAnimation.Length)
			{
				currentSprite = 0;
			}
			render.sprite = spriteAnimation[currentSprite];
			yield return new WaitForSeconds(SwitchSpritesTime);
		}
	}
}
