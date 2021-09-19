using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class MyScrollViewAdapter : MonoBehaviour
{
    public Image[] availableIcons;
    public RectTransform prefab;
    public Text countText;

    private void Start()
    {
        
    }

    public void updateItems()
    {

    }

    void fetchItemModelsFromServer(int count, Action<ExampleItemModel[]> onDone)
    {
        //yield return new WaitForSeconds(2f);

        for(int i = 0; i < count; ++i)
        {

        }
    }

    public class ExampleItemModel
    {
        public string title;
        public int iconIndex, icon2Index, icon3Index;
    }
}
