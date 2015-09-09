using UnityEngine;
using System.Collections;

public class BankColliderScript : MonoBehaviour {

	void Start () {
	}

	void Update () {
	}

	void OnTriggerEnter2D(Collider2D other){
		if (other.tag == "destroy me"){
		Destroy(other.gameObject);
		}
	}
}