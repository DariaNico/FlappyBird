using UnityEngine;
using System.Collections;

public class Column : MonoBehaviour {
	void OnTriggerEnter2D(Collider2D intruder) {
		if(intruder.GetComponent<Flapper>() != null)
		{
			//If the flapper hits the trigger collider in between the columns then
			//tell the game controller that the flapper scored.
			GameController.instance.FlapperScored();
		}
	}
}
