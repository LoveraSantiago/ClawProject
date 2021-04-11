using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public void startLevel()
    {
        SceneManager.LoadScene("MainContainerSceneV2");
    }

    public void closeDescricaoObjetivo()
    {
        gameObject.active = false;
    }

}
