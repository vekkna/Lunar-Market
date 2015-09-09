using UnityEngine;
using System.Collections;

public class ButtonScript : MonoBehaviour
{
	public GameObject lot;
	private GameObject[]goods, goodsCopy;
	private int price;
	public GameObject bank;
	private int balance;
	public AudioClip clip;
	public GameObject debugger;

	void Start(){
	}

	void Update ()
	{
		if(Input.touchCount > 0){

			for (int i = 0; i<Input.touchCount; i++) {
				
				if (Input.GetTouch(i).phase == TouchPhase.Began){

					Vector3 wp = Camera.main.ScreenToWorldPoint (Input.GetTouch (i).position);
					Vector2 touchPos = new Vector2 (wp.x, wp.y);

					float x = transform.position.x;
					float y = transform.position.y;
					if (touchPos.x > x - 5 && touchPos.x < x + 5
					    &&
					    touchPos.y > y - 5 && touchPos.y < y + 5){

						goods = lot.GetComponent<LotScript> ().currentGoods;
						goodsCopy = new GameObject[goods.Length];
						for (int j = 0; j < goodsCopy.Length; j++){
							goodsCopy[j] = goods[j];
							
						}
						price = lot.GetComponent<LotScript>().price;
						balance = bank.GetComponent<BankScript>().balance;
						
						if (balance >= price){
							audio.PlayOneShot(clip);
							if (gameObject.tag == "player one") {
								foreach (GameObject good in goodsCopy) {
									good.GetComponent<GoodsScript> ().buy ("player one");
								}
							} else {
								
								foreach (GameObject good in goodsCopy) {
									good.GetComponent<GoodsScript> ().buy ("player two");
								}
							}
							
							balance -= price;
							bank.GetComponent<BankScript>().balance = balance;
							lot.GetComponent<LotScript>().GenerateNewLot();
						}
					}
				}
			}
		}
	}
	}