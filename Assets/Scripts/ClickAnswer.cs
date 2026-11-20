using UnityEngine;
using UnityEngine.UI;

public class ClickAnswer : MonoBehaviour {
    private Button button;
    [SerializeField] private string answer;

    void Start() {
        button = GetComponent<Button>();
    }

    void OnEnable() {
        button = GetComponent<Button>();
        button.onClick.AddListener(AnswerItem);
    }

    void OnDisable() {
        button.onClick.RemoveAllListeners();
    }
    void AnswerItem() {
        // check if not its good to answer rn
        Debug.Log("you answered " + answer);
        EventBus.Publish(new InputAnswerEvent(answer));
    }
}