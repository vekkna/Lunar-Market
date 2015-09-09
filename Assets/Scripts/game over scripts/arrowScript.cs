using UnityEngine;
using System.Collections;

public class arrowScript : MonoBehaviour
{
		float lowestPoint = -4.0f, highestPoint = 10.0f;
		float originalYPos;
	bool isFalling;
	public bool isReveresed;
		Vector3 temp;

		void Start ()
		{
				originalYPos = transform.position.y;
				isFalling = true;
				temp = transform.position;
		}

		void Update ()
		{
		if (!isReveresed){
		if (isFalling){
				temp.y -= Time.deltaTime * 10;
		}
		if (!isFalling){
			temp.y += Time.deltaTime * 10;
		}
	
		if (temp.y < lowestPoint){
			isFalling = false;
		}

		if (temp.y > originalYPos){
			isFalling = true;
		}
		}

		else{
			if (isFalling){
				temp.y += Time.deltaTime * 10;
			}
			if (!isFalling){
				temp.y -= Time.deltaTime * 10;
			}
			
			if (temp.y > highestPoint){
				isFalling = false;
			}
			
			if (temp.y < originalYPos){
				isFalling = true;
			}
		}

		transform.position = temp;

		}


}