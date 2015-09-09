using UnityEngine;
using System.Collections;

public class scrollScript : MonoBehaviour {

	Vector3 scale;
	float rateOGrowth;
	public bool isGrowing;
	public GameObject scrollRack;

	void Start () {

		renderer.enabled = false; // start the pop up invisible
		scale = new Vector3 (0.1f, 0, 0);
		transform.localScale = scale; // and small
		rateOGrowth = Time.deltaTime * 7.0f;
	}

	void Update () {

		if (isGrowing && scale.x < 7.0f) {
			scale.x += rateOGrowth;
			scale.y += rateOGrowth;
			scale.z += rateOGrowth;
		} 
		if (!isGrowing && scale.x > 0) {
			scale.x -= rateOGrowth;
			scale.y -= rateOGrowth;
			scale.z -= rateOGrowth;
		}
		if (!isGrowing && scale.x <= 0) {
			scrollRack.GetComponent<scrollRackScript>().index++;
			scrollRack.GetComponent<scrollRackScript>().scrolls[scrollRack.GetComponent<scrollRackScript>().index].GetComponent<scrollScript>().isGrowing = true;
			renderer.enabled = false;
		}
		
		transform.localScale = scale;
		
		// if the player presses back, make it inactive
		if (renderer.enabled && Input.GetKeyDown (KeyCode.Escape)) {
			isGrowing = false;
		}
			else{// spell this out more and it should be fine
				//Application.LoadLevel("Welcome level");
		}
	
	}
//
//	void OnMouseDown(){
//		isGrowing = false;
//	}
}
