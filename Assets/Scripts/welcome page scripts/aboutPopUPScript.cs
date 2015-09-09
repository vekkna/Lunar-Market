using UnityEngine;
using System.Collections;

public class aboutPopUPScript : MonoBehaviour
{
		Vector3 scale;
		float rateOGrowth;
		public bool isGrowing;
		bool isShrinking;
		public GameObject rack;
		public float fullSize = 5.0f;

		void Start ()
		{
				//renderer.enabled = false; // start the pop up invisible
				scale = new Vector3 (0.0f, 0.0f, 0.0f);
				transform.localScale = scale; // and small
				rateOGrowth = Time.deltaTime * 7.0f;


		}

		void Update ()
		{	
				if (isGrowing && scale.x < fullSize) {
						scale.x += rateOGrowth;
						scale.y += rateOGrowth;
						scale.z += rateOGrowth;
				} 
				if (isShrinking && scale.x > 0) {
						scale.x -= rateOGrowth;
						scale.y -= rateOGrowth;
						scale.z -= rateOGrowth;

						if (scale.x <= 0) {

								int index = rack.GetComponent<rackScript> ().index;
								rackScript rs = rack.GetComponent<rackScript> ();

								if (index >= rs.scrollRack.Length - 1){ 
									Application.LoadLevel("welcome level");
								}

								else {
										rs.index++;
										rs.scrollRack [index + 1].GetComponent<aboutPopUPScript> ().isGrowing = true;
								} 

				Destroy(gameObject);
						}
				}

				transform.localScale = scale;

				if (Input.GetKeyDown (KeyCode.Escape)) {
						Application.LoadLevel("welcome level");
				}
		}

		void OnMouseDown ()
		{
				isGrowing = false;
				isShrinking = true;


		}
}