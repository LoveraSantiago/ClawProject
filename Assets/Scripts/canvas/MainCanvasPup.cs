using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;

public class MainCanvasPup 
{
    public MainCanvasPup(MainCanvasDto mainCanvasDto)
    {
        configButtonBack(mainCanvasDto.BtnBack);
    }

    private void configButtonBack(Button btnBack)
    {
        btnBack.onClick.AddListener(() => SceneManager.LoadScene("MapScene"));
    }
}
