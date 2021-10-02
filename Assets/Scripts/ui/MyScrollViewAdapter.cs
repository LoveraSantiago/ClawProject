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

    List<ExampleItemView> views = new List<ExampleItemView>();

    private void Start()
    {
        
    }

    public void updateItems()
    {
        Debug.Log("Update Items chamado");
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

        views.Clear();
        int i = 0;

        foreach(var model in models)
        {
            GameObject instance = GameObject.Instantiate(prefab.gameObject) as GameObject;
            instance.transform.SetParent(content, false);

            ExampleItemView view = initializeItemView(instance, model);
            views.Add(view);
            ++i;
        }
    }

    ExampleItemView initializeItemView(GameObject viewGameObject, ExampleItemModel model)
    {
        ExampleItemView view = new ExampleItemView(viewGameObject.transform);
        view.titleText.text = model.title;
        view.icon1Image.texture = availableIcons[model.iconIndex];
        view.icon2Image.texture = availableIcons[model.icon2Index];
        view.icon3Image.texture = availableIcons[model.icon3Index];
        return view;
    }

    IEnumerator fetchItemModelsFromServer(int count, Action<ExampleItemModel[]> onDone)
    {
        yield return new WaitForSeconds(2f);

        ExampleItemModel[] results = new ExampleItemModel[count];
        for (int i = 0; i < count; ++i)
        {
            results[i] = new ExampleItemModel();
            results[i].title = "Item " + i;
            results[i].iconIndex = UnityEngine.Random.Range(0, availableIcons.Length);
            results[i].icon2Index= UnityEngine.Random.Range(0, availableIcons.Length);
            results[i].icon3Index = UnityEngine.Random.Range(0, availableIcons.Length);

            Debug.Log("Construido " + results[i].title);
        }
        onDone.Invoke(results);
    }

    public class ExampleItemView
    {
        public Text titleText;
        public RawImage icon1Image, icon2Image, icon3Image;

        public ExampleItemView(Transform rootView)
        {
            titleText = rootView.Find("TitlePanel/TitleText").GetComponent<Text>();
            icon1Image = rootView.Find("Icon1Image").GetComponent<RawImage>();
            icon2Image = rootView.Find("Icon2Image").GetComponent<RawImage>();
            icon3Image = rootView.Find("TitlePanel/Icon3Image").GetComponent<RawImage>();
        }
    }

    public class ExampleItemModel
    {
        public string title;
        public int iconIndex, icon2Index, icon3Index;
    }

    //#region ScrollRectItemsAdapter8 code

    //class MyParams : BaseParams
    //{

    //}

    //class MyItemViewHolder : BaseItemViewHolder
    //{

    //}

    //class MyScrollRectAdapter : ScrollRectItemsAdapter<MyParams, MyItemViewHolder>
    //{

    //}

    //#endregion
}
