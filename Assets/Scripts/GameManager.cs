using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    TutorialManager tutorialManager;

    public Canvas panelCanvas;

    //bool isFirst = false; // ���� ������ ����..
    bool[] itemAvail; // ������ �ر� ���� �Ҹ��� �迭

    // Start is called before the first frame update
    void Start()
    {
        // GetComponent: �ش� ������Ʈ�� �پ� �ִ� TutorialManager ������Ʈ�� ���� ��
        tutorialManager = GetComponent<TutorialManager>();
        tutorialManager.StartTutorial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
