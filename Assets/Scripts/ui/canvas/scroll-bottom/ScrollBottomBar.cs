using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ScrollBottomBar
{
    protected BotaoBottomBar btnBottomBar;

    public ScrollBottomBar(GameObject prefabBottomBar, MonoBehaviour monoBehaviour)
    {
        PrefabScrollBottomBarDto prefabDto = prefabBottomBar.GetComponent<PrefabScrollBottomBarDto>();
        btnBottomBar = new BotaoBottomBar(prefabDto.BtnBottomBarDto, this, monoBehaviour);

        PowerUpEntidade[] allPups = FactoryPowerUpEntidade.getAllPowerUps();
        criarBoxes(prefabDto.ScrollBottomBarDto, allPups);

        prefabDto.ScrollBottomBarDto.RectTransfHorizontal.sizeDelta = new Vector2(300f * allPups.Length, 300f);
        prefabDto.ScrollBottomBarDto.RectTransfHorizontal.localPosition = new Vector3(300f * allPups.Length, 0, 0);        
    }

    private void criarBoxes(ScrollBottomBarDto scrollBottomBarDto, PowerUpEntidade[] allPups)
    {
        for (int contador = 1; contador < allPups.Length; contador++)
        {
            GameObject go = GameObject.Instantiate(scrollBottomBarDto.BoxPup, scrollBottomBarDto.BoxPup.transform.parent);
            bindBox(contador, go, allPups[contador]);
        }
        bindBox(0, scrollBottomBarDto.BoxPup, allPups[0]);
    }

    private void bindBox(int indiceName, GameObject box, PowerUpEntidade pupEntidade)
    {
        TextMeshProUGUI text = box.transform.Find("lbl-qtd").GetComponent<TextMeshProUGUI>();
        text.text = "999";

        Button btnIt = box.transform.Find("btn").GetComponent<Button>();
        btnIt.name = indiceName.ToString();
        btnIt.image.sprite = pupEntidade.sprPowerUp;
        btnIt.onClick.AddListener(() => cliqueBoxAcionado());
    }

    protected abstract void cliqueBoxAcionado();

    public virtual void posCliqueBtnClose() { }
}
