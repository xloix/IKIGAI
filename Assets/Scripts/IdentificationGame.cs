<<<<<<< Updated upstream
using UnityEngine;

public class IdentificationGame : MonoBehaviour {
=======
using System.Collections.Generic;
using UnityEngine;

public class IdentificationGame : MonoBehaviour {

    private Dictionary<string,Sprite> answers;
    string curAnswer;
>>>>>>> Stashed changes
    int questionInd;
    void Start() {
        InitializeGame();
    }

    void OnEnable() {
        EventBus.Subscribe<InputAnswerEvent>(AttemptAnswer);
    }

    void OnDisable() {
        EventBus.Unsubscribe<InputAnswerEvent>(AttemptAnswer);
        
    }

    void InitializeGame() {
        //get dictionary database, convert to data
<<<<<<< Updated upstream
=======
        questionInd = 0;
        // get right answer, place within the area
        // get random answer that's not 
>>>>>>> Stashed changes
        
    }

    void AttemptAnswer (InputAnswerEvent iae) {
<<<<<<< Updated upstream
        Debug.Log("blehhh");
=======
        if (iae.answer.ToLower() != curAnswer.ToLower()) {
            Debug.Log("blehhh wrong answer");
        } else {
            Debug.Log("yippieee right answer!!@!");
        }
>>>>>>> Stashed changes
        //check if iae is the correct answer of this round
    }
}
