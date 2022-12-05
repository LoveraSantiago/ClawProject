using UnityEngine;

public class ItemLevelScroll 
{
    private static Material estrelaBranca;
    private static Material estrelaColorida;

    public int indiceLevel { get; private set; }
    public bool isExclamacaoLigado { get; private set; }
    public Material material { get; private set; }

    private ItemLevelDto itemLevelDto;

    public ItemLevelScroll(ItemLevelDto itemLevelDto)
    {
        this.itemLevelDto = itemLevelDto;
        material = MaterialMiniMaquina.getNewMaterial();
        colocarCorBranca();
        setMaterial(material);
    }

    public string getNomeItem()
    {
        return itemLevelDto.RItem.name;
    }

    public int getNomeItemNumerico()
    {
        return int.Parse(getNomeItem());
    }

    public float getHaltura()
    {
        return itemLevelDto.RItem.rect.height;
    }

    public float getPosY()
    {
        return itemLevelDto.RItem.position.y;
    }

    public Vector3 getPosicaoImgMaquina()
    {
        return itemLevelDto.ImgMaquina.transform.position;
    }

    private void setMaterial(Material material)
    {
        itemLevelDto.ImgMaquina.material = material;
    }

    public void colocarCorBranca()
    {
        itemLevelDto.ImgEstrela1.color = Color.white;
        itemLevelDto.ImgEstrela2.color = Color.white;
        itemLevelDto.ImgEstrela3.color = Color.white;
    }

    public void colorirImgMaquina(AbstractLevel level)
    {
        int numeroEstrelas = ChallengesUtils.toQtdEstrelas(level.challenge);
        //Debug.Log("Colorindo nivel estrelas " + numeroEstrelas);
        MaterialMiniMaquina.addCores(numeroEstrelas, material, level.getDicionarioDeCores());
        itemLevelDto.ImgEstrela1.material = numeroEstrelas >= 1 ? estrelaColorida : estrelaBranca;
        itemLevelDto.ImgEstrela2.material = numeroEstrelas >= 2 ? estrelaColorida : estrelaBranca;
        itemLevelDto.ImgEstrela3.material = numeroEstrelas >= 3 ? estrelaColorida : estrelaBranca;
    }

    public void desligar()
    {
        itemLevelDto.RItem.gameObject.SetActive(false);
    }

    public void ligar()
    {
        itemLevelDto.RItem.gameObject.SetActive(true);
    }

    public void desligarExclamacao()
    {
        isExclamacaoLigado = false;
        itemLevelDto.Exclamacao.SetActive(false);
    }

    public void ligarExclamacao()
    {
        itemLevelDto.Exclamacao.SetActive(true);
        isExclamacaoLigado = true;
    }

    public void desligarImgMaquina()
    {
        //Debug.Log("Desligar img maquina chamado");
        itemLevelDto.ImgMaquina.gameObject.SetActive(false);
    }

    public void ligarImgMaquina()
    {
        itemLevelDto.ImgMaquina.gameObject.SetActive(true);
    }

    public void addLabels(int indiceLevel, string titulo, AbstractLevel level)
    {
        this.indiceLevel = indiceLevel;
        itemLevelDto.LblLevel.text = level.getLevelName();
        itemLevelDto.LblMap.text = titulo;
        itemLevelDto.LblMaquina.text = level.getMaquinaNome();
        itemLevelDto.LblScore.text = level.score.ToString();
        itemLevelDto.LblTempo.text = level.tempo;
    }

    public Vector2 getAnchoredPosition()
    {
        return itemLevelDto.RItem.anchoredPosition;
    }

    public void setAnchoredPosition(Vector2 posicao)
    {
        itemLevelDto.RItem.anchoredPosition = posicao;
    }

    public static void configurarSpritesEstrelas(Material estralaBrancaArg, Material estrelaColoridaArg)
    {
        estrelaBranca = estralaBrancaArg;
        estrelaColorida = estrelaColoridaArg;
    }
}
