using UnityEngine;
using System.Collections;

public class textPopUpScript : MonoBehaviour {

	Vector3 scale;
	float rateOGrowth;
	public bool isGrowing;
	
	void Start ()
	{
		scale = new Vector3 (0, 0, 0);
		transform.localScale = scale; // and small
		rateOGrowth = Time.deltaTime * 7.0f;
		isGrowing = true;
		
	}
	
	void Update ()
	{	
		if (isGrowing && scale.x < 7.0f) {
			scale.x += rateOGrowth;
			scale.y += rateOGrowth;
			scale.z += rateOGrowth;
		} 
		if (!isGrowing && scale.x > 0) {
			scale.x -= rateOGrowth;
			scale.y -= rateOGrowth;
			scale.z -= rateOGrowth;
		}
		
		transform.localScale = scale;
}
}