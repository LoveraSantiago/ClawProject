using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ScrollBottomBar 
{
    public ScrollBottomBar(ScrollBottomBarDto scrollBottomBarDto)
    {
        PowerUpEntidade[] allPups = FactoryPowerUpEntidade.getAllPowerUps();
        for(int contador = 1; contador < allPups.Length; contador++)
        {
            GameObject go = GameObject.Instantiate(scrollBottomBarDto.BoxPup, scrollBottomBarDto.BoxPup.transform.parent);
            go.name = "Box_" + contador;
            go.transform.Find("btn")
              .GetComponent<Button>()
              .onClick.AddListener(() => cliqueAcionado());
        }
        scrollBottomBarDto.RectTransfHorizontal.sizeDelta = new Vector2(300f * allPups.Length, 300f);
        scrollBottomBarDto.RectTransfHorizontal.localPosition = new Vector3(300f * allPups.Length, 0, 0);
    }

    public void cliqueAcionado()
    {
        Debug.Log("Pressionado " + EventSystem.current.currentSelectedGameObject.name);
    }

}
