using UnityEngine;
using System.Collections;

public class totalScoreScript : MonoBehaviour
{

		internal int totalScore;
		public int victoryScore = 200;
		public int player;
		public GameObject myBank, hisBank;
		public GameObject[] shelves1, shelves2;
		public GameObject[] lots;
		Vector3 scale;
		public bool isGrowing;
		float fullSize;
		bool isFluctuating;
		float originalX, originalY, originalZ;
		GameObject transitionPlane;

		void Start ()
		{
				scale = gameObject.transform.localScale;
				fullSize = scale.x * 1.2f;
				originalX = scale.x;
				originalY = scale.y;
				originalZ = scale.z;
		transitionPlane = GameObject.Find("transition plane");
		}

		void Update ()
		{
				Fluctuate ();
		}

		public void updateScore (int score)
		{
				totalScore += score;
				isGrowing = true;
				isFluctuating = true;
				if (totalScore >= victoryScore) {
						GlobalData.winner = player;
						Application.LoadLevel ("Game over level");
				} else {
						ResetGame ();
				}
				GetComponentInChildren<TextMesh> ().text = totalScore.ToString ();
		}

		void ResetGame ()
		{
		transitionPlane.GetComponent<transitionScript>().col.a = 1.0f;
//		transitionPlane.GetComponent<transitionScript>().duration = 2.0f;
	//	transitionPlane.renderer.enabled = true;
				myBank.GetComponent<BankScript> ().balance = 40;
				hisBank.GetComponent<BankScript> ().balance = 40;
				foreach (GameObject shelf in shelves1) {
						shelf.GetComponent<WarehouseScript> ().Empty ();
				}
				foreach (GameObject shelf in shelves2) {
						shelf.GetComponent<WarehouseScript> ().Empty ();
				}
				foreach (GameObject lot in lots) {
						lot.GetComponent<LotScript> ().EmptyLot ();
						lot.GetComponent<LotScript> ().GenerateNewLot ();
				}
		}

		void Fluctuate ()
		{
				if (isFluctuating) {

						if (gameObject.transform.localScale.x > fullSize) {
								isGrowing = false;
						}

			
						if (isGrowing) {
								scale.x += Time.deltaTime;
								scale.y += Time.deltaTime;
								scale.z += Time.deltaTime;
						
						} else {
								scale.x -= Time.deltaTime;
								scale.y -= Time.deltaTime;
								scale.z -= Time.deltaTime;
						}
			if (gameObject.transform.localScale.x < originalX) {
				isFluctuating = false;
				scale.x = originalX;
				scale.y = originalY;
				scale.z = originalZ;
			}
						gameObject.transform.localScale = scale;
				}
		}
}