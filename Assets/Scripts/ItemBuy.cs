using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class ItemBuy : MonoBehaviour
{
    public GameManager gameManager;
    //public Panel buyPanel; // 보호 수준 때문에 Panel은 public 불가능
    public Canvas buyCanvas;
    public TMP_Text[] itemtexts = new TMP_Text[6];
    public TMP_InputField[] iteminputs = new TMP_InputField[6];

    public bool flag = false; // 물품을 무언가 샀는지
    string dealerText = "오늘은 물건이 이 정도 있어.\n좀 사 갈래?";
    bool[] itemBuyornot;
    int[] dealerItemNum;

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        buyCanvas.gameObject.SetActive(false);
        itemBuyornot = new bool[7];
        dealerItemNum = new int[7];
        for (int i = 0; i < 7; i++)
            dealerItemNum[i] = 0;
        foreach (var itemtext in itemtexts) // c#의 foreach var in
            itemtext.gameObject.SetActive(false);
        foreach (var iteminput in iteminputs)
            iteminput.gameObject.SetActive(false);
        BuyItems();
    }

    void ShowBuying()
    {
        // 딜러 텍스트 띄우기
        gameManager.eventText.text = dealerText;

        // 판매 물건들 띄우기 (buyCanvas에)
        int newItemTotalNum = 0;
        for (int i = 0; i < gameManager.items.Length; i++)
        {
            if (newItemTotalNum == 6) break; // 6개까지만 판매
            if (Random.value < gameManager.items[i].proba)
            {
                //itemBuyornot[i] = true; // 아이템 거래됨..? 얠 써야돼 말아야돼
                itemtexts[newItemTotalNum].gameObject.SetActive(true);
                iteminputs[newItemTotalNum].gameObject.SetActive(true);

                // 오브젝트 위치 조정
                int y_pos = -40 - (newItemTotalNum * 70);

                // UI는 RectTransform 기반의 로컬 좌표 anchoredPosition 사용
                itemtexts[newItemTotalNum].rectTransform.anchoredPosition = new Vector2(0, y_pos);
                iteminputs[newItemTotalNum].GetComponent<RectTransform>().anchoredPosition = new Vector2(140, y_pos);


                // 물품 이름 -> TMP_Text.text
                string newItemString = "";
                switch (gameManager.items[i].name)
                {
                    case "물":
                        newItemString = "물  --------------------      / ";
                        break;
                    case "통조림":
                        newItemString = "통조림  ----------------      / ";
                        break;
                    case "마스크":
                        newItemString = "마스크  ----------------      / ";
                        break;
                    case "방독면":
                        newItemString = "방독면  ----------------      / ";
                        break;
                    case "독도삼다수":
                        newItemString = "독도삼다수  -------------      / ";
                        break;
                    case "약":
                        newItemString = "약  --------------------      / ";
                        break;
                    case "무기":
                        newItemString = "무기  ------------------      / ";
                        break;
                }
                itemtexts[newItemTotalNum].text = newItemString;

                // 물품 개수 -> TMP_Text.text
                int newItemNum = 0; // 판매 물품 개수
                if (gameManager.items[i].name == "물" || gameManager.items[i].name == "통조림"
                    || gameManager.items[i].name == "마스크")
                    newItemNum = Random.Range(1, 10); // 1 이상 10 미만
                else
                    newItemNum = Random.Range(1, 4);
                itemtexts[newItemTotalNum].text += newItemNum.ToString() + " 개";

                newItemTotalNum++;
            }
        }
    }

    public void BuyItems()
    {
        buyCanvas.gameObject.SetActive(true);

        ShowBuying(); // 텍스트 띄우기
    }

    public void InputBuy()
    {
        int paymoney = 0;
        for (int i = 0; i < 6; i++)
        {
            int num = int.Parse(iteminputs[i].text); // string -> int
            int sellNum = iteminputs[i].text[-3] - '0'; // char -> int
            if (num > 0 && num <= sellNum)
                // InputField용 스크립트를 만들어서 Check 함수 -> End 이벤트로 넣어야 하나
            {
                flag = true; // 무언갈 샀음 -> 멘트 조절하려고
                for(int j=0;j<7;j++)
                {
                    if (itemtexts[j].text.Contains(gameManager.items[j].name))
                    {
                        gameManager.items[j].tmpNum = num;
                        gameManager.items[j].tmpCheck = true;
                        paymoney += gameManager.items[j].price * num;
                        break; // 매치되는 물건 찾았으니까 탐색 종료
                    }
                }
            }
        }
        if (paymoney > gameManager.money) {
            UpdateDealerText("너 돈이 부족하잖아,\n난 할인은 못 해 줘.");

        }
        //else

    }

    void UpdateDealerText(string str)
    {
        gameManager.eventText.text = str;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
