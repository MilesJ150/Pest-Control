using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOverTime : MonoBehaviour {
    public Text finalTime;
    // Use this for initialization
    void Start () {
		finalTime = GetComponent<Text>() as Text;
        finalTime = GameObject.FindGameObjectWithTag("player").GetComponent<CharacterInputControllerTest>().gameEndedTime;
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
