using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Paddle : MonoBehaviour
{
    [SerializeField] float xMin = 1.0f;
    [SerializeField] float xMax = 15f;
    [SerializeField] float screenWidthInUnits = 16f;
    // Start is called before the first frame update
    
    //cash the reference
    GameSession myGameSession;
    ball theball;
    void Start()
    {
        myGameSession = FindObjectOfType<GameSession>();
        theball = FindObjectOfType<ball>();
    }

    // Update is called once per frame
    void Update()
    {
      
        
       
        Vector2 paddlePos = new Vector2(transform.position.x, transform.position.y);
        //not go ff the x pos or y pos
        paddlePos.x = Mathf.Clamp(GetXpos(),xMin, xMax);
        transform.position = paddlePos;

    }

    private float GetXpos()
    {
        
        if (myGameSession.IsAutoPlayEnable())
        {
            return FindObjectOfType<ball>().transform.position.x;
        }
        else
        {
            return Input.mousePosition.x / Screen.width * screenWidthInUnits;
        }

    }
}
