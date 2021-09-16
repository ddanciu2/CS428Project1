using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EightBallScriptOriginal : MonoBehaviour
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

    string[] eightBallPositive = new string[10] {"It is Certain", "It is decidedly so", "Without a doubt", "Yes definitely", "You may rely on it", "As I see it, yes.", "Most likely", "Outlook good", "Yes", "Signs point to yes"};

    string[] eightBallNeutral = new string[5] {"Reply hazy, try again", "Ask again later", "Better not tell you now", "Cannot predict now", "Concentrate and ask again"};
    string[] eightBallNegative = new string[5] {"Don't count on it", "My reply is no", "My sources say no", "Outlook not so good", "Very doubtful"};

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
