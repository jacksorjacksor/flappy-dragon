using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
   /* void Awake()
    {
        DontDestroyOnLoad(transform.gameObject);
    }*/
    public void Scene00Load()
    {
        SceneManager.LoadScene(0);
    }
    public void Scene01Load()
    {
        SceneManager.LoadScene(1);
    }
    public void Scene02Load()
    {
        SceneManager.LoadScene(2);
    }
    public void Scene03Load()
    {
        SceneManager.LoadScene(3);
    }
}
