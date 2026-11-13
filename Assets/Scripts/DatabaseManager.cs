using System;
using System.Collections;
using System.Threading.Tasks;
using Firebase;
using Firebase.Auth;
using Firebase.Database;
using UnityEngine;

public class DatabaseManager : MonoBehaviour {
    public static DatabaseManager instance;
    void Awake() {
        if (instance != null & instance != this) Destroy(this.gameObject);
        if (instance == null) instance = this;
    }
    public static FirebaseAuth auth {get; private set;}
    private static DatabaseReference dbReference;
    void Start() {
        auth = FirebaseAuth.DefaultInstance;
        FirebaseDatabase db = FirebaseDatabase.GetInstance(
            FirebaseApp.DefaultInstance,
            "https://ikigai-e33d1-default-rtdb.asia-southeast1.firebasedatabase.app/"
        );
        dbReference = db.RootReference;

    }

    // ==================== USER CREATION =====================

    public static async Task<bool> CreateUser(string em, string un, string pw, string rp) {
        // check for existing users first (emails, usernames)
        // double check for password integrity
        try {
            string lem = UsernameToEmail(un);
            AuthResult result = await auth.CreateUserWithEmailAndPasswordAsync(lem,pw);

            FirebaseUser user = result.User;
            User newUser = new User (un,em);
            string json = JsonUtility.ToJson(newUser);

            await dbReference.Child("users").Child(user.UserId).SetRawJsonValueAsync(json);
            Debug.Log("user has been created!");
            return true;
        } catch (Exception e) {
            Debug.LogError(e.Message);
            return false;
        }
    }

    // ================= GET DATA =============================
    public static async Task<bool> LoginUser (string un, string pw) {
        try {
            string lem = UsernameToEmail(un);

            await auth.SignInWithEmailAndPasswordAsync(lem, pw);
            Debug.Log("signed in successfully!");
            return true;
        } catch (Exception e) {
            Debug.LogError(e.Message);
            return false;
        }
    }

    private static string UsernameToEmail (string username) {
        return username.Trim() + "@sweetbook.ikigai.com";
    }
}
