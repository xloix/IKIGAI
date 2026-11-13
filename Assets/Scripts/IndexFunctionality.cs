using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class IndexFunctionality : MonoBehaviour
{
    public static IndexFunctionality instance;
    void Awake() {
        if (instance != null && instance != this) Destroy(this.gameObject);
        if (instance == null) instance = this;
    }
    [Header("Panels")]
    public GameObject login;
    public GameObject register,guests;
    [Header("Log In")]
    public InputField l_userField;
    public InputField l_passField;

    [Header("Register")]
    public InputField r_emailField;
    public InputField r_userField, r_passField, r_repassField;
    [Header("Guests")]
    public GameObject g_buttonPrefab;
    public Transform g_profileParent;

    // =============================== PRIVATE VARIABLES ================================
    private string g_selectedGuest;
    // ================================= FUNCTIONS =======================================

    void Start() {
        InitializeProfiles();
    }

    // for creating GuestProfile buttons on startup
    // also, set login page as starting panel first
    void InitializeProfiles() {
        login.SetActive(true);
        register.SetActive(false);
        guests.SetActive(false);

        // create guestbuttons based on how many offline profiles are in database
        // then create "add guest" button at the end
    }

    //called when the player selects a guest profile
    public void GuestProfileSelect(string uname) {
        g_selectedGuest = (g_selectedGuest == uname) ? "" : uname;
        Debug.Log(g_selectedGuest + " selected");
    }

    //called when the player logs in through offline guest profile
    public void AttemptGuestLogIn() {
        Debug.Log("attempting to log in via guest");
        if (String.IsNullOrEmpty(g_selectedGuest)) {
            Debug.LogWarning("oops, no guest profile selected.");
        } else {
            SceneManager.LoadScene(2);
        }
    }
    //called when the player logs in through the log in panel
    public async void AttemptLogIn() {
        Debug.Log("attempting to log in");
        bool inputsFilled = !String.IsNullOrEmpty(l_userField.text) && !String.IsNullOrEmpty(l_passField.text);
        if (inputsFilled) {
            bool userCreated = await DatabaseManager.LoginUser(r_userField.text, r_passField.text);
            // SceneManager.LoadScene(2);
        } else {
            Debug.LogWarning("oops, inputs aren't completely filled yet.");
        }
    }

    public async void AttemptRegister() {
        Debug.Log("attempting to register");
        bool inputsFilled = !String.IsNullOrEmpty(r_userField.text)
        && !String.IsNullOrEmpty(r_passField.text)
        && !String.IsNullOrEmpty(r_emailField.text)
        && !String.IsNullOrEmpty(r_repassField.text);
        if (inputsFilled) {
            bool userCreated = await DatabaseManager.CreateUser(r_emailField.text, r_userField.text, r_passField.text, r_repassField.text);
            // SceneManager.LoadScene(2);
        } else {
            Debug.LogWarning("oops, inputs aren't completely filled yet.");
        }
    }
}
