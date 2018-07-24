using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

    public Rigidbody Controller;
    public VirtualJoystick VirtualJoystick;
	public VirtualJoystick CameraJoystick;

    private Transform _camTransform;
	public float MoveSpeed = 2.0f;
    public float Drag = 0.5f;
    
	public Text countText;
	public Text winText;

    private int count;

	void Start () {
        Controller.drag = Drag;

        _camTransform = Camera.main.transform;

        count = 0;
		SetCountText ();
		winText.text = "";
    }
	
	void Update () {
        Vector3 dir = Vector3.zero;
		dir.x = Input.GetAxis ("Horizontal");//* Time.deltaTime * 150.0f;;
		dir.z = Input.GetAxis("Vertical");//* Time.deltaTime * 3.0f;;

        if (VirtualJoystick.InputVector != Vector3.zero) {
            dir = VirtualJoystick.InputVector;
        }

        Vector3 rotatedDir = _camTransform.TransformDirection(dir);
        rotatedDir = new Vector3(rotatedDir.x, 0, rotatedDir.z);
        rotatedDir = rotatedDir.normalized * dir.magnitude;

        Controller.AddForce(rotatedDir * MoveSpeed);
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
	int score = 8;
	public float time = 20; //Seconds to read the text
	void SetCountText(){
		countText.text = "" + count.ToString () + " dari " + score;
		if (count == score) {
			winText.text = "Makna batik Kawung sendiri ada beberapa, diantaranya adalah pengendalian diri yang sempurna," +
				" hati yang bersih tanpa adanya keinginan untuk ria, dan masih banyak lagi. " +
				"Nama dan motif Kawung dilansir berasal dari dua sumber. Yang pertama adalah serangga Kwangwung, " +
				"dan yang kedua adalah buah Kolang-Kaling. Motif Kawung termasuk kedalam beberapa motif larangan Keraton, " +
				"yang mana dulu hanya boleh digunakan oleh kalangan kerajaan saja.";
			Destroy (winText, time);
		} 
	}
}