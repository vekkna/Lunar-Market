using UnityEngine;
using System.Collections;

public class aboutButtonScript : MonoBehaviour {

	public GameObject popUp;

	void Start () {	
	}

	void OnMouseDown() {

		popUp.renderer.enabled = true;
		popUp.GetComponent<aboutPopUPScript>().isGrowing = true;

	}
}
