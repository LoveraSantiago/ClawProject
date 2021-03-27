using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleManager : MonoBehaviour
{
    public void OnClickPlay()
    {
        SceneManager.LoadScene("MainScene");
    }

}
