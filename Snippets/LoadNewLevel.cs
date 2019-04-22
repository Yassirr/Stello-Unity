using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class LoadNewLevel : MonoBehaviour
{
    public string levelToLoad = "scene";
    public SceneFader sceneFader;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Invoke("LoadNextLevel", 1.5f);
        }
    }
    public void LoadNextLevel()
    {
        sceneFader.FadeTo(levelToLoad);
    }


}
