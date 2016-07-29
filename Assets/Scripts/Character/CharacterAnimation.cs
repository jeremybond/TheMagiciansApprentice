// Created by: Jeremy Bond
// Date: 06/06/2016

using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/// <summary>
/// The enum for keeping track of the current looking direction.
/// </summary>
public enum LookingDirection
{
	Left,
	Right,
	Up,
	Down
}
/// <summary>
/// The enum for keeping track of the current animation state.
/// </summary>
public enum AnimationStates
{
	Idle,
	Moving,
	Shooting,
	MovingAndShooting
}

[RequireComponent (typeof (SpriteRenderer))]
public class CharacterAnimation : MonoBehaviour
{
	[SerializeField] private Sprite[] Die;
	[SerializeField] private Sprite[] IdleDown;
	[SerializeField] private Sprite[] IdleUp;
	[SerializeField] private Sprite[] IdleLeft;
	[SerializeField] private Sprite[] IdleRight;
	[SerializeField] private Sprite[] WalkDown;
	[SerializeField] private Sprite[] WalkUp;
	[SerializeField] private Sprite[] WalkLeft;
	[SerializeField] private Sprite[] WalkRight;
	[SerializeField] private Sprite[] ShootDown;
	[SerializeField] private Sprite[] ShootUp;
	[SerializeField] private Sprite[] ShootLeft;
	[SerializeField] private Sprite[] ShootRight;
	[SerializeField] private Sprite[] WalkAndShootDown;
	[SerializeField] private Sprite[] WalkAndShootUp;
	[SerializeField] private Sprite[] WalkAndShootLeft;
	[SerializeField] private Sprite[] WalkAndShootRight;
	
	private int currentSpriteID = 0;
	private Sprite[] currentAnim;

	private SpriteRenderer render;

	public LookingDirection lookDir;
	private AnimationStates curAnimState;

	private bool changeSide = true;

	private int keysPressed = 0;
	private List<LookingDirection> LastPressedDirection;

	private bool moving;
	private bool shooting;

