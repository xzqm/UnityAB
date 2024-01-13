using System.Collections;
using System.Collections.Generic;
using System.IO;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using LitJson;
using System;

public class SaveJsonTest : MonoBehaviour
{
    string filePath;
    string primitiveFilePath = Application.streamingAssetsPath + "/primitive.txt";
    string allsimpleworldsPath = Application.streamingAssetsPath + "/allsimplewords.txt";
    public Button saveBtn;
    public Button readBtn;

    public GameMain gameMain;
    string jsontext = "[{\"name\":\"\\u3042\",\"rom\":\"a\"},{\"name\":\"\\u3044\",\"rom\":\"i\"},{\"name\":\"\\u3046\",\"rom\":\"u\"},{\"name\":\"\\u3048\",\"rom\":\"e\"},{\"name\":\"\\u304A\",\"rom\":\"o\"},{\"name\":\"\\u304B\",\"rom\":\"ka\"},{\"name\":\"\\u304D\",\"rom\":\"ki\"},{\"name\":\"\\u304F\",\"rom\":\"ku\"},{\"name\":\"\\u3051\",\"rom\":\"ke\"},{\"name\":\"\\u3053\",\"rom\":\"ko\"},{\"name\":\"\\u3055\",\"rom\":\"sa\"},{\"name\":\"\\u3057\",\"rom\":\"shi\"},{\"name\":\"\\u3059\",\"rom\":\"su\"},{\"name\":\"\\u305B\",\"rom\":\"se\"},{\"name\":\"\\u305D\",\"rom\":\"so\"},{\"name\":\"\\u305F\",\"rom\":\"ta\"},{\"name\":\"\\u3061\",\"rom\":\"chi\"},{\"name\":\"\\u3064\",\"rom\":\"tsu\"},{\"name\":\"\\u3066\",\"rom\":\"te\"},{\"name\":\"\\u3068\",\"rom\":\"to\"},{\"name\":\"\\u306A\",\"rom\":\"na\"},{\"name\":\"\\u306B\",\"rom\":\"ni\"},{\"name\":\"\\u306C\",\"rom\":\"nu\"},{\"name\":\"\\u306D\",\"rom\":\"ne\"},{\"name\":\"\\u306E\",\"rom\":\"no\"},{\"name\":\"\\u306F\",\"rom\":\"ha\"},{\"name\":\"\\u3072\",\"rom\":\"hi\"},{\"name\":\"\\u3075\",\"rom\":\"fu\"},{\"name\":\"\\u3078\",\"rom\":\"he\"},{\"name\":\"\\u307B\",\"rom\":\"ho\"},{\"name\":\"\\u307E\",\"rom\":\"ma\"},{\"name\":\"\\u307F\",\"rom\":\"mi\"},{\"name\":\"\\u3080\",\"rom\":\"mu\"},{\"name\":\"\\u3081\",\"rom\":\"me\"},{\"name\":\"\\u3082\",\"rom\":\"mo\"},{\"name\":\"\\u3084\",\"rom\":\"ya\"},{\"name\":\"\\u3086\",\"rom\":\"yu\"},{\"name\":\"\\u3088\",\"rom\":\"yo\"},{\"name\":\"\\u3089\",\"rom\":\"ra\"},{\"name\":\"\\u308A\",\"rom\":\"ri\"},{\"name\":\"\\u308B\",\"rom\":\"ru\"},{\"name\":\"\\u308C\",\"rom\":\"re\"},{\"name\":\"\\u308D\",\"rom\":\"ro\"},{\"name\":\"\\u308F\",\"rom\":\"wa\"},{\"name\":\"\\u3092\",\"rom\":\"wo\"},{\"name\":\"\\u3093\",\"rom\":\"n\"},{\"name\":\"\\u30A2\",\"rom\":\"a\"},{\"name\":\"\\u30A4\",\"rom\":\"i\"},{\"name\":\"\\u30A6\",\"rom\":\"u\"},{\"name\":\"\\u30A8\",\"rom\":\"e\"},{\"name\":\"\\u30AA\",\"rom\":\"o\"},{\"name\":\"\\u30AB\",\"rom\":\"ka\"},{\"name\":\"\\u30AD\",\"rom\":\"ki\"},{\"name\":\"\\u30AF\",\"rom\":\"ku\"},{\"name\":\"\\u30B1\",\"rom\":\"ke\"},{\"name\":\"\\u30B3\",\"rom\":\"ko\"},{\"name\":\"\\u30B5\",\"rom\":\"sa\"},{\"name\":\"\\u30B7\",\"rom\":\"shi\"},{\"name\":\"\\u30B9\",\"rom\":\"su\"},{\"name\":\"\\u30BB\",\"rom\":\"se\"},{\"name\":\"\\u30BD\",\"rom\":\"so\"},{\"name\":\"\\u30BF\",\"rom\":\"ta\"},{\"name\":\"\\u30C1\",\"rom\":\"chi\"},{\"name\":\"\\u30C4\",\"rom\":\"tsu\"},{\"name\":\"\\u30C6\",\"rom\":\"te\"},{\"name\":\"\\u30C8\",\"rom\":\"to\"},{\"name\":\"\\u30CA\",\"rom\":\"na\"},{\"name\":\"\\u30CB\",\"rom\":\"ni\"},{\"name\":\"\\u30CC\",\"rom\":\"nu\"},{\"name\":\"\\u30CD\",\"rom\":\"ne\"},{\"name\":\"\\u30CE\",\"rom\":\"no\"},{\"name\":\"\\u30CF\",\"rom\":\"ha\"},{\"name\":\"\\u30D2\",\"rom\":\"hi\"},{\"name\":\"\\u30D5\",\"rom\":\"fu\"},{\"name\":\"\\u30D8\",\"rom\":\"he\"},{\"name\":\"\\u30DB\",\"rom\":\"ho\"},{\"name\":\"\\u30DE\",\"rom\":\"ma\"},{\"name\":\"\\u30DF\",\"rom\":\"mi\"},{\"name\":\"\\u30E0\",\"rom\":\"mu\"},{\"name\":\"\\u30E1\",\"rom\":\"me\"},{\"name\":\"\\u30E2\",\"rom\":\"mo\"},{\"name\":\"\\u30E4\",\"rom\":\"ya\"},{\"name\":\"\\u30E6\",\"rom\":\"yu\"},{\"name\":\"\\u30E8\",\"rom\":\"yo\"},{\"name\":\"\\u30E9\",\"rom\":\"ra\"},{\"name\":\"\\u30EA\",\"rom\":\"ri\"},{\"name\":\"\\u30EB\",\"rom\":\"ru\"},{\"name\":\"\\u30EC\",\"rom\":\"re\"},{\"name\":\"\\u30ED\",\"rom\":\"ro\"},{\"name\":\"\\u30EF\",\"rom\":\"wa\"},{\"name\":\"\\u30F2\",\"rom\":\"wo\"},{\"name\":\"\\u30F3\",\"rom\":\"n\"}]";
    private void Awake() {
        filePath = Application.persistentDataPath + "/test.json";
        File.WriteAllText(filePath, jsontext);
        readsimple();
        //Debug.Log("datapath:"+Application.dataPath);
    }

