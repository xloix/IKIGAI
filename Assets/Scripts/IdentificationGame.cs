using UnityEngine;

public class IdentificationGame : MonoBehaviour {
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
        
    }

    void AttemptAnswer (InputAnswerEvent iae) {
        Debug.Log("blehhh");
        //check if iae is the correct answer of this round
    }
}