	/// <summary>
	/// The awake function is used to apply values to variables.
	/// </summary>
	protected void Awake ()
	{
		render = GetComponent<SpriteRenderer> ();
		lookDir = LookingDirection.Down;
		curAnimState = AnimationStates.Idle;
		LastPressedDirection = new List<LookingDirection> ();
	}
	/// <summary>
	/// The start function is used to start the functions used from start to end.
	/// </summary>
	protected void Start ()
	{
		StartCoroutine(PlayAnimation());
	}
	/// <summary>
	/// The update function is used to play the input functions.
	/// </summary>
	protected void Update ()
	{
		if (!PlayerStats.died)
		{
			CheckMoving ();
			CheckStopMoving ();
			CheckShooting ();
		}
	}
	/// <summary>
	/// The general checks for pressing any move key.
	/// </summary>
	private void CheckMoving ()
	{
		// Check for every moving key.
		changeSide = false;
		changeSide = Input.GetKey (KeyCode.LeftShift);
		if (!changeSide)
		{
			//LEFT
			if (Input.GetKeyDown (KeyCode.A) || Input.GetKeyDown (KeyCode.LeftArrow))
			{
				lookDir = LookingDirection.Left;
				MoveKeyPressed ();
			}
			//RIGHT
			if (Input.GetKeyDown (KeyCode.D) || Input.GetKeyDown (KeyCode.RightArrow))
			{
				lookDir = LookingDirection.Right;
				MoveKeyPressed ();
			}
			//UP
			if (Input.GetKeyDown (KeyCode.W) || Input.GetKeyDown (KeyCode.UpArrow))
			{
				lookDir = LookingDirection.Up;
				MoveKeyPressed ();
			}
			//DOWN
			if (Input.GetKeyDown (KeyCode.S) || Input.GetKeyDown (KeyCode.DownArrow))
			{
				lookDir = LookingDirection.Down;
				MoveKeyPressed ();
			}
		}
	}
	/// <summary>
	/// The general check for releasing any move key.
	/// </summary>
	private void CheckStopMoving ()
	{
		// Check for releasing a move key and then decreasing keysPressed. When keysPressed is zero, changing animation.
		if (keysPressed != 0)
		{
			// Checking for releasing any movement key.
			//LEFT
			if (Input.GetKeyUp (KeyCode.A) || Input.GetKeyUp (KeyCode.LeftArrow))
			{
				ActionStopMoving (LookingDirection.Left);
			}
			//RIGHT
			if (Input.GetKeyUp (KeyCode.D) || Input.GetKeyUp (KeyCode.RightArrow))
			{
				ActionStopMoving (LookingDirection.Right);
			}
			//UP
			if (Input.GetKeyUp (KeyCode.W) || Input.GetKeyUp (KeyCode.UpArrow))
			{
				ActionStopMoving (LookingDirection.Up);
			}
			//DOWN
			if (Input.GetKeyUp (KeyCode.S) || Input.GetKeyUp (KeyCode.DownArrow))
			{
				ActionStopMoving (LookingDirection.Down);
			}
			
		}
	}
	/// <summary>
	/// The actions taken when released any movement key.
	/// </summary>
	private void ActionStopMoving (LookingDirection releasedDirection)
	{
		for (int i = 0; i < LastPressedDirection.Count; i++)
		{
			if (LastPressedDirection[i] == releasedDirection)
			{
				LastPressedDirection.RemoveAt (i);
				if (LastPressedDirection.Count != 0)
				{
					lookDir = LastPressedDirection[LastPressedDirection.Count - 1];
				}
			}
		}

		keysPressed--;
		if (keysPressed == 0)
		{
			moving = false;
		}

		AnimationStateAdjusted ();
	}
	/// <summary>
	/// The general checks for when using a spell.
	/// </summary>
	private void CheckShooting ()
	{
		// When using magic changing animation.
		if (Input.GetKeyDown (KeyCode.Space))
		{
			shooting = true;
			AnimationStateAdjusted ();
		}
		// When not using magic anymore changing animation.
		if (Input.GetKeyUp (KeyCode.Space))
		{
			shooting = false;
			AnimationStateAdjusted ();
		}
	}
	/// <summary>
	/// Everything that should happen when you have pressed or released a key related to playing an animation.
	/// </summary>
	private void AnimationStateAdjusted ()
	{
		ChangeCurrentAnimationState ();
		ChangeAnimation ();
	}
	/// <summary>
	/// All the stuff that should happen when a move key is pressed.
	/// </summary>
	private void MoveKeyPressed ()
	{
		LastPressedDirection.Add (lookDir);
		keysPressed++;
		moving = true;
		AnimationStateAdjusted ();
	}
	/// <summary>
	/// Changing the current animation state. Not the animation it self.
	/// </summary>
	private void ChangeCurrentAnimationState ()
	{
		curAnimState = AnimationStates.Idle;
		if (moving)
		{
			curAnimState = AnimationStates.Moving;
			if (shooting)
			{
				curAnimState = AnimationStates.MovingAndShooting;
			}
		}
		if (shooting)
		{
			curAnimState = AnimationStates.Shooting;
		}
	}
	/// <summary>
	/// Changing the animation according to the "CurrentAnimationState" and the current "LookingDirection".
	/// </summary>
	private void ChangeAnimation ()
	{
		switch (curAnimState)
		{
			case AnimationStates.Idle:
			switch (lookDir)
			{
				case LookingDirection.Down:
				currentAnim = IdleDown;
				break;
				case LookingDirection.Up:
				currentAnim = IdleUp;
				break;
				case LookingDirection.Left:
				currentAnim = IdleLeft;
				break;
				case LookingDirection.Right:
				currentAnim = IdleRight;
				break;
			}
			break;
			case AnimationStates.Moving:
			switch (lookDir)
			{
				case LookingDirection.Down:
				currentAnim = WalkDown;
				break;
				case LookingDirection.Up:
				currentAnim = WalkUp;
				break;
				case LookingDirection.Left:
				currentAnim = WalkLeft;
				break;
				case LookingDirection.Right:
				currentAnim = WalkRight;
				break;
			}
			break;
			case AnimationStates.Shooting:
			switch (lookDir)
			{
				case LookingDirection.Down:
				currentAnim = ShootDown;
				break;
				case LookingDirection.Up:
				currentAnim = ShootUp;
				break;
				case LookingDirection.Left:
				currentAnim = ShootLeft;
				break;
				case LookingDirection.Right:
				currentAnim = ShootRight;
				break;
			}
			break;
			case AnimationStates.MovingAndShooting:
			switch (lookDir)
			{
				case LookingDirection.Down:
				currentAnim = WalkAndShootDown;
				break;
				case LookingDirection.Up:
				currentAnim = WalkAndShootUp;
				break;
				case LookingDirection.Left:
				currentAnim = WalkAndShootLeft;
				break;
				case LookingDirection.Right:
				currentAnim = WalkAndShootRight;
				break;
			}
			break;
		}
	}
	/// <summary>
	/// playing the current animation.
	/// </summary>
	/// <returns></returns>
	private IEnumerator PlayAnimation ()
	{
		while (1 != 2)
		{
			if (currentAnim != null)
			{
				render.sprite = currentAnim[currentSpriteID];
				yield return new WaitForSeconds (0.1f);
				currentSpriteID++;
				if (currentAnim.Length == currentSpriteID)
				{
					currentSpriteID = 0;
				}
			}
			yield return null;
		}
	}
}
