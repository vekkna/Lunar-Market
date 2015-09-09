using UnityEngine;
using System.Collections;

public class VictoryDisplayScript : MonoBehaviour {

	public GameObject arrow1, arrow2; 
	GameObject globalDataObject;

	void Start () {

		arrow1.renderer.enabled = false;
		arrow2.renderer.enabled = false;

		globalDataObject = GameObject.Find("_GlobalDataObject");
		if (globalDataObject == null){
			Debug.Log("no data");
		}
		if (globalDataObject.GetComponent<GlobalData>().winner == 1){
			arrow2.renderer.enabled = true;
		}
		else if (globalDataObject.GetComponent<GlobalData>().winner == 2){
			arrow1.renderer.enabled = true;
	}
		else{
			Debug.Log("no winner assigned");
}
}
}