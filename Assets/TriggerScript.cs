using UnityEngine;
using System.Collections;

public class TriggerScript : MonoBehaviour {

	TokenScript ts;

	// Use this for initialization
	void Start () {

		ts = GameObject.Find("spinner").GetComponent<TokenScript>();
	
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other) {

		//Debug: print the name
		//ts.text.text = other.name;

		// Find the child object
		GameObject child = other.transform.GetChild(0).gameObject;

		// Get the index of that object
		// Ty @ DevMynd wrote this; uses clojure / Lambda function
		int nameIndex = System.Array.FindIndex (ts.tokens, token => token.name == child.name);
		print("nameIndex: " + nameIndex);

		//Destroy it
		//Destroy (child);
		Destroy(child);

		// Instantiate the next GameObject in the array

		// The next index to instantiate is the index just destroyed
		// plus the number of slots

		int nextIndex;
		print ("direction at time of trigger: " + ts.direction);

		// determine the nextIndex based on the current index
		if (ts.direction == "CW") {

			nextIndex = nameIndex + ts.slots.Length;
			print ("CW so next index: " + nextIndex);

		} else {

			nextIndex = nameIndex - ts.slots.Length;
			print ("CCW so next index: " + nextIndex);

		}

		if (nextIndex < 0 || nextIndex > (ts.tokens.GetUpperBound(0))) {

			print ("OUT OF BOUNDS");

		} else {
			
			string newTokenName = "Token " + nextIndex.ToString ();
			ts.InstantiateTokenInSlot (ts.tokens [nextIndex], other.gameObject, newTokenName);

		}


	}
}
