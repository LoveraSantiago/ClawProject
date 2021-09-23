using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MyScrollViewAdapter : MonoBehaviour
{
    public Texture2D[] availableIcons;
    public RectTransform prefab;
    public Text countText;
    public ScrollRect scrollView;
    public RectTransform content;

    private void Start()
    {
        
    }

    public void updateItems()
    {
        int newCount;
        int.TryParse(countText.text, out newCount);
        StartCoroutine(fetchItemModelsFromServer(newCount, results => onReceivedNewModels(results)));
    }

    void onReceivedNewModels(ExampleItemModel[] models)
    {
        foreach(Transform child in content)
        {
            Destroy(child.gameObject);
        }

        foreach(var model in models)
        {
            GameObject instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(content, false);
        }
    }

    IEnumerator fetchItemModelsFromServer(int count, Action<ExampleItemModel[]> onDone)
    {
        yield return new WaitForSeconds(2f);

        ExampleItemModel[] results = new ExampleItemModel[count];
        for (int i = 0; i < count; ++i)
        {
            results[i] = new ExampleItemModel();
            results[i].title = "Item " + 1;
            results[i].iconIndex = UnityEngine.Random.Range(0, availableIcons.Length);
            results[i].icon2Index= UnityEngine.Random.Range(0, availableIcons.Length);
            results[i].icon3Index = UnityEngine.Random.Range(0, availableIcons.Length);
        }
    }

    public class ExampleItemView
    {
        public Text titleText;
        public Image icon1Image, icon2Image, icon3Image;

        public ExampleItemView(Transform rootView)
        {
            
        }
    }

    public class ExampleItemModel
    {
        public string title;
        public int iconIndex, icon2Index, icon3Index;
    }
}
