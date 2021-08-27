using UnityEngine;

public class ScrollBottomBar 
{
    public ScrollBottomBar(ScrollBottomBarDto scrollBottomBarDto)
    {
        PowerUpEntidade[] allPups = FactoryPowerUpEntidade.getAllPowerUps();
        for(int contador = 1; contador < allPups.Length; contador++)
        {
            GameObject.Instantiate(scrollBottomBarDto.BoxPup, scrollBottomBarDto.BoxPup.transform.parent);
        }
        scrollBottomBarDto.RectTransfHorizontal.sizeDelta = new Vector2(300f * allPups.Length, 300f);
        scrollBottomBarDto.RectTransfHorizontal.localPosition = new Vector3(300f * allPups.Length, 0, 0);
    }

}
