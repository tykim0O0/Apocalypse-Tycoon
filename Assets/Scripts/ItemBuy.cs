using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemBuy : MonoBehaviour
{
    GameManager gameManager;
    //public Panel buyPanel; // 보호 수준 때문에 Panel은 public 불가능
    public Canvas buyCanvas;

    string dealerText = "오늘은 물건이 이 정도 있어.\n뭘 살 거야?";
    bool[] itemBuyornot;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        buyCanvas.gameObject.SetActive(false);
        itemBuyornot = new bool[7];
    }

    public void BuyItems()
    {
        buyCanvas.gameObject.SetActive(true);

        // 딜러 텍스트 띄우기
        gameManager.eventText.text = dealerText;

        // 판매 물건들 띄우기 (buyCanvas에)
        int newItemTotalNum = 0;
        for (int i = 0; i < gameManager.items.Length; i++)
        {
            if (Random.value < gameManager.items[i].proba)
            {
                // 물품 판매 O
                newItemTotalNum++;

                // 동적 UI 생성 - TMP_Text
                GameObject textObj = new GameObject("ItemText");
                textObj.transform.SetParent(buyCanvas.transform); // buyCanvas에 붙임


                TextMeshProUGUI tmpText = textObj.AddComponent<TextMeshProUGUI>(); // 생성한 오브젝트에 컴포넌트 부착
                tmpText.text = gameManager.items[i].name; // 판매 물품 이름
                tmpText.text += "\t";

                int newItemNum = 0; // 판매 물품 개수
                // if 문을 쓰는 게 나았을지도
                switch (gameManager.items[i].name)
                {
                    case "물":
                    case "통조림":
                    case "마스크":
                        newItemNum = Random.Range(1, 10); // 1 이상 10 미만
                        break;
                    case "방독면":
                    case "정화된 물":
                    case "약":
                    case "무기":
                        newItemNum = Random.Range(1, 4);
                        break;
                }
                tmpText.text += newItemNum.ToString() + " 개";
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
