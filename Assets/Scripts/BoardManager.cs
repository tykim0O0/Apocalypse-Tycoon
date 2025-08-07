using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    GameManager gameManager;

    public TMP_Text inventext;
    public TMP_Text invenNumtext;
    public TMP_Text moneytext;
    public TMP_Text daytext;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        daytext.text = "";
        moneytext.text = "";
        inventext.text = "";
        invenNumtext.text = "";
    }

    public void UpdateBoard()
    {
        // 날짜 업데이트
        daytext.text = "개업 ";
        daytext.text += gameManager.day.ToString();
        daytext.text += " 일차";

        // 자산 업데이트
        moneytext.text = gameManager.money.ToString() + " 만 원";

        // 재고 업데이트
        for(int i = 0; i < 7; i++)
        {
            if (gameManager.items[i].avail)
            {
                // 물품 이름 추가
                inventext.text += gameManager.items[i].name;
                // --- 추가
                switch (gameManager.items[i].name)
                {
                    case "물":
                    case "약":
                        inventext.text += " ---------\n";
                        break;
                    case "통조림":
                    case "방독면":
                    case "마스크":
                        inventext.text += "  ----\n";
                        break;
                    case "무기":
                        inventext.text += "  ------\n";
                        break;
                    case "독도삼다수":
                        inventext.text += "  -\n";
                        break;
                }

                // 물품 개수
                invenNumtext.text += gameManager.items[i].num.ToString();
                invenNumtext.text += " 개\n";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
