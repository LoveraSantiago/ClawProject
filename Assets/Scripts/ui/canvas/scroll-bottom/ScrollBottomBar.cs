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

        int qtdItems = getQtdItems();
        bordasBotoes = new GameObject[qtdItems];
        criarBoxes(prefabDto.ScrollBottomBarDto, qtdItems);

        prefabDto.ScrollBottomBarDto.RectTransfHorizontal.sizeDelta     = new Vector2(300f * qtdItems, 300f);
        prefabDto.ScrollBottomBarDto.RectTransfHorizontal.localPosition = new Vector3(300f * qtdItems, 0, 0);        
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

    private void criarBoxes(ScrollBottomBarDto scrollBottomBarDto, int qtdItems)
    {
        for (int contador = 1; contador < qtdItems; contador++)
        {
            GameObject go = GameObject.Instantiate(scrollBottomBarDto.BoxPup, scrollBottomBarDto.BoxPup.transform.parent);

            string qtdString = null;
            Sprite spr = null;
            recuperarDataFromItemIndice(contador, out qtdString, out spr);
            bindBox(contador, go, qtdString, spr);
        }
        
        string qtdStringZero = null;
        Sprite sprZero = null;
        recuperarDataFromItemIndice(0, out qtdStringZero, out sprZero);
        bindBox(0, scrollBottomBarDto.BoxPup, qtdStringZero, sprZero);
    }

    private void bindBox(int indiceName, GameObject box, string qtd, Sprite sprite)
    {
        TextMeshProUGUI text = box.transform.Find("lbl-qtd").GetComponent<TextMeshProUGUI>();
        text.text = qtd;

        Button btnIt = box.transform.Find("btn").GetComponent<Button>();
        btnIt.name = indiceName.ToString();
        btnIt.image.sprite = sprite;
        btnIt.onClick.AddListener(() => {
            if (!btnBottomBar.animacaoEmAndamento)
            {
                cliqueBoxAcionado(text);
            }
        });

        bordasBotoes[indiceName] = box.transform.Find("img-back-pup-borda").gameObject;
    }

    protected abstract int getQtdItems();
    protected abstract void recuperarDataFromItemIndice(int indice, out string qtdString, out Sprite spr);
    protected abstract void cliqueBoxAcionado(TextMeshProUGUI lblQtd);

    public virtual void posCliqueBtnClose() { }
}
