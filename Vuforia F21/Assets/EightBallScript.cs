using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EightBallScript : MonoBehaviour
{
    //Pick a random number to choose 8ball saying
    private int PickRandomNumber(){
        int randomNum = Random.Range(1,4);
        return randomNum;
    }

    public GameObject Magic8Text; //Text to change
    public Transform CubePositionDetection; //Cube base itself to detect position
    public AudioSource TextChangeSE; //Audio to play when Cube changes text

    bool upsideDownFlag = false; //Flag to signal that cube was flipped
    int randomNum; //Assign random # to choose between pos, neutral, neg
    int randomSayingIndex; //Choose random index in array of sayings
    string assignText; //String to store assigned text

    //List of sayings (custom)
    string[] eightBallPositive = new string[5] {"100% Yes", "Yesss", "Let's Go! Yes!", "No Doubt, answer = yes", "Looking like a yes"};
    
    string[] eightBallNeutral = new string[3] {"I don't know boss", "No idea", "Repeat the question"};
    string[] eightBallNegative = new string[4] {"Fat L, answer = no", "Bruh, no way", "No Shot","Sorry fam, but no"};

    void Start()
    {
       InvokeRepeating("UpdateEightBall", 2f, 0.5f); //Call UpdateEightBall
    }


    void UpdateEightBall()
    {
        //Get z value of base cube
        float z = CubePositionDetection.eulerAngles.z;
        
        //Cube is upside down
        if(z > 130 && z < 220){
            randomNum = PickRandomNumber();
            upsideDownFlag = true;
        }

        //Cube is rightside up
        if(z > 330 || z < 30){
            //Check if cube was flipped first, then change text/play audio
            if(upsideDownFlag == true){
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
                TextChangeSE.Play();
                Magic8Text.GetComponent<TextMeshPro>().text = assignText;
            }
        }
    }
}
