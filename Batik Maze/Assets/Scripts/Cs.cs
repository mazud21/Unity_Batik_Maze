using UnityEngine;
using System.Collections;
public class Cs : MonoBehaviour {

	void Start () 
	{
		Input.gyro.enabled = true;
	}

	void Update () 
	{
		var x = Input.gyro.rotationRateUnbiased.x;
		transform.eulerAngles = new Vector3 (x, 0, 0);

	}
}