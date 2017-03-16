using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class CardDrag : MonoBehaviour
{
	private Vector3 touchDown;
	private Vector3 touchUp;
	private Vector3 origin;
	private Rigidbody2D rigidbody;
	private int numOfCards = 4;
	private static int cardsReset = 0;
	public static int cardsRemoved = 0;


	private void Awake()
	{
		rigidbody = GetComponent<Rigidbody2D>();
	}

	void Start()
	{
		origin = transform.position;
	}

	//updates every frame, if resetQuestion is true it moves cards back to proper place and sets resetQuestion to false
	void Update()
	{
		if (QuestionGetter.resetQuestion && (cardsReset < numOfCards)) {
			cardsRemoved = 0;
			this.transform.position = origin;
			//Debug.Log ("Cards Removed: " + cardsRemoved);
			cardsReset += 1;
			//Debug.Log ("Cards Reset: " + cardsReset);
		} 
		else if (QuestionGetter.resetQuestion && cardsReset >= numOfCards) 
		{
			QuestionGetter.resetQuestion = false;
			cardsReset = 0;
			//Debug.Log ("Cards Reset: " + cardsReset);
			//Debug.Log ("Reset Question?: " + QuestionGetter.resetQuestion);
		}
	}

	void OnMouseDown()
	{
		touchDown = Input.mousePosition;
	}

	//determines direction answer card will move
	void OnMouseDrag ()
	{
		touchUp = Input.mousePosition;

		if (touchUp.x > touchDown.x) 
		{
			rigidbody.AddForce(new Vector2(20f, 0f));
		}
		else if (touchUp.x < touchDown.x) 
		{
			rigidbody.AddForce(new Vector2(-20f, 0f));
		}
	}

	//keeps track of cards removed, need to add functionality to see if answers were correct
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.CompareTag ("background"))
		{
			cardsRemoved += 1;
			//Debug.Log ("Cards Removed: " + cardsRemoved);
		}
	}
}