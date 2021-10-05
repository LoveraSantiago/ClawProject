using TMPro;
using UnityEngine;
using UnityEngine.UI;

public abstract class ScrollBottomBar
{
    protected BotaoBottomBar btnBottomBar;
    protected GameObject[] bordasBotoes;

    public ScrollBottomBar(GameObject prefabBottomBar)
    {
        PrefabScrollBottomBarDto prefabDto = prefabBottomBar.GetComponent<PrefabScrollBottomBarDto>();
        btnBottomBar = new BotaoBottomBar(prefabDto.BtnBottomBarDto, this);

        PowerUpEntidade[] allPups = FactoryPowerUpEntidade.getAllPowerUps();
        bordasBotoes = new GameObject[allPups.Length];
        criarBoxes(prefabDto.ScrollBottomBarDto, allPups);

        prefabDto.ScrollBottomBarDto.RectTransfHorizontal.sizeDelta = new Vector2(300f * allPups.Length, 300f);
        prefabDto.ScrollBottomBarDto.RectTransfHorizontal.localPosition = new Vector3(300f * allPups.Length, 0, 0);        
    }

    public void ligarBordas()
    {
        for(int contador = 0; contador < bordasBotoes.Length; contador++)
        {
            bordasBotoes[contador].SetActive(true);
        }
    }

    public void desligarBordas()
    {
        for (int contador = 0; contador < bordasBotoes.Length; contador++)
        {
            bordasBotoes[contador].SetActive(false);
        }
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
        text.text = PlayerPrefsPup.recuperarQtdPup(pupEntidade.nome).ToString();

        Button btnIt = box.transform.Find("btn").GetComponent<Button>();
        btnIt.name = indiceName.ToString();
        btnIt.image.sprite = pupEntidade.sprPowerUp;
        btnIt.onClick.AddListener(() => {
            if (!btnBottomBar.animacaoEmAndamento)
            {
                cliqueBoxAcionado(text);
            }
        });

        bordasBotoes[indiceName] = box.transform.Find("img-back-pup-borda").gameObject;
    }

    protected abstract void cliqueBoxAcionado(TextMeshProUGUI lblTQtd);

    public virtual void posCliqueBtnClose() { }
}
