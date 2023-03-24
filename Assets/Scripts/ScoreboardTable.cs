using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreboardTable : MonoBehaviour
{
    private Transform content;
    private Transform row;

    private void Awake()
    {
        content = transform.Find("ScoreboardContent");
        row = content.Find("Row");

        row.gameObject.SetActive(false);

        Transform header = transform.Find("Header");
        RectTransform headerRectTransform = header.GetComponent<RectTransform>();

        float rowHeight = 80f;
        for (int i = 0; i < 3; i++)
        {
            Transform entryTransform = Instantiate(row, content);
            RectTransform rectTransform = entryTransform.GetComponent<RectTransform>();
            rectTransform.anchoredPosition = new Vector2(headerRectTransform.position.x, -rowHeight * i);
            entryTransform.gameObject.SetActive(true);

            int rank = i + 1;
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

            entryTransform.Find("RankTxt").GetComponent<Text>().text = rank_str;
            entryTransform.Find("NameTxt").GetComponent<Text>().text = "...";
            entryTransform.Find("ScoreTxt").GetComponent<Text>().text = "...";
        }
    }
}
