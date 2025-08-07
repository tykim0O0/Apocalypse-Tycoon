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

    //bool isFirst = false; // ���ѷα� ���� ����

    public struct Item // ������ ���� ����ü
    {
        public bool avail;
        public string name;
        public int id, num, price;
        public float proba; // ������ Ȯ��

        public bool tmpCheck;
        public int tmpNum;
    }

    public Item[] items; // ������ Ÿ�Ժ��� public ����� �ϴ±�

    // ��ǰ �ʱ� ����
    string[] itemName = { "��", "������ټ�", "������", "�浶��", "����ũ", "��", "����" };
    int[] itemPrice = { 25, 50, 30, 100, 10, 200, 1000 };
    bool[] itemAvail = { true, false, true, true, false, true, true };
    float[] itemProba = { 0.8f, 0.0f, 0.8f, 0.2f, 0.0f, 0.1f, 0.1f };

    public int day; // ���� ��¥
    public int money; // �÷��̾� �ڱ�

    // Start is called before the first frame update
    void Start()
    {
        // GetComponent: �ش� ������Ʈ�� �پ� �ִ� TutorialManager ������Ʈ�� ���� ��
        tutorialManager = GetComponent<TutorialManager>();
        itemBuy = GetComponent<ItemBuy>();
        buttonTextColor = GetComponent<ButtonTextColor>();
        boardManager = GetComponent<BoardManager>();

        tutorialManager.StartTutorial();

        items = new Item[7];
        // ��ǰ �ʱ� ����
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

    public void GameEvent() // ���� �̺�Ʈ ���� �޼ҵ�
    {
        ++day; // �Ϸ� ����
        boardManager.UpdateBoard();

        // ������� �ŷ� - �Ϸ� ������ �� ������ ��ħ
        itemBuy.BuyItems();

        // ��� Ȯ���� ���� �ش� ��� �߻� - �Ϸ翡 4�� ���
        //// 
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
