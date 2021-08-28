using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class ScrollBottomBar : AcaoPupIndice.ProdutorEvento
{
    private ProdutorDeEvento<int> produtorDeIndiceEscolhido;

    public ScrollBottomBar(ScrollBottomBarDto scrollBottomBarDto, BotaoBottomBarDto bottomBarDto, MonoBehaviour monoBehaviour)
    {
        BotaoBottomBar btnBottomBar = new BotaoBottomBar(bottomBarDto, monoBehaviour);

        PowerUpEntidade[] allPups = FactoryPowerUpEntidade.getAllPowerUps();
        criarBoxes(scrollBottomBarDto, allPups);

        scrollBottomBarDto.RectTransfHorizontal.sizeDelta = new Vector2(300f * allPups.Length, 300f);
        scrollBottomBarDto.RectTransfHorizontal.localPosition = new Vector3(300f * allPups.Length, 0, 0);

        produtorDeIndiceEscolhido = new ProdutorDeEvento<int>();
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
        btnIt.onClick.AddListener(() => cliqueAcionado());
    }

    private void cliqueAcionado()
    {
        string nomeBtnSelecionado = EventSystem.current.currentSelectedGameObject.name;
        produtorDeIndiceEscolhido.produziuEvento(int.Parse(nomeBtnSelecionado));
    }

    ProdutorDeEvento<int> AcaoPupIndice.ProdutorEvento.getProdutorDeEventoColetado()
    {
        return produtorDeIndiceEscolhido;
    }
}
