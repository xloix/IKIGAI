using System;
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

    void Start() {
        if (String.IsNullOrEmpty(username))
            Destroy(this.gameObject);
    }

    void SelectThisProfile() {
        IndexFunctionality.instance.GuestProfileSelect(username);
    }
}