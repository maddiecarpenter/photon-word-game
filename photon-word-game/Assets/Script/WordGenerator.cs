using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WordGenerator : MonoBehaviour {

    private static string[] wordList = new string[1000];
    //{   
         //                           "sidewalk", "robin", "three", "protect", "periodic",
									//"somber", "majestic", "jump", "pretty", "wound", "jazzy",
									//"memory", "join", "crack", "grade", "boot", "cloudy", "sick",
									//"mug", "hot", "tart", "dangerous", "mother", "rustic", "economic",
									//"weird", "cut", "parallel", "wood", "encouraging", "interrupt",
									//"guide", "long", "chief", "mom", "signal", "rely", "abortive",
									//"hair", "representative", "earth", "grate", "proud", "feel",
									//"hilarious", "addition", "silent", "play", "floor", "numerous",
									//"friend", "pizzas", "building", "organic", "past", "mute", "unusual",
									//"mellow", "analyse", "crate", "homely", "protest", "painstaking",
									//"society", "head", "female", "eager", "heap", "dramatic", "present",
									//"sin", "box", "pies", "awesome", "root", "available", "sleet", "wax",
									//"boring", "smash", "anger", "tasty", "spare", "tray", "daffy", "scarce",
									//"account", "spot", "thought", "distinct", "nimble", "practise", "cream",
									//"ablaze", "thoughtless", "love", "verdict", "giant"    
                                    //};
    private void Start()
    {
        GetFromMyql();
    }

    private void GetFromMyql()
    {
        string connectStr = "server=127.0.0.1;port=3306;database=vocab;user=root;password=root";

        Dbutil dbutil = new Dbutil();
        dbutil.GetConn(connectStr);
        string sql = "select spell from master where wordId<1000 order by learnedTimes desc";
        dbutil.Query(sql);
        for (int i = 0; dbutil.mySqlDataReader.Read(); i++)
        {
            wordList[i] = dbutil.mySqlDataReader.GetString("spell");
            //Debug.Log("i= " + i + "  spell= " + wordList[i]);
        }
        dbutil.Close();
    }

    public static string GetRandomWord ()
	{

        int randomIndex = UnityEngine.Random.Range(0, wordList.Length);
		string randomWord = wordList[randomIndex];

		return randomWord;
	}

}
