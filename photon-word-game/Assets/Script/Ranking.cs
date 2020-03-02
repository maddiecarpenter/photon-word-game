using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Ranking : MonoBehaviour
{
    private bool isActive=false;
    public GameObject rankScroll;
    public Text userData;
    private void Update()
    {
        rankScroll.SetActive(isActive);

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isActive = !isActive;
        }
    }
    public void RankList()
    {
        isActive = true;
        GetRankData();
    }

    private void GetRankData()
    {
        //string connectStr = "server=127.0.0.1;port=3306;database=vocab;user=root;password=root";

        //Dbutil dbutil = new Dbutil();
        //dbutil.GetConn(connectStr);

        //string sql = "select * from vocabUser";

        //string name = null;
        //string score = null;
        //string info = null;
        //for (int i = 0; dbutil.mySqlDataReader.Read(); i++)
        //{
        //name = dbutil.mySqlDataReader.GetString("name");

        //score = dbutil.mySqlDataReader.GetString("score");
        //info += name + "\t" + score;
        //}
        //GameObject.Find("Canvas/Panel/Container/Text").GetComponent<Text>().text = info;
        //dbutil.Close();

        string connectStr = "server=127.0.0.1;port=3306;database=vocab;user=root;password=root";

        Dbutil dbutil = new Dbutil();
        dbutil.GetConn(connectStr);
        string sql = "select * from vocabUser order by score desc";
        string name = null;
        int score = 0;
        string info = "RANKING......\n";
        dbutil.Query(sql);
        for (int i = 0; dbutil.mySqlDataReader.Read(); i++)
        {
            name = dbutil.mySqlDataReader.GetString("name");

            score = dbutil.mySqlDataReader.GetInt32("score");
            if (name != null)
            info += name + "    " + score+"\n";

        }

       userData.text = info;

        dbutil.Close();

    }
}
