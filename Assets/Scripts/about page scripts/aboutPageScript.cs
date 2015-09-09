using UnityEngine;
using System.Collections;

public class aboutPageScript : MonoBehaviour {

	void Start () {
	}

	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape))Application.Quit();
	}
}
