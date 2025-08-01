using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    TutorialManager tutorialManager;

    public Canvas panelCanvas;

    //bool isFirst = false; // 게임 데이터 저장..
    bool[] itemAvail; // 아이템 해금 여부 불리언 배열

    // Start is called before the first frame update
    void Start()
    {
        // GetComponent: 해당 오브젝트에 붙어 있는 TutorialManager 컴포넌트를 가져 옴
        tutorialManager = GetComponent<TutorialManager>();
        tutorialManager.StartTutorial();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
