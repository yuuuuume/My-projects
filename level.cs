using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class level : MonoBehaviour
{

    [SerializeField] int breakableBlocks; // serialized for debugging purposes

    //cashed reference
    SceanLoader sceanLoader;


    private void Start()
    {
        //find the SceanLoader class.
        sceanLoader = FindObjectOfType<SceanLoader>();
    }
    public void CountBlocks()
    {
        breakableBlocks++;

    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if(breakableBlocks <= 0)
        {
            sceanLoader.LoadNextScene();
    
         }
    }
}
