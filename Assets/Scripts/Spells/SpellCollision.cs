//Created By: Jeremy Bond
//Date: 24/07/2016

using UnityEngine;

public class SpellCollision : MonoBehaviour 
{
	[SerializeField] private GameObject spell;
	[SerializeField] private GameObject explosion;

	/// <summary>
	/// Awake function that activates the spell.
	/// </summary>
	protected void Awake()
	{
		spell.SetActive(true);
	}
	/// <summary>
	/// OnCollision enter function that triggers when the spell collides with anything.
	/// </summary>
	/// <param name="col"></param>
	protected void OnTriggerEnter2D (Collider2D col)
	{
		if (col.gameObject.tag != ConstStrings.PLAYERTAG)
		{
			spell.SetActive(false);
			explosion.SetActive(true);
		}
	}
}
