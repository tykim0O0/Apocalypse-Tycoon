using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    TutorialManager tutorialManager;
    ItemBuy itemBuy;
    ButtonTextColor buttonTextColor;
    BoardManager boardManager;

    public Canvas panelCanvas;
    public TMP_Text eventText;

    //bool isFirst = false; // 프롤로그 실행 여부

    public struct Item // 아이템 관리 구조체
    {
        public bool avail;
        public string name;
        public int id, num, price;
        public float proba; // 아이템 확률

        public bool tmpCheck;
        public int tmpNum;
    }

    public Item[] items; // 데이터 타입부터 public 해줘야 하는군

    // 물품 초기 정보
    string[] itemName = { "물", "독도삼다수", "통조림", "방독면", "마스크", "약", "무기" };
    int[] itemPrice = { 25, 50, 30, 100, 10, 200, 1000 };
    bool[] itemAvail = { true, false, true, true, false, true, true };
    float[] itemProba = { 0.8f, 0.0f, 0.8f, 0.2f, 0.0f, 0.1f, 0.1f };

    public int day; // 게임 날짜
    public int money; // 플레이어 자금

    // Start is called before the first frame update
    void Start()
    {
        // GetComponent: 해당 오브젝트에 붙어 있는 TutorialManager 컴포넌트를 가져 옴
        tutorialManager = GetComponent<TutorialManager>();
        itemBuy = GetComponent<ItemBuy>();
        buttonTextColor = GetComponent<ButtonTextColor>();
        boardManager = GetComponent<BoardManager>();

        tutorialManager.StartTutorial();

        items = new Item[7];
        // 물품 초기 정보
        for(int i = 0; i < 7; i++)
        {
            items[i] = new Item();
            items[i].id = i;
            items[i].num = 0;
            items[i].price = itemPrice[i];
            items[i].name = itemName[i];
            items[i].avail = itemAvail[i];
            items[i].proba = itemProba[i];

            items[i].tmpCheck = false;
            items[i].tmpNum = 0;
        }
        day = 0; money = 200;
    }

    public void GameEvent() // 게임 이벤트 관리 메소드
    {
        ++day; // 하루 증가
        boardManager.UpdateBoard();

        // 유통업자 거래 - 하루 시작할 때 무조건 거침
        itemBuy.BuyItems();

        // 사건 확률에 따라 해당 사건 발생 - 하루에 4개 사건
        //// 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
