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

    public AudioSource TextChangeSE;

    bool upsideDownFlag = false;
    int randomNum;
    int randomSayingIndex;
    string assignText;

    string[] eightBallPositive = new string[5] {"100% Yes", "Yesss", "Let's Go! Yes!", "No Doubt, answer = yes", "Looking like a yes"};
    
    string[] eightBallNeutral = new string[3] {"I don't know boss", "No idea", "Repeat the question"};
    string[] eightBallNegative = new string[4] {"Fat L, answer = no", "Bruh, no way", "No Shot","Sorry fam, but no"};

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
        
        // Debug.Log("z: " + z);


        // if(y > 140 && y < 220 || z > 130 && z < 220){
        if(z > 130 && z < 220){
            randomNum = PickRandomNumber();
            upsideDownFlag = true;
            Debug.Log("AZ Flipped");
        }

        // if(y < 80 || y > 330 || z > 330 || z < 30){
        if(z > 330 || z < 30){
            Debug.Log("AZ Upright");

            if(upsideDownFlag == true){
                Debug.Log("AZ CHANGE TEXT");

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
                TextChangeSE.Play();
                Magic8Text.GetComponent<TextMeshPro>().text = assignText;
            }
        }

    }
}
