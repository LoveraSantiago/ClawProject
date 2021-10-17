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

        ItemsBottomBar items = getItemsBottomBar();

        int qtdItems = items.getQtdItems();
        bordasBotoes = new GameObject[qtdItems];
        criarBoxes(prefabDto.ScrollBottomBarDto, items);

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

    private void criarBoxes(ScrollBottomBarDto scrollBottomBarDto, ItemsBottomBar items)
    {
        for (int contador = 1; contador < items.getQtdItems(); contador++)
        {
            GameObject go = GameObject.Instantiate(scrollBottomBarDto.BoxPup, scrollBottomBarDto.BoxPup.transform.parent);

            string qtdString = items.getLabelQtdDoItemIndice(contador);
            Sprite spr = items.getSprDoItemIndice(contador);            
            bindBox(contador, go, qtdString, spr);
        }
        
        string qtdStringZero = items.getLabelQtdDoItemIndice(0);
        Sprite sprZero = items.getSprDoItemIndice(0);        
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
    
    protected abstract ItemsBottomBar getItemsBottomBar();
    protected abstract void cliqueBoxAcionado(TextMeshProUGUI lblQtd);

    public virtual void posCliqueBtnClose() { }
}
