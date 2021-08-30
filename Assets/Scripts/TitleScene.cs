using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{      
    public void irParaMainScene()
    {        
        SceneManager.LoadScene("MapScene");
    }
}
