using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Random = UnityEngine.Random;
using UnityEngine.SceneManagement;

public class QuestionGetter : MonoBehaviour {

	public int requiredCorrect = 3; //number of correct answers in a round
	public int wonRounds = 0; //keeps track of how many rounds a user has answered correctly
	public int lossRounds = 0; //keeps track of how many rounds a user has answered inccorectly
	public int requiredToWin = 4; //number of rounds needed to win to advance to next stage/scene
	public static bool resetQuestion = false;

	private Rigidbody2D rigidbody;

	private Text a1, a2, a3, a4, question;
	private static string[] mathQuestionMatrix = new string[]{"Which numbers have a sum of ", "Which numbers have a difference of ",
	"Which numbers are greater than ", "Which numbers are less than ", "Which numbers are between "};
	private static int[] questionNumMatrix = new int[]{1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14, 15, 16, 17, 18, 19, 20, 21, 22,
		23, 24, 25, 26, 27, 28, 29, 30, 31, 32, 33, 34, 35, 36, 37, 38, 39, 40, 41, 42, 43, 44, 45, 46, 47, 48, 49, 50, 51, 52,
		53, 54, 55, 56, 57, 58, 59, 60, 61, 62, 63, 64, 65, 66, 67, 68, 69, 70, 71, 72, 73, 74, 75, 76, 77, 78, 79, 80, 81,
		82, 83, 84, 85, 86, 87, 88, 89, 90, 91, 92, 93, 94, 95, 96, 97, 98, 99, 100 };
	//private static string[] answerMatrix = new string[]{ };

	//variables for random index
	private static int randomMathQuestion;
	private static int randomNumber;

	// Use this for initialization
	void Awake () 
	{
		rigidbody = GetComponent<Rigidbody2D>();
		question = GameObject.Find ("Question").GetComponent<Text>();
		a1 = GameObject.Find ("Answer1").GetComponent<Text>();
		a2 = GameObject.Find ("Answer2").GetComponent<Text>();
		a3 = GameObject.Find ("Answer3").GetComponent<Text>();
		a4 = GameObject.Find ("Answer4").GetComponent<Text>();

		question.text = questionCreator ();
	}
	

	void Update () 
	{
		//Debug.Log ("Reset Questions?: " + resetQuestion);
		if (CardDrag.cardsRemoved == requiredCorrect && !resetQuestion) 
		{
			rigidbody.AddForce(new Vector2(0f, 20f));
		}
		if (wonRounds == requiredToWin) 
		{
			//load the next scene
			SceneManager.LoadScene ("levelComplete", LoadSceneMode.Single);
		}
	}

	//updates board
	void OnCollisionEnter2D(Collision2D coll)
	{
		if (coll.gameObject.CompareTag ("background"))
		{
			wonRounds++;
			resetQuestion = true;
			//add functionality for if player loses round
			//Debug.Log ("Reset Question?: " + resetQuestion);
			//change question & answer text
			question.text = questionCreator();

		}
	}

	//creates new questions
	string questionCreator()
	{
		string toReturn = "";

		//creates random index for creating math question.
		randomMathQuestion = Random.Range (0, mathQuestionMatrix.Length - 1);
		randomNumber = Random.Range (0, questionNumMatrix.Length - 1);

		//string of created question
		toReturn = mathQuestionMatrix [randomMathQuestion] + questionNumMatrix [randomNumber] + "?";
		return toReturn;
	}

	string answerCreator(int rmq, int rn)
	{
		string toReturn = "";
		//rmq = randomMathQuestion
		//rn = randomNumber
		return toReturn;
	}
}
