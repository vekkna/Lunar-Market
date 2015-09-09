using UnityEngine;
using System.Collections;

public class SurrenderScript : MonoBehaviour {

	public GameObject myBank, hisBank, hisTotalScoreDisplay;
	internal int hisTotalScore;
	public GameObject[] shelves1, shelves2;
	public AudioClip clip;

	void Start(){
	}

	void Update () {

		if(Input.touchCount > 0){
			
			for (int i = 0; i<Input.touchCount; i++) {
				
				if (Input.GetTouch(i).phase == TouchPhase.Began){
					
					Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (i).position);
					Vector2 touchPos = new Vector2 (wp.x, wp.y);
					float x = transform.position.x;
					float y = transform.position.y;
					if (touchPos.x > x - 5 && touchPos.x < x + 5
					    &&
					    touchPos.y > y - 5 && touchPos.y < y + 5){

						Surrender();
					}
				}
			}
		}
	}

//	void OnMouseDown(){
//
//		Surrender();
//	}
	void Surrender(){

		int myBalance = myBank.GetComponent<BankScript>().balance;
		int hisBalance = hisBank.GetComponent<BankScript>().balance;
		if (myBalance < hisBalance){
			audio.PlayOneShot(clip);
			hisTotalScoreDisplay.GetComponent<totalScoreScript>().updateScore(hisBalance);
		}
	}
}