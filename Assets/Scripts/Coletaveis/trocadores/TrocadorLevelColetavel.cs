using UnityEngine;

public class TrocadorLevelColetavel : TrocadorDeOrdem
{
    private TrincaColetaveisTiles trincaColetaveis;

    public TrocadorLevelColetavel(TrincaColetaveisTiles trincaColetaveis)
    {
        this.trincaColetaveis = trincaColetaveis;
    }

    public override void atualizar(ColetavelTile coletavelPrimeiro)
    {
        //Debug.Log("atualizar ordem chamado");
        if (trincaColetaveis.isColetavelNaTrinca(coletavelPrimeiro))
        {
            addMaterialOutline(coletavelPrimeiro);
        }
        else
        {
            addMaterialGrayScale(coletavelPrimeiro);
        }
    }

    public override void trocarFigura(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo)
    {
        //Debug.Log("trocar figura chamado");
        if (trincaColetaveis.isColetavelNaTrinca(coletavelPrimeiro) &&
            trincaColetaveis.isColetavelNaTrinca(coletavelSegundo))
        {
            Material materialOutline = MaterialOutline.of(coletavelPrimeiro.getSprite());
            coletavelPrimeiro.addMaterial(materialOutline);
        }
        else
        {
            addMaterialGrayScale(coletavelPrimeiro);
        }
    }

    public override void trocar(ColetavelTile coletavelPrimeiro, ColetavelTile coletavelSegundo)
    {
        //Debug.Log("trocar ordem chamado");

        bool primeiroNaTrinca = trincaColetaveis.isColetavelNaTrinca(coletavelPrimeiro);
        bool segundoNaTrinca  = trincaColetaveis.isColetavelNaTrinca(coletavelSegundo);

        if (primeiroNaTrinca && segundoNaTrinca)
        {
            addMaterialOutline(coletavelPrimeiro);
            addMaterialOutline(coletavelSegundo);
        }
        else if(primeiroNaTrinca && !segundoNaTrinca)
        {
            addMaterialOutline(coletavelSegundo);
            addMaterialGrayScale(coletavelPrimeiro);
            //Debug.Log("Na trinca" + coletavelPrimeiro.nome);
            //Debug.Log("Nao trinca" + coletavelSegundo.nome);
            trocarNaTrinca(coletavelPrimeiro, coletavelSegundo);            
        }
        else if(!primeiroNaTrinca && segundoNaTrinca)
        {
            addMaterialOutline(coletavelPrimeiro);
            addMaterialGrayScale(coletavelSegundo);
            //Debug.Log("Na trinca" + coletavelSegundo.nome);
            //Debug.Log("Nao trinca" + coletavelPrimeiro.nome);
            trocarNaTrinca(coletavelSegundo, coletavelPrimeiro);
        }
        else if(!primeiroNaTrinca && !segundoNaTrinca)
        {
            addMaterialGrayScale(coletavelPrimeiro);
            addMaterialGrayScale(coletavelSegundo);
        }
    }    
    
    private void trocarNaTrinca(ColetavelTile coletavelRemocao, ColetavelTile coletavelInsercao)
    {
        int indice = trincaColetaveis.getIndiceNaTrinca(coletavelRemocao);
        trincaColetaveis.trocarIndice(indice, coletavelInsercao);
    }   
}
