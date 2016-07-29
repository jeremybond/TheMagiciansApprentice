// Created by: Jeremy Bond
// Date: 06/06/2016

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Rigidbody2D))]
public class CharacterMovement : MonoBehaviour
{
	[SerializeField] private float speed = 1;
	private Rigidbody2D rigid;
	private bool stunned;

	/// <summary>
	/// The awake function is used to apply values to variables.
	/// </summary>
	protected void Awake ()
	{
		rigid = GetComponent<Rigidbody2D> ();
	}
	/// <summary>
	/// The OnEnable function adds the listeners from the events.
	/// </summary>
	protected void OnEnable ()
	{
		EventManager.AddListener (GeneralEvents.DAMAGED, BounceBack);
	}
	/// <summary>
	/// The OnDisable function removes the listeners from the events.
	/// </summary>
	protected void OnDisable ()
	{
		EventManager.RemoveListener (GeneralEvents.DAMAGED, BounceBack);
	}
	/// <summary>
	/// The update function is used to call the move function.
	/// </summary>
	protected void Update ()
	{
		if (!PlayerStats.died)
		{
			Move (Input.GetAxis ("Horizontal"), Input.GetAxis ("Vertical"));
		}
	}
	/// <summary>
	/// The move function takes the horizontal and vertical input and uses them as velocity for the rigidbody.
	/// </summary>
	/// <param name="horizontal"></param>
	/// <param name="vertical"></param>
	private void Move (float horizontal, float vertical)
	{
		horizontal =  Mathf.RoundToInt (horizontal);
		vertical = Mathf.RoundToInt (vertical);
		if (horizontal != 0 && vertical != 0)
		{
			horizontal /= 1.5f;
			vertical /= 1.5f;
		}
		Vector2 force = new Vector3 (horizontal, vertical);

		if (!stunned)
		{
			rigid.velocity = force * speed;
		}
	}
	/// <summary>
	/// The bounce back function. The player bounces back when hit by a enemy.
	/// </summary>
	private void BounceBack ()
	{
		stunned = true;
		rigid.velocity = -rigid.velocity;
		StartCoroutine (StunnedTimer ());
	}
	/// <summary>
	/// A timer to stun the player.
	/// </summary>
	/// <returns></returns>
	private IEnumerator StunnedTimer ()
	{
		yield return new WaitForSeconds(0.1f);
		stunned = false;
		rigid.velocity = Vector2.zero;
	}
}
