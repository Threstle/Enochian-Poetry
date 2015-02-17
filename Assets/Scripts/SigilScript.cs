using UnityEngine;
using System.Collections;

public class SigilScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
				if (Input.GetMouseButtonDown (0)) {
						RaycastHit2D hit = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (Input.mousePosition), Vector2.zero);
						if (hit.collider != null) {
								if (hit.collider.gameObject == gameObject) {
									if(checkAnswer()){
										StartCoroutine("FadeIn", transform.GetComponent<SpriteRenderer>());
									}
									else{
										transform.audio.Play();
										StartCoroutine("Blink", transform.GetComponent<SpriteRenderer>());
									}
					
								} else {
					
					
								}
						}
				}

		}

	bool checkAnswer (){
		bool isCorrect = true;
		GameObject[] dominos;
		//transform.GetComponent<SpriteRenderer>().Color = Mathf.SmoothDamp(transform.GetComponent<SpriteRenderer>().colo, target.position.y, ref yVelocity, smoothTime);
		dominos = GameObject.FindGameObjectsWithTag("EmptyDomino");
		foreach (GameObject domino in dominos) {
			if(!domino.transform.GetComponent<EmptyDominoScript>().isOk)
				isCorrect = false;

				Debug.Log(domino.transform.GetComponent<EmptyDominoScript>().isOk);
		}


		return isCorrect;
	}

	IEnumerator FadeIn(SpriteRenderer rend) {
			for (float i = 0; i <= 255; i+=5) {

				rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 1-i/255);
				yield return new WaitForSeconds(0);
			}
	}

	IEnumerator Blink(SpriteRenderer rend) {
		for (float i = 0; i <= 255; i+=5) {
			
			rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 0.5f-i/255);
			yield return new WaitForSeconds(0);
		}
		for (float i = 0; i <= 255; i+=5) {
			
			rend.color = new Color(rend.color.r, rend.color.g, rend.color.b, 0f+i/255);
			yield return new WaitForSeconds(0);
		}
	}
}
