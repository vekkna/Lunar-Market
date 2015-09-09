using UnityEngine;
using System.Collections;

public class BankScript : MonoBehaviour {

	public int balance = 50; 
	public int victoryBalance = 100;
	public GameObject bank1, bank2, myTotalScoreDisplay;
	public AudioClip clip;

	void Start () {
	}

	void Update () {
		GetComponent<TextMesh> ().text = balance.ToString ();
	}

	void OnTriggerEnter2D(Collider2D other){
		VictoryCheck();
		Destroy(other.gameObject);
	}

	public void VictoryCheck(){

		if (balance >= victoryBalance){
			audio.PlayOneShot(clip);
			myTotalScoreDisplay.GetComponent<totalScoreScript>().updateScore(balance);
		}
	}
}