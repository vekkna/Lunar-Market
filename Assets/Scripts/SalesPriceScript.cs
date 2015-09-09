using UnityEngine;
using System.Collections;

public class SalesPriceScript : MonoBehaviour {

	internal int price;
	public GameObject priceDisplayP1, priceDisplayP2;
	public float rateOfChange = 50.0f; // the smaller the faster prices increase
	float rate;

	// Use this for initialization
	void Start () {

		price = 0;
		rate = rateOfChange;
	}
	
	// Update is called once per frame
	void Update () {

		rate -= Time.deltaTime;
		if (rate < 0){
			price++;
			rate = rateOfChange;
		}

		priceDisplayP1.GetComponent<TextMesh> ().text = price.ToString ();
		priceDisplayP2.GetComponent<TextMesh> ().text = price.ToString ();
	}
}