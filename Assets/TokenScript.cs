using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class TokenScript : MonoBehaviour {

	// Create a desired menu of tokens
	public GameObject[] tokens;
	public GameObject[] slots;

	// Vertical offset from the slots
	public float verticalOffset;

	// UI to print to
	public Text text;

	// 2-Array
	private float[] yArray;
	private float spinnerYRot;
	private float yArrayDiff;

	// Public direction string
	public string direction;

	// Use this for initialization
	void Start () {

		// initialize values
		yArray = new float[2];
		yArray [0] = 0.0f;
		yArray [1] = 0.0f;

		for (int i = 0; i < slots.Length; i++) {

			// Find the slot, and insert the appropriate token
			//string thisSlot = "Slot" + i.ToString ();
			//GameObject thisSlotGameObject = GameObject.Find (thisSlot);

			// Instantiate the token
			string thisTokenName = "Token" + i.ToString ();
			InstantiateTokenInSlot (tokens[i], slots[i], thisTokenName);

			TurnOnEndpointColliders (tokens);

		}
			

		// Print the GameObjects
		//print(tokens[0]);
//		print(tokens[1]);
//		print(tokens[2]);
//		print(tokens[3]);
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		checkDirection ();
		//updateTokens ();
		checkCollision();



	}

	string checkDirection() {
		
		// Look for Y rotation.
		spinnerYRot = transform.localEulerAngles.y;
		//text.text = spinnerYRot.ToString();

		yArray [0] = yArray [1];
		yArray [1] = spinnerYRot;

		// Is this frame's EulerAngle Y greater than the last frame's?
		// This is a 'hack-y' way of getting the direction of movement.
		// Look up dot product, cross product for 'real' ways of calculating this
		if (yArray [1] > yArray [0]) {
			direction = "CW";
		} else {
			direction = "CCW";
		}

		text.text = direction;
		return direction;

	}

	string checkCollision() {


		return "";
	}

	public void InstantiateTokenInSlot(GameObject token, GameObject slot, string name){

		Vector3 thisPosition = slot.transform.position + new Vector3 (0, verticalOffset, 0);
		Instantiate(token, thisPosition, new Quaternion()).name = name; 
			
		// Find the token by name
		GameObject thisToken = GameObject.Find (name);
		thisToken.transform.SetParent (slot.transform);

	}

	// Turns on colliders for first and last tokens so they don't go through the trigger.
	public void TurnOnEndpointColliders (GameObject[] tokenGameObjects){


		// OPTION A: Use triggers on tokens
		print ("EndpointColliders function called");

		Collider firstCollider = tokenGameObjects [0].GetComponent<Collider> ();
		Collider lastCollider = tokenGameObjects [tokenGameObjects.Length - 1].GetComponent<Collider> ();

		firstCollider.enabled = true;
		lastCollider.enabled = true;

//		// OPTION B: Use triggers on parents (slots)
//		Collider firstTokenSlotCollider = GameObject.Find(tokenGameObjects[0].name).GetComponentInParent<Collider>();
//		Collider lastTokenSlotCollider = GameObject.Find(tokenGameObjects[tokenGameObjects.GetUpperBound(0)].name).GetComponentInParent<Collider>();
//
//		firstTokenSlotCollider.isTrigger = false;
//		lastTokenSlotCollider.isTrigger = false;

	}

}
