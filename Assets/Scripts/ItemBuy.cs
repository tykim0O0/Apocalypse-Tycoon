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

    string dealerText = "오늘은 물건이 이 정도 있어. 뭘 살 거야?";

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        buyCanvas.gameObject.SetActive(false);
    }

    public void BuyItems()
    {
        buyCanvas.gameObject.SetActive(true);

        // 딜러 텍스트 띄우기
        gameManager.eventText.text = dealerText;

        // 판매 물건들 띄우기 (buyCanvas에)

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
