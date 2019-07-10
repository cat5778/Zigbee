using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour {

    // The map we're building is going to look like;
    //List of user-> A User ->List of score for that user
    //

    Dictionary<string, Dictionary<string, int>> playerScore;

    // Use this for initialization
    void Start () {
        SetScore("asdf", "kill", 123);
        Debug.Log(GetData("asdf", "kill"));
        

	}
    void Init()
    {
        if (playerScore != null)
            return;
        playerScore = new Dictionary<string, Dictionary<string, int>>();
    }


	public int GetData(string username, string scoreType)
    {
        Init();
        if(playerScore.ContainsKey(username) == false)
        {
            return 0;
        }
        if (playerScore[username].ContainsKey(scoreType) == false)
        {
            return 0;
        }
            return playerScore[username][scoreType];
    }


    public void SetScore(string username, string scoreType,int value)
    {
        Init();
        if (playerScore.ContainsKey(username) == false)
        {
            playerScore[username] = new Dictionary<string, int>();
        }
        playerScore[username][scoreType] = value;

    }


    public void ChangeScore(string username,string scoreType,int amount)
    {
        Init();
        int curScore = GetData(username, scoreType);
        SetScore(username, scoreType, curScore + amount);

    }


}
