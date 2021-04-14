using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class LoveSimulation : MonoBehaviour
{
    private string characterName; // 이름
    private char bloodType; // 혈액형
    private int age; //나이
    private float height; //키
    private bool isFemalale; // 성별
    private int loveNum; // 호감도 
    private int thNumber; // 회차
    private bool isMarriage; //결혼 여부 

    private void Awake()
    {
        characterName = "라라";
        bloodType = 'A';
        age = 17;
        height = 168.3f;
        isFemalale = true;
        loveNum = 60;
        thNumber = 0;
        isMarriage = false;
    }
    // Start is called before the first frame update
    void Start()
    {
        Personal_Information(); // 인적 사항
        Simulation(); // 결혼 까지 시뮬레이션 후 종료.
        Simulation(); // 결혼을 한 이후 시뮬레이션을 돌릴 경우.
    }

    //인적 사항
    private void Personal_Information()
    {
        Debug.Log("캐릭터 이름 : " + characterName);
        Debug.Log("혈액형 : " + bloodType);
        Debug.Log("나이 : " + age);
        Debug.Log("키 : " + height);
        if (isFemalale)
        {
            Debug.Log("성별 : 여성");
        }
        else
        {
            Debug.Log("성별 : 남성");
        }
        Debug.Log("호감도 : " + loveNum);
    }

    //시뮬레이션 
    private void Simulation()
    {
        while (true)
        {
            loveNum++; // 1회 반복 마다 호감도 1씩 증가 
            if (70 > loveNum) // 호감도가 70 미만 일 시 
            {
                Debug.Log(++thNumber + "회차 플레이어가 라라와 썸을 타기 시작 합니다!" );

                Debug.Log("라라에게 차였습니다!");

            }
            if (90 > loveNum && 70 <= loveNum) // 호감도가 70 이상 90 미만 일시 
            {
                Debug.Log(++thNumber + "회차 플레이어가 라라와 썸을 타기 시작 합니다!" );
                Debug.Log("라라와 데이트를 성공 했습니다~");
            }
            if (90 <= loveNum) // 호감도가 90 이상일 시 
            {
                if (!isMarriage) // 결혼을 하지 않았을 경우
                {
                    Debug.Log(++thNumber + "회차 플레이어가 라라와 썸을 타기 시작 합니다!");
                    Debug.Log("라라와 결혼 하였습니다!");
                    isMarriage = true;
                    break;
                }
                else // 결혼을 했을 경우 
                {
                    Debug.Log(++thNumber + "회차 플레이어는 이미 라라와 결혼을 하였습니다.");
                    break;
                }
            }

        }
    }

}
