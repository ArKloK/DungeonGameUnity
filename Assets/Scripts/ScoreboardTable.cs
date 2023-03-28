using System;
using System.Collections.Generic;
using System.Reflection;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreboardTable : MonoBehaviour
{
    private Transform content;
    private Transform row;
    private List<Transform> rowTransformList;

    private void Awake()
    {

        content = transform.Find("ScoreboardContent");
        row = content.Find("Row");

        row.gameObject.SetActive(false);
        //Basic operations in player prefs
        //AddRow("Carlos", 38888800);
        //ResetScoretable();
        //DeleteRow(4);

        Rows rows;
        //Getting data from player prefs
        if (!PlayerPrefs.HasKey("scoretable"))
        {
            rows = new Rows();
        }
        else
        {
            string jsonString = PlayerPrefs.GetString("scoretable");
            rows = JsonUtility.FromJson<Rows>(jsonString);

            //Sort the list
            for (int i = 0; i < rows.RowList.Count; i++)
            {
                for (int j = i + 1; j < rows.RowList.Count; j++)
                {
                    if (rows.RowList[j].score > rows.RowList[i].score)
                    {
                        Row tmp = rows.RowList[i];
                        rows.RowList[i] = rows.RowList[j];
                        rows.RowList[j] = tmp;
                    }
                }
            }

            //Locate the list in the RectTransform
            rowTransformList = new List<Transform>();
            for (int i = 0; i < 3; i++)
            {
                CreateRowTransform(rows.RowList[i], content, rowTransformList);
            }
        }
    }

    private void CreateRowTransform(Row newRow, Transform content, List<Transform> transformList)
    {
        Transform header = transform.Find("Header");
        RectTransform headerRectTransform = header.GetComponent<RectTransform>();

        float rowHeight = 80f;

        Transform entryTransform = Instantiate(row, content);
        RectTransform rectTransform = entryTransform.GetComponent<RectTransform>();
        rectTransform.anchoredPosition = new Vector2(headerRectTransform.position.x, -rowHeight * transformList.Count);
        entryTransform.gameObject.SetActive(true);

        int rank = transformList.Count + 1;
        string rank_str;

        switch (rank)
        {
            case 1:
                rank_str = "1ST";
                break;
            case 2:
                rank_str = "2ND";
                break;
            case 3:
                rank_str = "3RD";
                break;
            default:
                rank_str = rank + "TH";
                break;
        }

        entryTransform.Find("RankTxt").GetComponent<TextMeshProUGUI>().text = rank_str;

        string name = newRow.name;
        entryTransform.Find("NameTxt").GetComponent<TextMeshProUGUI>().text = name;

        int score = newRow.score;

        string minutos = Mathf.Floor(score / 60).ToString("00");
        string segundos = Mathf.Floor(score % 60).ToString("00");

        string score_str = minutos + " : " + segundos;
        entryTransform.Find("ScoreTxt").GetComponent<TextMeshProUGUI>().text = score_str;

        transformList.Add(entryTransform);
    }

    private void AddRow(string name, int score)
    {
        Row row = new Row { score = score, name = name };

        Rows rows;
        if (!PlayerPrefs.HasKey("scoretable"))
        {
            rows = new Rows();
            rows.RowList = new List<Row>();
        }
        else
        {
            string jsonString = PlayerPrefs.GetString("scoretable");
            rows = JsonUtility.FromJson<Rows>(jsonString);
        }

        rows.RowList.Add(row);

        string json = JsonUtility.ToJson(rows);
        PlayerPrefs.SetString("scoretable", json);
        PlayerPrefs.Save();
    }

    private void DeleteRow(int index)
    {
        string jsonString = PlayerPrefs.GetString("scoretable");
        Rows rows = JsonUtility.FromJson<Rows>(jsonString);

        rows.RowList.RemoveAt(index);

        string json = JsonUtility.ToJson(rows);
        PlayerPrefs.SetString("scoretable", json);
        PlayerPrefs.Save();
    }

    private void ResetScoretable()
    {
        string jsonString = PlayerPrefs.GetString("scoretable");
        Rows rows = JsonUtility.FromJson<Rows>(jsonString);

        rows.RowList.Clear();

        string json = JsonUtility.ToJson(rows);
        PlayerPrefs.SetString("scoretable", json);
        PlayerPrefs.Save();
    }

    public void AddScore(TMP_InputField name)
    {
        int seconds = (int)DontDestroyCounter.GetCounter();
        AddRow(name.text, seconds);
        SceneManager.LoadScene("MenuPrincipal");
    }

    private class Rows
    {
        public List<Row> RowList;
    }

    //References a new row
    [Serializable]
    private class Row
    {
        public int score;
        public string name;
    }
}


