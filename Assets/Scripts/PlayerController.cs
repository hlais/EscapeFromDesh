using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI; //import UI package


public class PlayerController : MonoBehaviour
{

	private Rigidbody2D myRigidBody; // firstly we declare the RigidBody
	public float JumpForce;
	private Animator myAnimator; // this gets access to the animator we created. on uniyt step (2) we must declare it to access it
	private float soliderHurtTime = -1; // this variable is to allow for a delay before we play the solider death animation. at onCollisionEnter2D (step 3)
	private Collider2D myCollider; // this gets access to the collider from Unity 
	public Text scoreText;// this is public on UNIty. in the unity public box we dragged. UI -> text we created onto the empty spacee
	private float startTime; // this will help us record the score.
	private int jumpLeft = 2;// this is to limit the jump we create this variable
public AudioSource jumpSFX; // appeears on unity. we then dragged the mp3 file on it.
	public AudioSource deathSFX; // appeears on unity. we then dragged the mp3 file on it.

	// Use this for initialization
	void Start()
	{
		myRigidBody = GetComponent<Rigidbody2D>(); // now we are Getting the componet. and assigning it to myRigidBody variable 
		myAnimator = GetComponent<Animator>(); // now we are getting component from the animator. step (2)
		myCollider = GetComponent<Collider2D>();

		startTime = Time.time; // we are storing away the current time



	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) // if input key code is escape. it would releaod screen from title screeen 
		{
			SceneManager.LoadScene("Title");
		}

			if (soliderHurtTime == -1) //this is true. Since its stated in the variable 
			{
			if ((Input.GetButtonDown("Jump") || Input.GetButtonDown("Fire1")) && jumpLeft > 0) //"Jump" is the standard unity definition// jumpleft, since we started on two. when we reach 0 it will stop. see below jumpLeft--;
				{
					if (myRigidBody.velocity.y < 0) // checking if velcoity is less than zero (this is addition code, i didnt really need this, could of removed it.)
					{
						myRigidBody.velocity = Vector2.zero; // if so we will canx any velcotiy (this is addition code, i didnt really need this, could of removed it.)
					}
					if (jumpLeft == 1) // following if statement reduces the hieght of the secone jump
					{
						myRigidBody.AddForce(transform.up * JumpForce * 0.75f); // (*0.75 will reduce total jump) (this is addition code, i didnt really need this, could of removed it.)
					}
					else
					{
						myRigidBody.velocity = Vector2.up * JumpForce; //else jump the full force (this is addition code, i didnt really need this, could of removed it.)
					}

					//myRigidBody.AddForce(transform.up * JumpForce); //adding force. Transform UP. I made jumpforce a public variable // (code removed replaced with better jump CS)
					myRigidBody.velocity = Vector2.up * JumpForce; // this is apart of the better jump. allowing sharper gravity pull on down
					jumpLeft--; // this would decrrease come left by one until we got zero. HOWEVER WE MUST RESET THIS JUMP. OR else wont be able to jump AGAIN!! Go oncollision  to read more.

					jumpSFX.Play();
				}
				// code below switches animator jump to running. when we press the jump key 
				myAnimator.SetFloat("vVelocity", myRigidBody.velocity.y); // we are referencing vVelocity from unity: Animator Parameter. we are picking up velocity in the Y direction. we are setting vvelocity parameter to the current velocity 
				scoreText.text = (Time.time - startTime).ToString("0.0"); // text filed setting it to. t.t - S.t. to find out how long scene has been running in secs. its a float we converting to string. in "0.0" format. One decimal 		
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
			myRigidBody.velocity = Vector2.up* JumpForce; // we basically triggering the bunny to jump. using the code the above
			myCollider.enabled = false;
			deathSFX.Play();

			float currentBestScore = PlayerPrefs.GetFloat("BestScore", 0); // this basically checks the current best score if its passed, and could be 0 if we didnt have a value before 
			float currentScore = Time.time - startTime; // this basically gets the current score  the player just acheive

			if (currentScore > currentBestScore) // if current is greater than best score . we would save the best score, PLAYERPREFS
			{
				PlayerPrefs.SetFloat("BestScore", currentScore);
			}
		}
		if (collision.collider.gameObject.layer == LayerMask.NameToLayer("Ground")) //on unity we made a new layer. Ground layer. and assignt the ground layer to duh ground!
		{
			jumpLeft = 2; //this resets the amount of jump to two again 
		}
	}
}



