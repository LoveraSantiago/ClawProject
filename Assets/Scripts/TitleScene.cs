using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{   
    private void Start()
    {
        Camera.main.aspect = Utils.RATIO_SCREEN;
    }    
    
    public void irParaMainScene()
    {        
        SceneManager.LoadScene("MapScene");
    }
}
