// Coded by Shashank.S - Creator of SandS Arts , Mail me at sandsarts.developer@gmail.com
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour {
	GameObject Player;           //reference of player to use in other method

	//Function used to detect collision
	void OnTriggerEnter(Collider obj)
	{
		//Checking whether collided object has a tag caleed Player
		if (obj.CompareTag ("Player")) {
			Player = obj.gameObject;

			obj.GetComponent<Player> ().health += 7f;                                                                                                  //Increasing health of the player
			obj.GetComponent<Renderer>().sharedMaterial.color=Random.ColorHSV();              //changing color of the Player
			obj.transform.localScale = new Vector3 (.5f,.5f,.5f);                                                                            //changing scale of the Player
		    
			//Destroying Colliders and mesh renderers
			Destroy (GetComponent<Collider> ());
			Destroy (GetComponent<MeshRenderer> ());

			//Calling Reset method after 3s
			Invoke ("Reset", 3f);

			Debug.Log ("PlayerCollided");
		} 

		//if obj doesnt have Player tag
		else
			Debug.Log ("Other ");
		
	}

	//Resetting player size in this method
	void Reset()
	{
		Player.transform.localScale = new Vector3 (1f,1f,1f);
		Destroy (gameObject);
	}
}
