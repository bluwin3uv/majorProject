using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scenemanager : MonoBehaviour
{
    public int curLevel;

    private static scenemanager insta;
    public void Reset()
    {
        SceneManager.LoadScene(0);
    }

    void Start()
    {
        if(insta == null)
        {
            DontDestroyOnLoad(gameObject);
            insta = this;
        }
    }

    public static void completelevel()
    {
        insta.curLevel++;
        SceneManager.LoadScene(insta.curLevel);
    }


	
	
}
