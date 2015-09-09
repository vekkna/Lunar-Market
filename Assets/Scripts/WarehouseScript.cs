/* If the balls are not moving within the warehouse correctly, change the distance of the warehouse
 * from the background.
 */
using UnityEngine;
using System.Collections.Generic;

public class WarehouseScript : MonoBehaviour
{
		List<GameObject> goods = new List<GameObject> ();
		GameObject copy;
		public int capacity;
		public GameObject  bank, salePrice;
		private int totalValue, opponentTotalValue, opponentContents;
		public GameObject[] targets;
		public AudioClip clip;

		void Start ()
		{
		}

		void Update ()
		{
				if (goods.Count >= capacity) {
						audio.PlayOneShot (clip);
						bank.GetComponent<BankScript> ().balance += salePrice.GetComponent<SalesPriceScript> ().price;
						foreach (GameObject g in goods) {
								g.GetComponent<GoodsScript> ().direction = bank.transform.position - gameObject.transform.position;
								g.GetComponent<GoodsScript> ().moving = true;
								g.GetComponent<CircleCollider2D> ().enabled = true;
								g.tag = "destroy me";
						}
						goods.Clear ();
						salePrice.GetComponent<SalesPriceScript> ().price = 0;
						bank.GetComponent<BankScript> ().VictoryCheck ();
				}
		}
	
		void OnTriggerEnter2D (Collider2D good)
		{
				good.GetComponent<CircleCollider2D> ().enabled = false;
				if (goods.Count < capacity) {
						
						goods.Add (good.gameObject);
						good.GetComponent<GoodsScript> ().moving = false;
						for (int i = 0; i < goods.Count; i++) {
								goods [i].transform.position = targets [i].transform.position;
						}
				} else {
						Debug.Log ("Collider: " + good);
				}
		}
}