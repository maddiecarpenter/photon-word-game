using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplay : MonoBehaviour {

	public Text text;

	public void SetWord (string word)
	{
		text.text = word;
	}


}
