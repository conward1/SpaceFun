using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextMover : MonoBehaviour {

	public GameObject answerC;

	// Use this for initialization
	void Start () 
	{
		//answerC = GameObject.Find ("answerCard1");
	}
	
	// Update is called once per frame
	void Update () 
	{
		this.transform.position = answerC.transform.position;
	}
}
