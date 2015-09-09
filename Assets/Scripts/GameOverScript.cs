using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour {

	public GameObject gameOverMessage;
	public string message;
	public string winner;

	// Use this for initialization
	void Start () {
		winner = "Peter";
		message = "Game Over!\n" + winner + " has won!";

		GetComponent<TextMesh> ().text = message;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
