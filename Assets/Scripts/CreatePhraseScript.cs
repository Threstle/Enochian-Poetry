using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreatePhraseScript : MonoBehaviour {
	
	public int minChar = 10;
	public int maxChar = 15;
	public GameObject dominoTemplate;
	public GameObject emptyDominoTemplate;
	public GameObject dragDominoTemplate;
	public Sprite[] chars;
	public int[] encodage;
	private List<int> phrase = new List<int>();
	private List<int> encodedPhrase = new List<int>();


	// Use this for initialization
	void Start () {
		createNewPhrase ();
		translatePhrase ();
		writePhrase ();
		writeEncodedPhrase ();
		for(int i = 0; i < 10; i++)placeDraggableDominos ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void createNewPhrase(){
		int range = (int)Random.Range (minChar, maxChar);
		for (int i = 0; i < range; i++) {
			if(Random.Range(0,15) < 14 && i!=0 && i!=range)
				phrase.Add((int)Random.Range(0,chars.Length));
			else
				phrase.Add(666);
		}
	}

	public void translatePhrase(){
		for (int i = 0; i < phrase.Count; i++) {
			if(phrase[i] == 666)
				encodedPhrase.Add(666);
			else
				encodedPhrase.Add(encodage[phrase[i]]);
		}
	}

	public void writePhrase(){
		//transform.localScale = new Vector2 (phrase.Count*dominoTemplate.transform.localScale.x*1.5f, transform.localScale.y);
		for (int i = 0; i < phrase.Count; i++) {

				Vector3 posDomino = new Vector3(transform.position.x+((dominoTemplate.transform.localScale.x*1.5f)*i),transform.position.y,2);
				GameObject currentDomino = Instantiate(dominoTemplate,posDomino,transform.rotation) as GameObject;
				//currentDomino.tag =  phrase[i].ToString();
				currentDomino.GetComponent<DominoScript>().sign = phrase[i];
				if(phrase[i] != 666){currentDomino.transform.Find("Sign").GetComponent<SpriteRenderer>().sprite = chars[phrase[i]];}
				currentDomino.transform.parent = transform;
				


		}

		transform.position = new Vector2(transform.position.x - ((float)(phrase.Count)*(dominoTemplate.transform.localScale.x)/2)-0.5f,transform.position.y);

	}

	public void writeEncodedPhrase(){
		for (int i = 0; i < encodedPhrase.Count; i++) {

				Vector2 posDomino = new Vector2(transform.position.x+((dominoTemplate.transform.localScale.x*1.5f)*i),transform.position.y-2);
				GameObject currentDomino = Instantiate(emptyDominoTemplate,posDomino,transform.rotation) as GameObject;
				//currentDomino.tag =  phrase[i].ToString();
				currentDomino.GetComponent<EmptyDominoScript>().valueToGet = encodedPhrase[i];
				//if(encodedPhrase[i] != 666){currentDomino.transform.Find("Sign").GetComponent<SpriteRenderer>().sprite = chars[encodedPhrase[i]];}
				currentDomino.transform.parent = transform;

			
			
		}
		//transform.position = new Vector2(transform.position.x - ((float)phrase.Count/2),transform.position.y);
		
	}

	public void placeDraggableDominos(){
		for (int i = 0; i < 7; i++) {
			Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
			Vector2 posDomino = new Vector2(Screen.width/14,(i*Screen.height/10)+Screen.height/4);
			posDomino = Camera.main.ScreenToWorldPoint(posDomino);
			GameObject currentDomino = Instantiate(dragDominoTemplate,posDomino,transform.rotation) as GameObject;
			currentDomino.GetComponent<DragDominoScript>().sign = encodage[i];
			currentDomino.transform.Find("Sign").GetComponent<SpriteRenderer>().sprite = chars[i];

		}
		for (int i = 7; i < 11; i++) {

			Vector2 posDomino = new Vector2(Screen.width/14*1.6f,((i-7)*Screen.height/10)+Screen.height/4 + Screen.height/20);
			posDomino = Camera.main.ScreenToWorldPoint(posDomino);
			GameObject currentDomino = Instantiate(dragDominoTemplate,posDomino,transform.rotation) as GameObject;
			currentDomino.GetComponent<DragDominoScript>().sign = encodage[i];
			currentDomino.transform.Find("Sign").GetComponent<SpriteRenderer>().sprite = chars[i];
			
		}

		for (int i = 0; i < 7; i++) {
			Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
			Vector2 posDomino = new Vector2(Screen.width/14*13,(i*Screen.height/10)+Screen.height/4);
			posDomino = Camera.main.ScreenToWorldPoint(posDomino);
			GameObject currentDomino = Instantiate(dragDominoTemplate,posDomino,transform.rotation) as GameObject;
			currentDomino.GetComponent<DragDominoScript>().sign = encodage[i+11];
			currentDomino.transform.Find("Sign").GetComponent<SpriteRenderer>().sprite = chars[i+11];
			
		}

		for (int i = 7; i < 11; i++) {
			Debug.Log(Camera.main.ScreenToWorldPoint(Input.mousePosition));
			Vector2 posDomino = new Vector2(Screen.width/14*12.4f,((i-7)*Screen.height/10)+Screen.height/4 + Screen.height/20);
			posDomino = Camera.main.ScreenToWorldPoint(posDomino);
			GameObject currentDomino = Instantiate(dragDominoTemplate,posDomino,transform.rotation) as GameObject;
			currentDomino.GetComponent<DragDominoScript>().sign = encodage[i+11];
			currentDomino.transform.Find("Sign").GetComponent<SpriteRenderer>().sprite = chars[i+11];
			
		}
	
	}
}
