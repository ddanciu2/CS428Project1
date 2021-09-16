using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EightBallScript : MonoBehaviour
{

    private int PickRandomNumber(){
        int randomNum = Random.Range(1,4);
        return randomNum;
    }

    public GameObject Magic8Text;
    public Transform CubePositionDetection;

    bool upsideDownFlag = false;
    int randomNum;
    int randomSayingIndex;
    string assignText;

    string[] eightBallPositive = new string[5] {"100% Yes", "Yesss", "Let's Go! Yes!", "No Doubt, answer = yes", "Looking like a yes"};
    
    string[] eightBallNeutral = new string[3] {"I don't know chief", "No idea", "Repeat the question"};
    string[] eightBallNegative = new string[4] {"Fat L, answer = no", "Bruh, no way", "No Shot","Sorry fam, but no"};

    WaitForSeconds waitTime = new WaitForSeconds(5);

    // Start is called before the first frame update
    void Start()
    {
       InvokeRepeating("UpdateEightBall", 2f, 0.5f);
    }


    void UpdateEightBall()
    {
         float x = CubePositionDetection.eulerAngles.x;
        float y = CubePositionDetection.eulerAngles.y;
        float z = CubePositionDetection.eulerAngles.z;
        

        Debug.Log("x,y,z: " + x + " " + y + " " + z);


        if(y > 140 && y < 220){
            randomNum = PickRandomNumber();
            upsideDownFlag = true;
            Debug.Log("Test3");
        }

        if(y < 80 || y > 330){
            Debug.Log("Test4");

            if(upsideDownFlag == true){
                Debug.Log("Test5");

                upsideDownFlag = false;
                if(randomNum == 1){
                    int randomSayingIndex = Random.Range(0,eightBallPositive.Length-1);
                    assignText = eightBallPositive[randomSayingIndex];
                }
                else if(randomNum == 2){
                    int randomSayingIndex = Random.Range(0,eightBallNeutral.Length-1);
                    assignText = eightBallNeutral[randomSayingIndex];                }
                else if(randomNum == 3){
                    int randomSayingIndex = Random.Range(0,eightBallNegative.Length-1);
                    assignText = eightBallNegative[randomSayingIndex];
                }
                Debug.Log("New Text: " + assignText);

                Magic8Text.GetComponent<TextMeshPro>().text = assignText;
            }
        }

    }
}
