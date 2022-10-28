using UnityEngine;
using System.Collections.Generic;

public class FactoryMapaEntidade 
{
    private static Dictionary<MapaEnum, MapaEntidade> mapasEntidadesPorMapaEnum = new Dictionary<MapaEnum, MapaEntidade>();
    private PrefabLevelsDto prefabsLevelsDto;

    public MapaEntidade getMapaEntidadeByMapaEnum(MapaEnum mapaEnum)
    {
        if (!mapasEntidadesPorMapaEnum.ContainsKey(mapaEnum))
        {
            MapaEntidade mapaEntidade = criarMapaEntidade(mapaEnum);
            mapasEntidadesPorMapaEnum.Add(mapaEnum, mapaEntidade);
        }
        return mapasEntidadesPorMapaEnum[mapaEnum];
    }

    private MapaEntidade criarMapaEntidade(MapaEnum mapaEnum)
    {
        LevelMapDto levelMapDto = prefabsLevelsDto.getLevelMapByEnum(mapaEnum);
        switch (mapaEnum)
        {
            case MapaEnum.DEFAULTS:
                return new MapaEntidade(levelMapDto)
                    .addInfo(0, "Defaults")
                    .addFornecedoresColetaveis(new DefaultFornecedorLevelsColetaveis());

            case MapaEnum.FRUTAS:
                //Debug.Log("Instanciado mapa entidade frutas");
                return new MapaEntidade(levelMapDto)
                    .addInfo(1, "PARQUE DE DIVERSÕES")
                    .addFornecedoresLevels(new FornecedorLevelsParqueDeDiversoes())
                    //.addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas());

            case MapaEnum.DINO:
                return new MapaEntidade(levelMapDto)
                    .addInfo(2, "PARQUE JURASSICO")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new FornecedorLevelColetaveisDinos());
                    //.addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas());

            case MapaEnum.BOLAS:
                return new MapaEntidade(levelMapDto)
                    .addInfo(3, "QUADRAS POLIESPORTIVAS")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new FornecedorLevelColetaveisBolas());
                //.addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas());

            case MapaEnum.FALLGUYS:
                return new MapaEntidade(levelMapDto)
                    .addInfo(4, "FULL GUYS WORLD")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new FornecedorLevelColetaveisFallGuys());
                //.addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas());

            case MapaEnum.YUYU:
                return new MapaEntidade(levelMapDto)
                    .addInfo(5, "DESERTO ATACAMA")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new FornecedorLevelColetaveisYuyu());
                //.addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas());

            case MapaEnum.GELEIA:
                return new MapaEntidade(levelMapDto)
                    .addInfo(6, "DESERTO DE GELO")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new FornecedorLevelColetaveisGeleia());
                //.addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas());

            case MapaEnum.MARIO:
                return new MapaEntidade(levelMapDto)
                    .addInfo(7, "X")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new FornecedorLevelColetaveisMario());
                //.addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas());

            case MapaEnum.MEGAMAN:
                return new MapaEntidade(levelMapDto)
                    .addInfo(8, "X")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new FornecedorLevelColetaveisMegaman());
                    //.addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas());

            case MapaEnum.COGUMELOS:
                return new MapaEntidade(levelMapDto)
                    .addInfo(9, "X")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new FornecedorLevelColetaveisCogumelos());
                //.addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas());

            case MapaEnum.POOPS:
                return new MapaEntidade(levelMapDto)
                    .addInfo(10, "X")
                    .addFornecedoresLevels(new FornecedorLevelsTestes())
                    .addFornecedoresColetaveis(new FornecedorLevelColetaveisPoop());
                //.addFornecedoresColetaveis(new FornecedorLevelColetaveisFrutas());

            case MapaEnum.CACANIQUEL:
                return new MapaEntidade(levelMapDto)
                    .addFornecedoresLevels(new FornecedorLevelsCacaNiquel());

            case MapaEnum.POWERUP:
                return new MapaEntidade(levelMapDto)
                    .addFornecedoresLevels(new FornecedorLevelsPowerUp());
        }
        return null;
    }

    public MapaEntidade[] getMapaEntidadesLiberados(int adicao)
    {
        int indiceMapaLiberado = PlayerPrefsMapas.getIndiceMapaLiberado();
        LevelMapDto[] levelMapsDto = prefabsLevelsDto.getLevelsMapLiberadosDto(indiceMapaLiberado, adicao);
        MapaEntidade[] mapaEntidades = new MapaEntidade[levelMapsDto.Length];
        for (int contador = 0; contador < levelMapsDto.Length; contador++)
        {
            MapaEntidade mapaEntidadeIt = mapaEntidades[contador];
            mapaEntidadeIt = getMapaEntidadeByMapaEnum(levelMapsDto[contador].MapaEnum);//PROBLEMA
            if (mapaEntidadeIt.id <= indiceMapaLiberado)
            {
                mapaEntidadeIt.liberar();
            }
            mapaEntidades[contador] = mapaEntidadeIt;
        }
        return mapaEntidades;
    }

    public void configurar(PrefabLevelsDto prefabsLevelsDtoArg)
    {
        prefabsLevelsDto = prefabsLevelsDtoArg;
    }
}
