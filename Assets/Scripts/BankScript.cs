using UnityEngine;
using System.Collections;

public class BankScript : MonoBehaviour {

	public int balance = 50; 
	public int victoryBalance = 50;
	public GameObject bank1, bank2;

	void Start () {
	}

	void Update () {
		GetComponent<TextMesh> ().text = balance.ToString ();
	}

	void OnTriggerEnter2D(Collider2D other){
		Destroy(other.gameObject);
	}

	public void VictoryCheck(){
		// if one player has enough money more than the other, he wins.

		// get the difference between their balances
		int difference = bank1.GetComponent<BankScript>().balance - bank2.GetComponent<BankScript>().balance;

		// if its great enough
		if (Mathf.Abs(difference) >= victoryBalance) {
			
			if(difference > 0){// balanceOne was the greater
				GlobalData.winner = 1;
			}
			else{// balanceTwo was the greater
				GlobalData.winner = 2;
			}
			Application.LoadLevel ("Game over level");
		}
		// if one player runs out of money, the other wins
		if (balance <= 0) {
			
			if(gameObject == bank1){
				GlobalData.winner = 2;
			}
			else if (gameObject == bank2){
				GlobalData.winner = 1;
			}
			Application.LoadLevel ("Game over level");
		}
	}
}