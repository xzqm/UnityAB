using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameMain : MonoBehaviour
{
    string pingName = "あ い う え お か き く け こ さ し す せ そ た ち つ て と な に ぬ ね の は ひ ふ へ ほ ま み む め も や ゆ よ ら り る れ ろ わ を ん";

    string defaultFileName = "d0.txt";
    string line1 = "d1.txt";
    string line2 = "d2.txt";
    string line3 = "d3.txt";
    string line4 = "d4.txt";
    string line5 = "d5.txt";
    string line6 = "d6.txt";
    string line7 = "d7.txt";
    string line8 = "d8.txt";
    string line9 = "d9.txt";
    string line10 = "d10.txt";
    string line11 = "d11.txt";
    string line12 = "d12.txt";

    public List<SimpleWord> words = new List<SimpleWord>();

    public List<Data> globalData = new List<Data>();

    public Action OnOrderChange;
    private void Awake() {
        init();
    }

    private void Start() {
        OnOrderChange += RefreshOrder;
    }

    public void RefreshOrder() {
        GetComponent<RandomDisplay>().SetRadomOrder(words);
    }

    private void init() {
        PlayerPrefs.GetInt("SAVEINDEX");
    }

    void GetContentByIndexFromJson(int index) {
        string filename = "";
        switch (index) {
            case 0:
                break;
            case 1:
                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
            case 7:
                break;
            case 8:
                break;
            case 9:
                break;
            case 10:
                break;
            case 11:
                break;
            default:
                break;

        }
    }























    string a = "";
    List<string> pingList = new List<string>();
    void sss() {
        string[] sssss = pingName.Split(' ');
        foreach (string ssss in sssss) {
            pingList.Add(ssss);
            Debug.Log(ssss);
        }
        
    }



}
