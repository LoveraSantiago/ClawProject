using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Loading 
{
    private static readonly string LABEL_LOADING = "LOADING... {0}%";
    private static readonly int FECHAR_MODAL = Animator.StringToHash("fechar-loading");
    private static readonly int ABRIR_MODAL = Animator.StringToHash("abrir-loading");

    private LoadingDto loadingDto;
    private SomLoading somLoading;

    public Loading(LoadingDto loadingDto, SomLoading somLoading)
    {
        this.loadingDto = loadingDto;
        this.somLoading = somLoading;
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

    private IEnumerator coroutineAbrirModal(string nomeCena)
    {
        somLoading.playSomAbrirModal();
        loadingDto.Animator.Play(ABRIR_MODAL);
        loadingDto.LblLoadingTexto.text = string.Format(LABEL_LOADING, 0);
        yield return null;

        somLoading.playGarraGirando();
        yield return new WaitForSeconds(loadingDto.DelayAbrirModal);        

        AsyncOperation operation = SceneManager.LoadSceneAsync(nomeCena);
        operation.allowSceneActivation = false;
        while (operation.progress < 0.89)
        {
            float progresso = operation.progress * 100;
            loadingDto.LblLoadingTexto.text = string.Format(LABEL_LOADING, progresso);
            //Debug.Log(operation.progress);
            yield return null;
        }
        loadingDto.LblLoadingTexto.text = string.Format(LABEL_LOADING, 100);
        //loadingDto.Animator.Play(FECHAR_MODAL);
        //somLoading.playSomAbrirModal();
        yield return new WaitForSeconds(loadingDto.DelayFecharModal);
        operation.allowSceneActivation = true;
        yield return null;
    }

    private IEnumerator coroutineFecharModal()
    {
        yield return null;
        somLoading.playGarraGirando();        
        
        loadingDto.Animator.Play(FECHAR_MODAL);
        somLoading.playSomAbrirModal();
        yield return new WaitForSeconds(loadingDto.DelayFecharModal);

        loadingDto.GoCanvas.gameObject.SetActive(false);
    }
}
