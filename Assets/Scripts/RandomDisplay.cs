using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RandomDisplay : MonoBehaviour
{
    [SerializeField] private Text name;
    [SerializeField] private Text rom;



    List<SimpleWord> simpleRandom = new List<SimpleWord>();

    int curIndex = 0;

    public void SetRadomOrder(List<SimpleWord> data) {
        simpleRandom = GetRamdomOrder<SimpleWord>(data);
        curIndex = 0;
        name.text = simpleRandom[curIndex].name;
        rom.text = simpleRandom[curIndex].rom;
        curIndex++;
    }

    public void Next() {
        if(curIndex < simpleRandom.Count) {
            rom.gameObject.SetActive(false);
            name.text = simpleRandom[curIndex].name;
            rom.text = simpleRandom[curIndex].rom;
            curIndex++;
        } else {
            GetComponent<GameMain>().OnOrderChange();
            Debug.Log("结束了此轮");
        }
    }



    public List<T> GetRamdomOrder<T>(List<T> inputList) {
        
        List<T> shuffledList = new List<T>(inputList);
        System.Random random = new System.Random();
        // 使用Fisher-Yates洗牌算法
        int n = shuffledList.Count;
        while (n > 1) {
            n--;
            int k = random.Next(n + 1);
            T value = shuffledList[k];
            shuffledList[k] = shuffledList[n];
            shuffledList[n] = value;
        }

        return shuffledList;
        
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
