using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ScrollBottomBar 
{
    public ScrollBottomBar(ScrollBottomBarDto scrollBottomBarDto)
    {
        PowerUpEntidade[] allPups = FactoryPowerUpEntidade.getAllPowerUps();
        for(int contador = 1; contador < allPups.Length; contador++)
        {
            GameObject go = GameObject.Instantiate(scrollBottomBarDto.BoxPup, scrollBottomBarDto.BoxPup.transform.parent);
            bindBox(contador, go, allPups[contador]);
        }
        bindBox(0, scrollBottomBarDto.BoxPup, allPups[0]);
        scrollBottomBarDto.RectTransfHorizontal.sizeDelta = new Vector2(300f * allPups.Length, 300f);
        scrollBottomBarDto.RectTransfHorizontal.localPosition = new Vector3(300f * allPups.Length, 0, 0);
    }

    private void bindBox(int indiceName, GameObject box, PowerUpEntidade pupEntidade)
    {
        TextMeshProUGUI text = box.transform.Find("lbl-qtd").GetComponent<TextMeshProUGUI>();
        text.text = "999";

        Button btnIt = box.transform.Find("btn").GetComponent<Button>();
        btnIt.name = indiceName.ToString();
        btnIt.image.sprite = pupEntidade.sprPowerUp;
        btnIt.onClick.AddListener(() => cliqueAcionado());
    }

    private void cliqueAcionado()
    {
        Debug.Log("Pressionado " + EventSystem.current.currentSelectedGameObject.name);
    }

}
