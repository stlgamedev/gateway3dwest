using UnityEngine;
using System.Collections;

public class Character : MonoBehaviour {
	//movement variables
	public CharacterController character;
	public Camera view;
	protected Vector3 moveDirection;
	public float speed = 10f;
	public float sprintSpeed = 7.5f;
	public float cameraXSensitivity = 10f;
	public float cameraYSensitivity = 10f;
	protected Vector3 cameraRotation;
	public float jumpSpeed = 10f;
	public float gravity = 9.8f;
	public Animator playerAnimator;
	protected bool isSprinting = false;
	//private bool isStriking = false;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		Movement ();
		Actions ();
		/*if (Input.GetMouseButtonDown(0)) {
			playerAnimator.SetTrigger("isStriking");
		}*/
	}
	private void Actions(){
		playerAnimator.SetFloat ("isStriking", Input.GetAxis("Strike"));
		/*if (Input.GetAxis ("Strike") > 0) {
			playerAnimator.SetBool ("isStriking", true);
			isStriking = true;
		} 
		if(isStriking){
			playerAnimator.SetBool("isStriking", false);
			isStriking = false;
		}*/
	}
	private void Movement(){
		//sprint
		if (Input.GetAxis ("Sprint") > 0 && Input.GetAxis("Forward") > 0 && !isSprinting) {
			speed += sprintSpeed;
			isSprinting = true;
		}
		if (Input.GetKeyUp (KeyCode.LeftShift) && isSprinting || Input.GetAxis ("Forward") <= 0 && isSprinting) {
			speed -= sprintSpeed;
			isSprinting = false;
		}
		//movement
		if (character.isGrounded) {
			moveDirection = new Vector3(Input.GetAxis("Right"), 0, Input.GetAxis("Forward"));
			moveDirection = transform.TransformDirection(moveDirection);
			moveDirection *= speed;
			//jump
			if (Input.GetButton("Jump")){
				moveDirection.y = jumpSpeed;
			}
			
		}
		//camera / player rotation
		transform.Rotate (new Vector3 (0, Input.GetAxis ("MouseX") * cameraXSensitivity * Time.deltaTime, 0));
		view.transform.Rotate (new Vector3 (-Input.GetAxis ("MouseY") * cameraYSensitivity * Time.deltaTime, 0, 0));
		//gravity
		moveDirection.y -= gravity * Time.deltaTime;
		//finally telling the character to move.
		character.Move(moveDirection * Time.deltaTime);
	}
}
