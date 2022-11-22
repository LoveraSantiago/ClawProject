using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading 
{
    private static readonly string LABEL_LOADING = "LOADING... {0}%";
    private static readonly int FECHAR_MODAL = Animator.StringToHash("fechar-loading");
    private static readonly int ABRIR_MODAL  = Animator.StringToHash("abrir-loading");

    private LoadingDto loadingDto;
    private SomLoading somLoading;
    private GameObject[] gosDesligar;

    public Loading(LoadingDto loadingDto, SomLoading somLoading, GameObject[] gosDesligar)
    {
        this.loadingDto = loadingDto;
        this.somLoading = somLoading;
        this.gosDesligar = gosDesligar;
    }

    public void irParaMapScene()
    {
        abrirModal("MapScene");
    }

    public void irParaPowerUpCena()
    {
        abrirModal("PupSceneV2");
    }

    public void irParaLojaCena()
    {
        abrirModal("LojaScene");
    }

    public void irParaLevelCena()
    {
        abrirModal("LevelsScene");
    }

    public void irParaColetaveisCena()
    {
        abrirModal("ColetaveisSceneV2");
    }

    public void irParaConfiguracaoCena()
    {
        abrirModal("ConfigScene");
    }

    public void irParaGameCena()
    {
        abrirModal("MainGameScene");
    }

    public void fecharModal()
    {
        loadingDto.GoCanvas.gameObject.SetActive(true);
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineFecharModal());
    }

    private void abrirModal(string nomeCena)
    {
        loadingDto.GoCanvas.gameObject.SetActive(true);
        ContextoEstaticoUtils.MonoBehaviour.StartCoroutine(coroutineAbrirModal(nomeCena));
    }

    private void desligarGos()
    {
        if(gosDesligar != null)
        {
            for(int contador = 0; contador < gosDesligar.Length; contador++)
            {
                gosDesligar[contador].SetActive(false);
            }
        }
    }

    private IEnumerator coroutineAbrirModal(string nomeCena)
    {
        somLoading.stopSomBackground();
        loadingDto.Animator.Play(ABRIR_MODAL);
        yield return new WaitForSeconds(0.1f);

        somLoading.playSomBumpModal();
        loadingDto.LblLoadingTexto.text = string.Format(LABEL_LOADING, 0);
        yield return null;

        somLoading.playSomGarraGirando();
        yield return new WaitForSeconds(loadingDto.DelayAbrirModal);

        desligarGos();
        yield return null;

        AsyncOperation operation = SceneManager.LoadSceneAsync(nomeCena);
        operation.allowSceneActivation = false;
        while (operation.progress < 0.89)
        {
            int progresso = (int)(operation.progress * 100);
            loadingDto.LblLoadingTexto.text = string.Format(LABEL_LOADING, progresso);
            //Debug.Log(operation.progress);
            yield return null;
        }
        loadingDto.LblLoadingTexto.text = string.Format(LABEL_LOADING, 100);        
        yield return new WaitForSeconds(loadingDto.DelayFecharModal);
        operation.allowSceneActivation = true;
        yield return null;
    }

    private IEnumerator coroutineFecharModal()
    {
        somLoading.stopSomGarraGirando();
        yield return null;
        
        loadingDto.Animator.Play(FECHAR_MODAL);
        somLoading.playSomBumpModal();
        yield return new WaitForSeconds(loadingDto.DelayFecharModal);

        loadingDto.GoCanvas.gameObject.SetActive(false);
    }
}
