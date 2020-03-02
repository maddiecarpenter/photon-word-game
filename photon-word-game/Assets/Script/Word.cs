using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Word :MonoBehaviour{

	public string word;
	private int typeIndex;
	WordDisplay display;
    private ScoreDisplay scoreDisplay = new ScoreDisplay();
    public static int score = 0;

    public Word (string _word, WordDisplay _display)
	{

        word = _word;
		typeIndex = 0;

		display = _display;
		display.SetWord(word);

        scoreDisplay = GameObject.Find("Canvas/Score").GetComponent<ScoreDisplay>();

    }

    public char GetNextLetter ()
	{
        Debug.Log(typeIndex+" word: " + word[typeIndex]);
		return word[typeIndex];
	}

	public void TypeLetter ()
	{
		typeIndex++;
		display.RemoveLetter();
	}

	public bool WordTyped ()
	{
		bool wordTyped = (typeIndex >= word.Length);
		if (wordTyped)
		{
            score++;
            scoreDisplay.SetWord("Score: " + score);
            Debug.Log("score is " + score);
            display.RemoveWord();
		}
		return wordTyped;
	}

    public void Die()
    {
        Debug.Log("die and score--");
        Destroy(gameObject);
    }



}
