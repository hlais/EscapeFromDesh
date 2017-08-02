using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerController : MonoBehaviour
{

	private Rigidbody2D myRigidBody; // firstly we declare the RigidBody
	public float JumpForce;
	private Animator myAnimator; // this gets access to the animator we created. on uniyt step (2) we must declare it to access it
	private float soliderHurtTime = -1; // this variable is to allow for a delay before we play the solider death animation. at onCollisionEnter2D (step 3)

	// Use this for initialization
	void Start()
	{
		myRigidBody = GetComponent<Rigidbody2D>(); // now we are Getting the componet. and assigning it to myRigidBody variable 
		myAnimator = GetComponent<Animator>(); // now we are getting component from the animator. step (2)

	}

	// Update is called once per frame
	void Update()
	{
		if (soliderHurtTime == -1) //this is true. Since its stated in the variable 
		{
			if (Input.GetButtonDown("Jump")) //"Jump" is the standard unity definition
			{
				//myRigidBody.AddForce(transform.up * JumpForce); //adding force. Transform UP. I made jumpforce a public variable // (code removed replaced with better jump CS)
				myRigidBody.velocity = Vector2.up * JumpForce; // this is apart of the better jump. allowing sharper gravity pull on down

			}
			// code below switches animator jump to running. when we press the jump key 
			myAnimator.SetFloat("vVelocity", myRigidBody.velocity.y); // we are referencing vVelocity from unity: Animator Parameter. we are picking up velocity in the Y direction. we are setting vvelocity parameter to the current velocity 
		}
		else
		{
			if (Time.time > soliderHurtTime + 2) // time.time gets the current time in the game. 2 secs after we collided
			{
				SceneManager.LoadScene("Game"); // this would reload the scene. Named "Game";
			}
		}
	}
	void OnCollisionEnter2D(Collision2D collision) // if something collides with GameObejct funtion
	{
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Enemy")) //we made a layer.(click drop down-> add layer "Enemy") on the game object(i.e cactus).
		{
			foreach (PrefabsSpawner spawner in FindObjectsOfType<PrefabsSpawner>()) // this disables the Prefabs spawner class. Read below MOveleft for more details.
			{
				spawner.enabled = false;
			}
			foreach (MoveLeft moveLefter in FindObjectsOfType<MoveLeft>()) // goes through each moveleft object in the array of moveleft // <MoveLeft> is a scripte//
			{
				moveLefter.enabled = false; //disable the script in code. Just like if were to disable the solider . codes is to stop cactus , when player collided with cactus "Enemy" 
			}
			soliderHurtTime = Time.time; // we made bunnyhurt time equal to the game time Time.Time is in secs.
			myAnimator.SetBool("soliderHurt", true); // this accesses the Animator via myAnimator. SetBool is used since its a parameter on the animation in unity to play "soliderHurt" animation)
			myRigidBody.velocity = Vector2.zero;//we want to stop any motion that the bunny has. so we make it equal to zero. 
			myRigidBody.velocity = Vector2.up* JumpForce;; // we basically triggering the bunny to jump. using the code the above
		}

	}
}



