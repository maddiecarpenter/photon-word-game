using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using Photon.Pun;
using UnityEngine.UI;
public class WordManager : MonoBehaviourPun {

	public List<Word> words= new List<Word>();
    public WordSpawner wordSpawner;
    public static bool hasActiveWord;
	public Word activeWord;
    public GameObject Option;
    //public GameObject exitBtn;
    public bool isPause=false;
    public GameObject reinsure;
    public Text username;
    public void AddWord ()
	{
		Word word = new Word(WordGenerator.GetRandomWord(), wordSpawner.SpawnWord());
		Debug.Log(word.word);
        if(word.word!=null)
		words.Add(word);
	}
    private void Start()
    {
        Option.SetActive(false);
        reinsure.SetActive(false);
        GameObject.Find("Canvas/Username").GetComponent<Text>().text=NetWorkManager.userName;
    }
    private void Update()
    {
        Option.SetActive(isPause);
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isPause = !isPause;
        }
    }

    public void ComfirmPanel()
    {
        isPause = false;
        reinsure.SetActive(true);
    }
    public void ExitSaveDate()
    {
        string connectStr = "server=127.0.0.1;port=3306;database=vocab;user=root;password=root";
        Dbutil dbutil = new Dbutil();
        dbutil.GetConn(connectStr);
        string sql = "insert into vocabUser(name,score) values(@name,@score)";
        dbutil.AddDelete(sql,NetWorkManager.userName, Word.score);
        dbutil.Close();
        UnityEditor.EditorApplication.isPlaying = false;
    }

    public void BackToOption()
    {
        reinsure.SetActive(false);
        isPause = true;
        Debug.Log("back to  option ");
    }

    public void BackToMain()
    {
        SceneManager.LoadScene(0);
        ExitSaveDate();
    }

    public void TypeLetter (char letter)
	{
        Debug.Log(letter);
        
		if (hasActiveWord)
		{
            Debug.Log("has active word");
			if (activeWord.GetNextLetter() == letter)
			{
				activeWord.TypeLetter();
			}
		} 
        else
		{
            Debug.Log("do not have active word");
            Debug.Log("words.length: " + words.Count);
			foreach(Word word in words)
			{
                Debug.Log("foreach");
                Debug.Log(word.GetNextLetter()+" ========");

                if (word.GetNextLetter() == letter)
				{
					activeWord = word;
					hasActiveWord = true;
					word.TypeLetter();
					break;
				}
			}
		}

		if (hasActiveWord && activeWord.WordTyped())
		{
			hasActiveWord = false;
			words.Remove(activeWord);
        }

    }

}
