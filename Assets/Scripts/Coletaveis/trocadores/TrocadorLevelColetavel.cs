using UnityEngine;

public class TrocadorLevelColetavel : TrocadorDeOrdem
{
    private TrincaColetaveisTiles trincaColetaveis;

    public TrocadorLevelColetavel(TrincaColetaveisTiles trincaColetaveis)
    {
        this.trincaColetaveis = trincaColetaveis;
    }

    public override void atualizar(Coletavel coletavel)
    {
        //Debug.Log("atualizar ordem chamado");
        if (trincaColetaveis.isColetavelNaTrinca(coletavel))
        {
            addMaterialOutline(coletavel);
        }
        else
        {
            addMaterialGrayScale(coletavel);
        }
    }

    public override void trocarFigura(Coletavel coletavel1, Coletavel coletavel2)
    {
        //Debug.Log("trocar figura chamado");
        if (trincaColetaveis.isColetavelNaTrinca(coletavel1) &&
            trincaColetaveis.isColetavelNaTrinca(coletavel2))
        {
            Material materialOutline = MaterialOutline.of(coletavel1.getSprite());
            coletavel1.addMaterial(materialOutline);
        }
        else
        {
            addMaterialGrayScale(coletavel1);
        }
    }

    public override void trocar(Coletavel coletavel1, Coletavel coletavel2)
    {
        //Debug.Log("trocar ordem chamado");

        bool primeiroNaTrinca = trincaColetaveis.isColetavelNaTrinca(coletavel1);
        bool segundoNaTrinca  = trincaColetaveis.isColetavelNaTrinca(coletavel2);

        if (primeiroNaTrinca && segundoNaTrinca)
        {
            addMaterialOutline(coletavel1);
            addMaterialOutline(coletavel2);
        }
        else if(primeiroNaTrinca && !segundoNaTrinca)
        {
            addMaterialOutline(coletavel2);
            addMaterialGrayScale(coletavel1);
            //Debug.Log("Na trinca" + coletavelPrimeiro.nome);
            //Debug.Log("Nao trinca" + coletavelSegundo.nome);
            trocarNaTrinca(coletavel1, coletavel2);            
        }
        else if(!primeiroNaTrinca && segundoNaTrinca)
        {
            addMaterialOutline(coletavel1);
            addMaterialGrayScale(coletavel2);
            //Debug.Log("Na trinca" + coletavelSegundo.nome);
            //Debug.Log("Nao trinca" + coletavelPrimeiro.nome);
            trocarNaTrinca(coletavel2, coletavel1);
        }
        else if(!primeiroNaTrinca && !segundoNaTrinca)
        {
            addMaterialGrayScale(coletavel1);
            addMaterialGrayScale(coletavel2);
        }
    }    
    
    private void trocarNaTrinca(Coletavel coletavelRemocao, Coletavel coletavelInsercao)
    {
        int indice = trincaColetaveis.getIndiceNaTrinca(coletavelRemocao);
        trincaColetaveis.trocarIndice(indice, coletavelInsercao);
    }   
}
