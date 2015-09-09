using UnityEngine;
using System.Collections;

public class GoodsScript : MonoBehaviour
{
		internal bool moving;
		private GameObject redShelfp1, blueShelfp1, greenShelfp1, yellowShelfp1, redShelfp2, blueShelfp2, greenShelfp2, yellowShelfp2;
		public Vector3 direction;
		public float speed = 2.0f;
		public Vector3 target;
	public bool hasEntered;

		void Start ()
		{
		hasEntered = false;
				moving = false;
				direction = new Vector3 ();
				target = new Vector3 ();
				redShelfp1 = GameObject.Find ("redShelfTarget1p1");
				blueShelfp1 = GameObject.Find ("blueShelfTarget1p1");
				greenShelfp1 = GameObject.Find ("greenShelfTarget1p1");
				yellowShelfp1 = GameObject.Find ("yellowShelfTarget1p1");

				redShelfp2 = GameObject.Find ("redShelfTarget1p2");
				blueShelfp2 = GameObject.Find ("blueShelfTarget1p2");
				greenShelfp2 = GameObject.Find ("greenShelfTarget1p2");
				yellowShelfp2 = GameObject.Find ("yellowShelfTarget1p2");

				
		}

		void Update ()
		{
				if (moving) {
					//	direction = (target - gameObject.transform.position);
						gameObject.transform.position += direction.normalized * speed;
				}
		}

		public void buy (string player)
		{
				if (player.Equals ("player one")) {

						if (gameObject.tag == "red good") {		
								target = redShelfp1.transform.position;	

						} else if (gameObject.tag == "blue good") {		
								target = blueShelfp1.transform.position;
						} else if (gameObject.tag == "green good") {	
								target = greenShelfp1.transform.position;	
						} else {	
								target = yellowShelfp1.transform.position;
						}
				} else if (player.Equals ("player two")) {

						if (gameObject.tag == "red good") {		
								target = redShelfp2.transform.position;	
						} else if (gameObject.tag == "blue good") {		
								target = blueShelfp2.transform.position;
						} else if (gameObject.tag == "green good") {	
								target = greenShelfp2.transform.position;	
						} else {	
								target = yellowShelfp2.transform.position;
						}
				}
				direction = (target - gameObject.transform.position);	
				moving = true;
		}
}