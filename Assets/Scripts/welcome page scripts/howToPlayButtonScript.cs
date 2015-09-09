using UnityEngine;
using System.Collections;

public class howToPlayButtonScript : MonoBehaviour {

	void Start () {
	
	}

	void OnMouseDown(){
		Application.LoadLevel("instructions level");

}
}