using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

#pragma warning disable 0649
public class PupScene : MonoBehaviour
{
    [SerializeField] private Button btnBack;
    [Space(5)]
    [SerializeField] private GameObject prefabPowerUpDto;
    [Space(5)]
    [SerializeField] private Animator animatorBottonBar;
    [SerializeField] private Button btnBottonBar;

    // Start is called before the first frame update
    void Start()
    {
        configButtonBack(btnBack);
        new BottomBar(animatorBottonBar, btnBottonBar, this);

        PrefabPowerUpDto prefabPUpDto = prefabPowerUpDto.GetComponent<PrefabPowerUpDto>();
        PowerUpEntidade.configurarDicionarioDeSpritesPup(prefabPUpDto.getInstance().dicionarioDeSprites);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void configButtonBack(Button btnBack)
    {
        btnBack.onClick.AddListener(() => SceneManager.LoadScene("MapScene"));
    }
}
