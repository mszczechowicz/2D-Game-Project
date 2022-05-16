using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuSceneMenager : MonoBehaviour
{
    public Animator transition;

    public float transitionTime = 1f;
    public void GoToSceneOne()
    {
        StartCoroutine(LoadLevel(1));
    }

    public void Quit()
    {
        Application.Quit();
    }

    //public void LoadNextLevel()
    //{ // ++ scene




    //}





    IEnumerator LoadLevel(int levelIndex)
    {

        transition.SetTrigger("Start");

        yield return new WaitForSeconds(transitionTime);

        SceneManager.LoadScene(levelIndex);

    }




}
