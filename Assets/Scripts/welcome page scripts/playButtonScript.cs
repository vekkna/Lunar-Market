using UnityEngine;
using System.Collections;

public class playButtonScript : MonoBehaviour {
	
	void Start () {
	}
	void OnMouseDown() {
		Application.LoadLevel("Game level");
	}
}
