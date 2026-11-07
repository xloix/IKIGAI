using UnityEngine;
using UnityEngine.UI;

public class GuestButton : MonoBehaviour {
    void OnEnable() {
        GetComponent<Button>().onClick.AddListener(SelectThisProfile);
    }

    void OnDisable() {
        GetComponent<Button>().onClick.RemoveListener(SelectThisProfile);
    }

    public string username;

    void SelectThisProfile() {
        IndexFunctionality.instance.GuestProfileSelect(username);
    }
}