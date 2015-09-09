using UnityEngine;
using System.Collections;

public class buttonEntryScript : MonoBehaviour {

	public GameObject targetPosition, contrail; 
	Vector3 tempPosition;
	public float entrySpeed = 500;
	public bool isActive;


	void Start () {
		
		tempPosition = transform.position;
	}

	void Update () {

		if (isActive){
		if (gameObject.tag == "instructions"){
		if (targetPosition.transform.position.x <= transform.position.x)
		{
			tempPosition.x -= Time.deltaTime * entrySpeed;
		}
			else{
				contrail.particleEmitter.emit = false;
			}
		}
		else if (gameObject.tag == "play"){
			if (targetPosition.transform.position.x >= transform.position.x)
			{
				tempPosition.x += Time.deltaTime * 100;
			}
			else{
				contrail.particleEmitter.emit = false;
			}
		}

		transform.position = tempPosition;

		}
	}
}
