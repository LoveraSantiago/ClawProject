using System.Collections.Generic;
using UnityEngine;

public class ColoridorMaquina 
{
    public void colorir(
        PartesMaquinaDto partesDto, Dictionary<string, string> dicionarioDeCores)
    {
        string corHex = dicionarioDeCores[ConstantesCoresMaquina.PLACA_CIMA];
        partesDto.PlacaCima.color = Utils.getCorByHex(corHex);

        corHex = dicionarioDeCores[ConstantesCoresMaquina.BASE_PARTE];
        Color cor = Utils.getCorByHex(corHex);
        partesDto.BaseParteCima.color = cor;
        partesDto.BaseParteBaixo.color = cor;

        corHex = dicionarioDeCores[ConstantesCoresMaquina.BASE_CHAO];
        partesDto.BaseChao.color = Utils.getCorByHex(corHex);        

        corHex = dicionarioDeCores[ConstantesCoresMaquina.PLACA_FRONTAL];
        partesDto.PlacaFrontal.color = Utils.getCorByHex(corHex);

        corHex = dicionarioDeCores[ConstantesCoresMaquina.BARRA];
        partesDto.Barra.color = Utils.getCorByHex(corHex);

        corHex = dicionarioDeCores[ConstantesCoresMaquina.CHAO_DENTRO];
        partesDto.ChaoDentro.color = Utils.getCorByHex(corHex);

        corHex = dicionarioDeCores[ConstantesCoresMaquina.PLACA_SAIDA];
        partesDto.PlacaDeSaida.color = Utils.getCorByHex(corHex);        

        corHex = dicionarioDeCores[ConstantesCoresMaquina.PLACA_FICHA];
        partesDto.PlacaFicha.color = Utils.getCorByHex(corHex);

        corHex = dicionarioDeCores[ConstantesCoresMaquina.PLACA_P_CIMA];
        partesDto.PlacaParteCima.color = Utils.getCorByHex(corHex);

        corHex = dicionarioDeCores[ConstantesCoresMaquina.PLACA_P_BAIXO];
        partesDto.PlacaParteBaixo.color = Utils.getCorByHex(corHex);

        corHex = dicionarioDeCores[ConstantesCoresMaquina.QUADRADO_MAIOR];
        partesDto.QuadMaior.color = Utils.getCorByHex(corHex);

        corHex = dicionarioDeCores[ConstantesCoresMaquina.QUADRADO_MENOR];
        partesDto.QuadMenor.color = Utils.getCorByHex(corHex);

        corHex = dicionarioDeCores[ConstantesCoresMaquina.FURO_CIMA];
        partesDto.FuroCima.color = Utils.getCorByHex(corHex);

        corHex = dicionarioDeCores[ConstantesCoresMaquina.FURO_BAIXO];
        partesDto.FuroBaixo.color = Utils.getCorByHex(corHex);
    }
}
