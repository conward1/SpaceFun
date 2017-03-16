using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class DialogText : MonoBehaviour {

	//keeps track of what scene it is (question scenes do not count)
	public static int indexOfScene = 0;

	//arrays of dialog
	private string[] carlDialog0 = new string[]{"Hello! My name is Astronaught Carl and I need your help!", 
		"My crew and I seem to have gotten separated while exploring the solar system. Will you help me find them?", 
		"We can use my spaceship, but it's powered by the imagination and knowledge.", 
		"I'll need your help to get it moving!"};
	private string[] carlDialog1 = new string[]{"You did it! You got the ship moving. Good Job!", 
		"We still have a long way to go.", "Placeholder text", "Placeholder text"};

	//temp string array for different scenes dialog
	private string[] temp = new string[]{};

	//index for a particular phrase in a scene
	private int indexOfDialog = 0;

	//does the next scene need to be loaded?
	private bool loadNextScene = false;
	//private bool firstScene = true;

	//variable for text to be output to screen
	private Text displayedText;

	// Use this for initialization
	void Awake ()
	{
		//finds text object in scene
		displayedText = GameObject.Find ("CarlText").GetComponent<Text>();

		//assigns correct dialog for scene
		switch (indexOfScene) 
		{
		case 0:
			temp = carlDialog0;
			break;
		case 1:
			temp = carlDialog1;
			break;
		}

		//begins printing text to screen
		StartCoroutine(AnimateText());
	}

	void Update()
	{
		/*if (loadNextScene && firstScene) {
			indexOfScene++;
			firstScene = false;
			SceneManager.LoadScene ("questions", LoadSceneMode.Single);
		} 
		else if (loadNextScene && !firstScene) 
		{
			SceneManager.UnloadSceneAsync("questions");
			indexOfScene++;
			SceneManager.LoadScene ("questions", LoadSceneMode.Single);
		}*/
		if (loadNextScene) 
		{
			//StopAllCoroutines ();
			Debug.Log ("Loading next scene");
			indexOfScene++;
			SceneManager.LoadScene ("questions", LoadSceneMode.Single);
		} 
	}

	void OnMouseDown()
	{
		//stops text printing
		StopAllCoroutines ();
		//goes to next dialog
		indexOfDialog++;
		//checks for out of bounds
		if (indexOfDialog == temp.Length) 
		{
			//Debug.Log ("inside indexOfDialog == temp.Length");
			loadNextScene = true;
		} 
		else 
		{
			//restarts printing text
			//Debug.Log ("inside else");
			StartCoroutine(AnimateText());
		}
	}

	IEnumerator AnimateText()
	{
		//Debug.Log ("indexOfDialog: " + indexOfDialog);
		//Debug.Log ("temp[]: " + temp [indexOfDialog]);

		//make text be typed across screen, rather than printed all at once
		if(indexOfDialog < temp.Length)
		{
			for (int i = 0; i < (temp [indexOfDialog].Length + 1); i++) 
			{
				displayedText.text = temp [indexOfDialog].Substring (0, i);
				yield return new WaitForSeconds (0.03f);
			}
		}
		else
		{
			StopCoroutine(AnimateText());
		}
	}
}
