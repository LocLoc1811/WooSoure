using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SwitchScene : MonoBehaviour
{
    //public float delaySecond = 2;
    //public string nameScene;

    public GameObject LoadingScreen;
    public Image LoadingBarFill;
    public float speed;
    public int sceneId;


    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
           collision.gameObject.SetActive(false);

            //ModeSelect();
            LoadScene();
        }
            
    }

    /* public void ModeSelect()
    {
        StartCoroutine(LoadAfterDeley());
    }

    IEnumerator LoadAfterDeley() 
    {
        yield return new WaitForSeconds(delaySecond);

        SceneManager.LoadScene(nameScene);
    } */

    public void LoadScene()
    {
        StartCoroutine(LoadSceneAsync(sceneId));
    }

    IEnumerator LoadSceneAsync(int sceneId)
    {

        LoadingScreen.SetActive(true);

        AsyncOperation operation = SceneManager.LoadSceneAsync(sceneId);

        

        while (!operation.isDone)
        {
            float progressValue = Mathf.Clamp01(operation.progress / speed);
            LoadingBarFill.fillAmount = progressValue;

            yield return null;
        }
    }
}
