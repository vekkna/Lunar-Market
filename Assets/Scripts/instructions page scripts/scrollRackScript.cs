using UnityEngine;
using System.Collections;

public class scrollRackScript : MonoBehaviour {

	public GameObject[] scrolls;
//	public GameObject transition;
	public int index;
///	bool hasBegun;

	void Start () {

		index = 0;
		//scrolls[index].renderer.enabled = true;
		//scrolls[index].GetComponent<scrollScript>().isGrowing = true;
	}

//	void Update () {
//
//		if (transition == null && !hasBegun){
//			scrolls[index].GetComponent<scrollScript>().isGrowing = true;
//			hasBegun = true;
//		}
//	
//	}
}