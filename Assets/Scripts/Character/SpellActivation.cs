//Created By: Jeremy Bond
//Date: 26/07/2016

using UnityEngine;
using System.Collections;

public class SpellActivation : MonoBehaviour
{
	[SerializeField] private GameObject fireBall;
	private CharacterAnimation charAnim;
	private LookingDirection dir;
	private Vector2 position;

	/// <summary>
	/// Awake function that gives the "charanim" variable a value.
	/// </summary>
	protected void Awake()
	{
		charAnim = GetComponent<CharacterAnimation>();
	}
	/// <summary>
	/// OnEnable function that adds a listener to the spellcast event to the manager.
	/// </summary>
	protected void OnEnable()
	{
		EventManager.AddListener(GeneralEvents.SPELLCAST, SpellCast);
	}
	/// <summary>
	/// OnDisable function that removes a listener to the spellcast event to the manager.
	/// </summary>
	protected void OnDisable()
	{
		EventManager.RemoveListener(GeneralEvents.SPELLCAST, SpellCast);
	}
	/// <summary>
	/// The function that gets called after a "spellcast" event.
	/// Rotates the instantiated spell towards the right direction.
	/// </summary>
	private void SpellCast()
	{
		dir = charAnim.lookDir;
		GameObject spell = Instantiate(fireBall, transform.position, Quaternion.identity) as GameObject;
		SpellMovement spellMovement = spell.GetComponent<SpellMovement>();
		spellMovement.lookDir = dir;
		spell.transform.SetParent(transform);
	}
}
