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


	// Use this for initialization
	void Start () {

		// initialize values
		yArray = new float[2];
		yArray [0] = 0.0f;
		yArray [1] = 0.0f;

		// set token names
		for (int i = 0; i < tokens.Length; i++) {

			string thisName = "Token" + i.ToString();
			tokens [i].name = thisName;

		}


		for (int i = 0; i < slots.Length; i++) {

			// Find the slot, and insert the appropriate token
			string thisSlot = "Slot" + i.ToString ();
			GameObject thisSlotGameObject = GameObject.Find (thisSlot);
			Vector3 thisPosition = thisSlotGameObject.transform.position + new Vector3 (0, verticalOffset, 0);

			// Instantiate the token
			string thisTokenName = "Token" + i.ToString ();
			Instantiate(tokens[i], thisPosition, new Quaternion()).name = thisTokenName;

			// Find the token by name
			GameObject thisToken = GameObject.Find (thisTokenName);
			thisToken.transform.SetParent (thisSlotGameObject.transform);



		}
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		checkDirection ();
		updateTokens ();


	}

	string checkDirection() {

		string direction;

		// Look for Y rotation.
		spinnerYRot = transform.localEulerAngles.y;
		//text.text = spinnerYRot.ToString();

		yArray [0] = yArray [1];
		yArray [1] = spinnerYRot;

		// Is this frame's EulerAngle Y greater than the last frame's?
		// This is a 'hack-y' way of getting the direction of movement.
		// Look up dot product, cross product for 'real' ways of calculating this
		if (yArray [1] > yArray [0]) {
			direction = "CLOCKWISE";
		} else {
			direction = "COUNTERCLOCKWISE";
		}

		text.text = direction;
		return direction;

	}

	void updateTokens(){

		// We have this TOTAL array of tokens
		// We also need the "CURRENT" array of tokens
		// which should shift depending on the current state of the slider

		// This re-evaluation should happen every time a SLOT hits the TOGGLE


	}

}
