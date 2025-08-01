using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class ItemBuy : MonoBehaviour
{
    GameManager gameManager;
    //public Panel buyPanel; // ��ȣ ���� ������ Panel�� public �Ұ���
    public Canvas buyCanvas;

    string dealerText = "������ ������ �� ���� �־�. �� �� �ž�?";

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GetComponent<GameManager>();
        buyCanvas.gameObject.SetActive(false);
    }

    public void BuyItems()
    {
        buyCanvas.gameObject.SetActive(true);

        // ���� �ؽ�Ʈ ����
        gameManager.eventText.text = dealerText;

        // �Ǹ� ���ǵ� ���� (buyCanvas��)

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
