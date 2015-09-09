using UnityEngine;
using System.Collections;

public class transitionScript : MonoBehaviour {

	public float rate = 0.6f;
	internal Color col;
	public GameObject button1, button2;

	void Start () {	
		col = gameObject.renderer.material.color;
		col.a = 1;
	}

	void Update () {
		if (col.a >= 0){
			col.a -= rate * Time.deltaTime;
		}
		else{
			button1.GetComponent<buttonEntryScript>().isActive = true;
			button2.GetComponent<buttonEntryScript>().isActive = true;
		}
		gameObject.renderer.material.color = col;
	}
}