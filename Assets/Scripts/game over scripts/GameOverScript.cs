// Placed on the background plane of the game over scene
using UnityEngine;
using System.Collections;

public class GameOverScript : MonoBehaviour
{
	public float textOffset, arrowOffset; // to correct their positions when rotated

		void Start ()
		{
				if (GlobalData.winner == 2) { // if player two has won, flip the display

						transform.rotation = Quaternion.Euler (0, 0, 180);
						transform.position = new Vector3 (15.0f, 12.0f, 10.0f);
						GetComponentInChildren<arrowScript>().isReveresed = true;
				}
		}

		void Update ()
		{
				if (Input.GetKeyDown (KeyCode.Escape)) {
						Application.LoadLevel ("Welcome Level");
				}
		}
}




