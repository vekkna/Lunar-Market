using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LotScript : MonoBehaviour {

	public GameObject redGood, blueGood, greenGood, yellowGood;
	public float offsetWhenTwoGoods = 1.5f;
	public float offsetWhenThreeGoods = 3.0f;
	public GameObject pricePlayerOne, pricePlayerTwo;

	public int price;
	public int nextReset = 2;
	float rateOfChange = GlobalData.rateOfChange;
	float rate;

	internal GameObject[] totalGoods, currentGoods;
	GameObject goodOne, goodTwo, goodThree;
	int numberOfGoods, random;
	Vector3 positionWhenOneGood;
	Vector3[] positionsWhenTwoGoods, positionsWhenThreeGoods;
	public int priceLowerRange = 15; 
	public int priceUpperRange = 30;

	void Start () {
		if (GlobalData.difficultyLevel == 1){
			totalGoods = new GameObject[]{greenGood, blueGood};
		}
		else if(GlobalData.difficultyLevel == 2){
			totalGoods = new GameObject[]{yellowGood, blueGood, greenGood};
		}
		else {
			totalGoods = new GameObject[]{redGood, blueGood, greenGood, yellowGood};
		}


		positionWhenOneGood = new Vector3();
		positionWhenOneGood.Set (transform.position.x, transform.position.y, transform.position.z);

		positionsWhenTwoGoods = new Vector3[2];
		positionsWhenTwoGoods[0].Set(transform.position.x, transform.position.y + offsetWhenTwoGoods, transform.position.z);
		positionsWhenTwoGoods[1].Set(transform.position.x, transform.position.y - offsetWhenTwoGoods, transform.position.z);

		positionsWhenThreeGoods = new Vector3[3];
		positionsWhenThreeGoods[0].Set(transform.position.x, transform.position.y + offsetWhenThreeGoods, transform.position.z);
		positionsWhenThreeGoods[1].Set(transform.position.x, transform.position.y, transform.position.z);
		positionsWhenThreeGoods[2].Set(transform.position.x, transform.position.y - offsetWhenThreeGoods, transform.position.z);

		currentGoods = new GameObject[1];
		GenerateNewLot();

		rate = rateOfChange;
	}

	void Update ()
	{
		rate -= Time.deltaTime;
		if (rate < 0) {
			
			price -= 1;
			rate = rateOfChange;
			
			if (price < nextReset) {
				EmptyLot();
				GenerateNewLot();
				
			}
		}
		
		pricePlayerOne.GetComponent<TextMesh> ().text = price.ToString ();
		pricePlayerTwo.GetComponent<TextMesh> ().text = price.ToString ();
	}

	public void GenerateNewLot(){

		random = Random.Range(0, 4);
		
		if(random == 0 || random == 1){
			numberOfGoods = 2;
			currentGoods = new GameObject[numberOfGoods];
			currentGoods[0] = Instantiate(totalGoods[Random.Range(0, totalGoods.Length)], positionsWhenTwoGoods[0], transform.rotation) as GameObject;
			currentGoods[1] = Instantiate(totalGoods[Random.Range(0, totalGoods.Length)], positionsWhenTwoGoods[1], transform.rotation) as GameObject;

		}
		else if(random == 2){
			numberOfGoods = 1;
			currentGoods = new GameObject[numberOfGoods];
			currentGoods[0] = Instantiate(totalGoods[Random.Range(0, totalGoods.Length)], positionWhenOneGood, transform.rotation) as GameObject;
	
		}
		else{
			numberOfGoods = 3;
			currentGoods = new GameObject[numberOfGoods];
			currentGoods[0] = Instantiate(totalGoods[Random.Range(0, totalGoods.Length)], positionsWhenThreeGoods[0], transform.rotation) as GameObject;
			currentGoods[1] = Instantiate(totalGoods[Random.Range(0, totalGoods.Length)], positionsWhenThreeGoods[1], transform.rotation) as GameObject;
			currentGoods[2] = Instantiate(totalGoods[Random.Range(0, totalGoods.Length)], positionsWhenThreeGoods[2], transform.rotation) as GameObject;

		}

		price = Random.Range (priceLowerRange, priceUpperRange);
		//nextReset = Random.Range (2, priceLowerRange);
	}

	public void EmptyLot(){
		foreach(GameObject good in currentGoods){
			DestroyObject(good);
		}
	}
}
