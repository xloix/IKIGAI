using UnityEngine;

// used for events based on what happens in the exploration scene ONLY
public class InputAnswerEvent : IGameEvent {
    public string answer;
    public InputAnswerEvent (string a) {
        this.answer = a;
    }
}