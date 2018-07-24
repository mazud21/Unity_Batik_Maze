using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashCube : MonoBehaviour {

	public Text countText;
	public Text winText;

	private int count;

	// Use this for initialization
	void Start () {
		count = 0;
		SetCountText ();
		winText.text = "";
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	//destroy cube object
	void OnTriggerEnter(Collider other){
		if (other.gameObject.CompareTag ("Cube")) {
			other.gameObject.SetActive (false);
			count = count + 1;
			SetCountText ();
		}
	}
	//count cube
	int score = 10;
	void SetCountText(){
		countText.text = "" + count.ToString () + " of " + score;
		if (count == score) {
			winText.text = "All Fragments Collected";
			SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex + 2);
		}
	}
}
