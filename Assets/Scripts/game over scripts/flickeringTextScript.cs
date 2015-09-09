using UnityEngine;
using System.Collections;

public class flickeringTextScript : MonoBehaviour {

	public float flickerDuration = 0.1f;
	float timer;
	Color originalColor; 
	Color flickerColor = new Color(0, 0, 0);

	void Start () {
		timer = flickerDuration;
		originalColor = renderer.material.color;
	}

	void Update () {

		Color currentColor = renderer.material.color;

		timer -= Time.deltaTime;
		if (timer <= 0){
			currentColor = (currentColor == originalColor) ? flickerColor : originalColor;
			renderer.material.SetColor("_Color", currentColor);
			timer = flickerDuration;
		}
	
	}
}
