using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneControl : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Quit()
    {
        #if UNITY_EDITOR
                UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif
    }

    public void LoadScene(string sceneName)
    {
        if (!(sceneName == "MainMenu" || sceneName == "LevelSelecter"))
        {
            if (GameObject.Find("MenuBGM(Clone)"))
                Destroy(GameObject.Find("MenuBGM(Clone)"));
        }

        SceneManager.LoadScene(sceneName);
    }
}
