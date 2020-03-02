using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;
public class WordSpawner : MonoBehaviourPun {

	public GameObject wordPrefab;
	//public Transform wordCanvas;
    public Transform map;

	public WordDisplay SpawnWord ()
	{
		Vector3 randomPosition = new Vector3(Random.Range(-2.5f, 2.5f), 7f);

        GameObject wordObj = Instantiate(wordPrefab, randomPosition, Quaternion.identity,map);
        WordDisplay wordDisplay = wordObj.GetComponent<WordDisplay>();
		return wordDisplay;
	}

}
