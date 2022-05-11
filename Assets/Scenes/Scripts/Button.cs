using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class Button: MonoBehaviour
{
    //public GameObject information;
    //public GameObject tip;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetKeyDown(KeyCode.I))
        //{
        //    information.SetActive(true);
        //}
        //if (Input.GetKeyUp(KeyCode.I))
        //{
        //    information.SetActive(false);
        //}

        //if (Time.time >= 3f)
        //{
        //    tip.SetActive(false);
        //}
    }

    public void LoadSelectLeve()
    {
        SceneManager.LoadSceneAsync("SelectLevel");
        DontDestroyOnLoad(gameObject);
        Time.timeScale = 1f;
    }

    public void QuitGame()
    {
        //UnityEditor.EditorApplication.isPlaying = false;
        Application.Quit();
        Time.timeScale = 1f;
    }

    public void GoBackMenu()
    {
        SceneManager.LoadSceneAsync("StartInterface");
        DontDestroyOnLoad(gameObject);
        Time.timeScale = 1f;
    }

    public void LoadTutrial()
    {
        SceneManager.LoadSceneAsync("tutrial");
        DontDestroyOnLoad(gameObject);
        Time.timeScale = 1f;
    }

    public void LoadLevel1()
    {
        SceneManager.LoadSceneAsync("Level1");
        DontDestroyOnLoad(gameObject);
        Time.timeScale = 1f;
    }

    public void LoadLevel2()
    {
        SceneManager.LoadSceneAsync("Level2");
        DontDestroyOnLoad(gameObject);
        Time.timeScale = 1f;
    }

    public void LoadLevel3()
    {
        SceneManager.LoadSceneAsync("Level3");
        DontDestroyOnLoad(gameObject);
        Time.timeScale = 1f;
    }

    public void LoadLevel4()
    {
        SceneManager.LoadSceneAsync("Level4");
        DontDestroyOnLoad(gameObject);
        Time.timeScale = 1f;
    }

    public void LoadLevel5()
    {
        SceneManager.LoadSceneAsync("Level5");
        DontDestroyOnLoad(gameObject);
        Time.timeScale = 1f;
    }

    public GameObject ingameMenu;

    public void OnPause()
    {
        Time.timeScale = 0;
        ingameMenu.SetActive(true);
    }

    public void onResume()
    {
        Time.timeScale = 1;
        ingameMenu.SetActive(false);
    }

    public void OnRestart()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        SceneManager.LoadScene(SceneManager.GetSceneAt(0).name);
        //application.LoadLevel("Level1");
        Time.timeScale = 1f;
    }

}
