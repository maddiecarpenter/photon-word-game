﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MySql.Data.MySqlClient;
using System;

public class Dbutil : MonoBehaviour
{
    MySqlConnection conn = null;
    MySqlCommand mySqlCommand = null;
    public MySqlDataReader mySqlDataReader = null;
    //private void Start()
    //{
    //    GetConn();
    //    string sql = "select spell from master where wordId<20";
    //    Query(sql);
    //    //Query("select * from master where wordId<10");
    //    //AddDelete("insert into master(explaination,spell,wordLength)values('a','" + DateTime.Now + "',1)");
    //    //Query("select * from master where explaination='a'");
    //    //UpdateMysql("delete from master where explaination='a'");
    //    //UpdateMysql("update master set spell='aba' where wordId=1 and spell='abaa'");//字符串组合拼接
    //    //UpdateMysql("update master set spell='aaa' where wordId=@wordId and spell=@spell");//字符串组合拼接
    //    //Query("select * from master where explaination = 'a'");
    //    //mySqlDataReader.Close();

    //    //QuerySingle("select count(wordId) from master");
    //    Close();
    //}
    
    public void AddDelete(string sql,string name,int score)
    {
        mySqlCommand = new MySqlCommand(sql, conn);
        mySqlCommand.Parameters.AddWithValue("@name", name);
        mySqlCommand.Parameters.AddWithValue("@score", score);
        int count = mySqlCommand.ExecuteNonQuery();
        Debug.Log("数据库中受影响的数据行数" + count);
    }

    //与函数结合起来
    public void UpdateMysql(string sql,int score)
    {
        mySqlCommand = new MySqlCommand(sql, conn);

        //mySqlCommand.Parameters.AddWithValue("@id", 1);
        mySqlCommand.Parameters.AddWithValue("@score", score);
        int count = mySqlCommand.ExecuteNonQuery();
        Debug.Log("数据库中受影响的数据行数" + count);
    }
    void QuerySingle(string sql)
    {
        mySqlCommand = new MySqlCommand(sql, conn);
        object o = mySqlCommand.ExecuteScalar();
        int avg = Convert.ToInt32(o.ToString());
        Debug.Log(avg);
       
    }
    public void Query(string sql)
    {
        mySqlCommand = new MySqlCommand(sql, conn);
        //mySqlCommand.ExecuteReader();//query
        //mySqlCommand.ExecuteNonQuery();//insert update delete
        //mySqlCommand.ExecuteScalar();//return single value
        mySqlDataReader = mySqlCommand.ExecuteReader();
        Debug.Log("execute query in mysql");
        //while (mySqlDataReader.Read())
        //{
        //    //Debug.Log(mySqlDataReader[0].ToString());
        //    //Debug.Log(mySqlDataReader.GetInt32(0));
        //    //Debug.Log(mySqlDataReader.GetInt32("wordId") + " " + mySqlDataReader.GetString("spell"));
        //}
    }


    public void GetConn(string connectStr)
    {
        conn = new MySqlConnection(connectStr);
        try
        {
            conn.Open();
        }
        catch (Exception e)
        {
            Debug.Log(e.ToString());
        }
        finally
        {
            Debug.Log("数据库连接的状态： " + conn.State);
        }
    }

    public void Close()
    {
        if (mySqlDataReader != null)
        {
            mySqlDataReader.Close();
        }
        if (conn != null)
        {
            conn.Close();
        }
    }
}
