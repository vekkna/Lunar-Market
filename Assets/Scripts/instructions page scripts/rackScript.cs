using UnityEngine;
using System.Collections;

public class rackScript : MonoBehaviour {

	public GameObject[] scrollRack;
	public int index;

	void Start () {

		index = 0;
		scrollRack[index].renderer.enabled = true;
		scrollRack[index].GetComponent<aboutPopUPScript>().isGrowing = true;
	
	}
}
