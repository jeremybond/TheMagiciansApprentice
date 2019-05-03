//Created By: Jeremy Bond
//Date: 03/05/2019

using UnityEngine;
using System.Collections;

[RequireComponent (typeof (CharacterAnimation))]
[RequireComponent (typeof (CharacterMovement))]
[RequireComponent (typeof (CharacterCollision))]
[RequireComponent (typeof (Collider2D))]
[RequireComponent (typeof (Rigidbody2D))]
public class CharacterJumpDown : MonoBehaviour 
{
    public GameObject RaycastCenter;
    private bool onTheWall = false;
    private CharacterCollision characterCollisionScript;
    private CharacterAnimation characterAnimationScript;
    private CharacterMovement characterMovementScript;
    private Collider2D playerCollider;
    private Rigidbody2D characterRigidbody;

    /// <summary>
    /// The Awake function is setup to make sure the required public variables are filled.
    /// </summary>
	protected void Awake () 
	{
        characterCollisionScript = gameObject.GetComponent<CharacterCollision>();
        characterAnimationScript = gameObject.GetComponent<CharacterAnimation>();
        characterMovementScript = gameObject.GetComponent<CharacterMovement>();
        playerCollider = gameObject.GetComponent<Collider2D> ();
        characterRigidbody = gameObject.GetComponent<Rigidbody2D>();
        if (characterCollisionScript == null)
        {
            Debug.LogError("Forgotten component: The player object doesn't has the CharacterCollision script.");
        }
        if (playerCollider == null)
        {
            Debug.LogError("Forgotten component: The player object doesn't have a collider2D, you rascal!");
        }
        if (RaycastCenter == null)
        {
            Debug.LogError ("Forgotten reference: No raycast origin point is assigned to the jumpdown script on the player object.");
        }
    }
    
    /// <summary>
	/// The update function is used to check if the character is trying to walk.
	/// </summary>
	protected void Update ()
    {
        if (Input.GetAxis ("Horizontal") != 0 || Input.GetAxis ("Vertical") !=0)
        {
            ReadyToJumpCheck();
        }
    }

    /// <summary>
    /// Check the position in front of the player for a wall and check for an open space to land on after jumping off the all.
    /// If both are correct the jump function is initiated.
    /// </summary>
    private void ReadyToJumpCheck ()
    {
        Vector2 playerPosition = RaycastCenter.transform.position;
        //Debug.Log(characterRigidbody.velocity + " velocity vs  input " + Input.GetAxis("Horizontal") + "," + Input.GetAxis("Vertical"));
        Vector2 toCheckCoordinates = new Vector2(characterRigidbody.velocity.x/2, characterRigidbody.velocity.y/2);
        Vector2 wallCheckPosition = playerPosition + (toCheckCoordinates / 3);
        Vector2 coordinates = playerPosition + toCheckCoordinates;
        RaycastHit2D hitCoordinates = Physics2D.Raycast (coordinates, new Vector2());
        RaycastHit2D hitWall = Physics2D.Raycast (wallCheckPosition, new Vector2());
        //Debug.DrawLine(coordinates, coordinates + (toCheckCoordinates/10), Color.white);
        //Debug.DrawLine(wallCheckPosition, wallCheckPosition + (toCheckCoordinates/10), Color.red);

        if (hitWall.collider != null)
        {
            if (hitWall.collider.tag == ConstStrings.WALLTAG)
        {
                if (hitCoordinates.collider == null)
                {
                    if (characterCollisionScript.onTheWall)
                    {
                        Jump ();
                    }
                }
            }
        }
    }

    /// <summary>
    /// The actions required to jump off a wall
    /// </summary>
    private void Jump ()
    {
        MoveOverWall(characterAnimationScript.lookDir);
        StartCoroutine (TemperaryDisableMovement ());
    }

    /// <summary>
    /// the movement to get over the wall
    /// </summary>
    /// <param name="dir"></param>
    private void MoveOverWall (LookingDirection dir)
    {
        Vector2 pos = transform.position;
        switch (dir)
        {
            case LookingDirection.Down:
            transform.position = Vector2.Lerp (pos, pos + Vector2.down, 0);
            break;
            case LookingDirection.Up:
            transform.position = Vector2.Lerp (pos, pos + Vector2.up, 0);
            break;
            case LookingDirection.Left:
            transform.position = Vector2.Lerp (pos, pos + Vector2.left, 0);
            break;
            case LookingDirection.Right:
            transform.position = Vector2.Lerp (pos, pos + Vector2.right, 0);
            break;
        }
    }

    /// <summary>
    /// Disable the movement and colliders and enable them after waiting a sertain time.
    /// </summary>
    /// <returns></returns>
    private IEnumerator TemperaryDisableMovement ()
    {
        UpdateGameObjectsComponents(false);
        characterAnimationScript.JumpOfWallAnimation();
        yield return new WaitForSeconds(.5f);
        UpdateGameObjectsComponents(true);
    }

    private void UpdateGameObjectsComponents (bool value)
    {
        playerCollider.enabled = value;
        characterMovementScript.enabled = value;
        characterCollisionScript.ChangeOnTheWallVariable(false);
    }
}
