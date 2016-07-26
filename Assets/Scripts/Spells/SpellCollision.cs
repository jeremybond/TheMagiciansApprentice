//Created By: Jeremy Bond
//Date: 24/07/2016

using UnityEngine;

public class SpellCollision : MonoBehaviour 
{
	[SerializeField] private GameObject spell;
	[SerializeField] private GameObject explosion;
	[SerializeField] private Collider2D[] colliders;
	[SerializeField] private int spellDamage;

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
			EventManager.TriggerAdjustLifeEvent(spellDamage);
			foreach(Collider2D coll in colliders)
			{
				coll.enabled = false;
			}
			spell.SetActive(false);
			explosion.SetActive(true);
			Invoke("DestroySelf", .6f);
		}
	}
	/// <summary>
	/// Function that destroys the spell after colliding with an object.
	/// </summary>
	private void DestroySelf()
	{
		Destroy(gameObject);
	}
}
