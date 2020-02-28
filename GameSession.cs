using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameSession : MonoBehaviour
{
    level level;
    //confing param
    [Range(0.1f,10f)][SerializeField] float GameSpeed = 1f;
    [SerializeField] int pointsPerBlockDestroyed = 10;
    //state variable
    [SerializeField]int CurrentScore = 0;
    [SerializeField] TextMeshProUGUI scoreTxt;
    [SerializeField] bool isAutoPlayEnabled = false;

    private void Awake()
    {
        int gameStatusCount = FindObjectsOfType<GameSession>().Length;
        Debug.Log(gameStatusCount);
        if (gameStatusCount > 1)
        {
            
            gameObject.SetActive(false);
            Destroy(gameObject);

        }
        else
        {
            //is gonna stick around you even if it goes next scene
            DontDestroyOnLoad(gameObject);
        }
        
    }
    private void Start()
    {
        scoreTxt.text = CurrentScore.ToString();
    }
    // Update is called once per frame
    void Update()
    {
        Time.timeScale = GameSpeed;
        
    }

    public void Add2Score()
    {
        CurrentScore += pointsPerBlockDestroyed;
        scoreTxt.text = CurrentScore.ToString();
    }

    public void ResetGame()
    {
        //we are talking about the instance of game object so it starts from small letter.
        //If it starts from Capital, this means it is Class
        Destroy(gameObject);


    }

    public bool IsAutoPlayEnable()
    {
        return isAutoPlayEnabled;
    }
}