    // Start is called before the first frame update
    void Start()
    {
        saveBtn.onClick.AddListener(()=>{
            ReadSimpleWords(); 
        });
        readBtn.onClick.AddListener(readsimple);
    }

    void save() {//い     | イ     | いちご (ichigo)
        List<Data> datas = new List<Data>();
        datas.Add(new Data() { ping = "あ", pian = "ア", from = "芦", sample = "ありがとう (arigatou) (仍仍)" });
        datas.Add(new Data() { ping = "い", pian = "イ", from = "", sample = "いちご (ichigo) (課櫪)��" });

        string json = JsonMapper.ToJson(datas);
        File.AppendAllText(filePath, json);
        Debug.Log("save successful");
        Debug.Log("saved json:"+json);
        Debug.Log("saved datas:"+datas);
        
    }

    void read() {
        string json = File.ReadAllText(filePath);
        List<Data> ddss = JsonMapper.ToObject<List<Data>>(json);
        foreach (var d in ddss) {
            Debug.Log($"ping:{d.ping},pian:{d.pian},from:{d.from},sample:{d.sample},rom:({d.rom}),chinese:{d.chinese}");
        }
    }
    void readsimple() {
        string json = File.ReadAllText(filePath);
        gameMain.words = JsonMapper.ToObject<List<SimpleWord>>(json);
        foreach (var d in gameMain.words) {
            //Debug.Log($"name:{d.name},rom:({d.rom})");
        }
        gameMain.RefreshOrder();
    }


    void ReadFromPrimitive() {
        string[] lines = File.ReadAllLines(primitiveFilePath);
        List<Data> datas = new List<Data>();
        foreach (var line in lines) {
            string[] data = line.Split(" ");
            datas.Add(new Data() { ping = data[0], pian = data[1], /*from = data[2],*/ sample = data[2], rom = data[3],chinese = data[4] });
        }
        string json = JsonMapper.ToJson(datas);
        File.WriteAllText(filePath, json);


    }

    void ReadSimpleWords() {
        string[] lines = File.ReadAllLines(allsimpleworldsPath);
        List<SimpleWord> datas = new List<SimpleWord>();
        foreach (var line in lines) {
            string[] data = line.Split(" ");
            datas.Add(new SimpleWord() { name = data[0], rom = data[1]});
        }
        string json = JsonMapper.ToJson(datas);
        File.WriteAllText(filePath, json);
    }






}
