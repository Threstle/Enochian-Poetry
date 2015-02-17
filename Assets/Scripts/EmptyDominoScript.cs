using UnityEngine;
using System.Collections;

public class EmptyDominoScript : MonoBehaviour {

	public int valueToGet;
	public int valueStored;
	public bool isOk = false;
	// Use this for initialization
	void Start () {
		valueStored = 666;
	}
	
	// Update is called once per frame
	void Update () {
		if (valueToGet == valueStored)
			isOk = true;
		else
			isOk = false;
	}

	void OnTriggerEnter2D(Collider2D collision){
		Debug.Log(collision.name);
		if (collision.tag == "DragDomino") {
			if(collision.GetComponent<DragAndDropScript>().isDragged){
				Debug.DrawLine (transform.position, collision.transform.position, Color.red);
			}
			else{
				Vector3 newPos = new Vector3(transform.position.x,transform.position.y,collision.transform.position.z);
				collision.transform.position = newPos;
				valueStored = collision.GetComponent<DragDominoScript>().sign;
			}
		}

	}

	void OnTriggerStay2D(Collider2D collision){
		Debug.Log ("STAY" + collision.name);
	}

	void OnTriggerExit2D(Collider2D collision){
		Debug.Log("H");
		valueStored = 666;
	
	}
}
