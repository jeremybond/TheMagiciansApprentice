// Created by: Jeremy Bond
// Date: 06/06/2016

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (SpriteRenderer))]
public class CharacterCollision : MonoBehaviour
{
	[SerializeField]
	private Material hitMat;
	[SerializeField]
	private Material normalMat;
	
	private bool canOpenChest;
	private GameObject currentChest;
	private SpriteRenderer render;

	/// <summary>
	/// The awake function is used to apply values to variables.
	/// </summary>
	protected void Awake ()
	{
		render = GetComponent<SpriteRenderer> ();
	}

	/// <summary>
	/// The material switch happens here. After being hit the character will flash white and change back in an instant.
	/// </summary>
	private IEnumerator SwitchMaterialFlash ()
	{
		render.material = hitMat;
		yield return new WaitForSeconds (0.1f);
		render.material = normalMat;
	}

	/// <summary>
	/// OnCollision enter function that triggers when the player collides with anything.
	/// </summary>
	/// <param name="col"></param>
	protected void OnCollisionEnter2D (Collision2D col)
	{
		if (!PlayerStats.died)
		{
			if (col.gameObject.tag == ConstStrings.ENEMYTAG)
			{
				Invoke ("LoseLife", 0.1f);
				StartCoroutine (SwitchMaterialFlash ());
			}
		}
	}

	/// <summary>
	/// OnTrigger enter function that triggers when entering a trigger collider.
	/// </summary>
	/// <param name="col"></param>
	protected void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag == ConstStrings.CHESTTAG)
		{
			canOpenChest = true;
			currentChest = col.gameObject;
		}
	}

	/// <summary>
	/// Ontrigger exit function that triggers when leaving a trigger collider.
	/// </summary>
	/// <param name="col"></param>
	protected void OnTriggerExit2D (Collider2D col)
	{
		if (col.gameObject.tag == ConstStrings.CHESTTAG)
		{
			canOpenChest = false;
		}
	}

	/// <summary>
	/// Function that triggers the adjust life event.
	/// </summary>
	private void LoseLife ()
	{
		EventManager.TriggerAdjustLifeEvent (20);
	}

	protected void Update ()
	{
		if (canOpenChest)
		{
			if (Input.GetKeyDown (KeyCode.E))
			{
				if (currentChest)
				{
					currentChest.GetComponent<ChestInteraction> ().OpenChest ();
				}
			}
		}
	}
}
