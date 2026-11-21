using System;
using System.Collections;
using System.Collections.Generic;
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

    // ================= USER LOGIN =============================
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

    // ================ GET DATA ===============================
    public static async Task<User> GetUserData () {
        try {
            FirebaseUser user = auth.CurrentUser;
            if (user == null) {
                Debug.LogError("User is not logged in");
                return null;
            }

            DataSnapshot snapshot = await dbReference.Child("users").Child(user.UserId).GetValueAsync();

            if (snapshot.Exists) {
                User userData = JsonUtility.FromJson<User>(snapshot.GetRawJsonValue());

                Debug.Log("data has been got!");
                Debug.Log("Username: " + userData.username);
                Debug.Log("Email: " + userData.email);
                return userData;
            }
            return null;
        } catch (Exception e) {
            Debug.LogError(e.Message);
            return null;
        }
    }
    
    public static async Task<Classroom[]> GetUserClasses () {
        try {
            FirebaseUser user = auth.CurrentUser;
            if (user == null) {
                Debug.LogError("User is not logged in");
                return null;
            }

            Query que = dbReference.Child("classrooms").OrderByChild("userId").EqualTo(user.UserId);

            DataSnapshot snapshot = await que.GetValueAsync();

            if (snapshot.Exists) {
                List<Classroom> tempC = new List<Classroom>();
                foreach (DataSnapshot cr in snapshot.Children) {
                    tempC.Add(JsonUtility.FromJson<Classroom>(snapshot.GetRawJsonValue()));
                }
                return tempC.ToArray();
            }
            return null;
        } catch (Exception e) {
            Debug.LogError(e.Message);
            return null;
        }
    }
    public static async Task<Subject[]> GetClassSubjects (string cid) {
        try {
            FirebaseUser user = auth.CurrentUser;
            if (user == null) {
                Debug.LogError("User is not logged in");
                return null;
            }

            Query que = dbReference.Child("subjects").OrderByChild("classId").EqualTo(cid);

            DataSnapshot snapshot = await que.GetValueAsync();

            if (snapshot.Exists) {
                List<Subject> tempS = new List<Subject>();
                foreach (DataSnapshot cr in snapshot.Children) {
                    tempS.Add(JsonUtility.FromJson<Subject>(snapshot.GetRawJsonValue()));
                }
                return tempS.ToArray();
            }
            return null;
        } catch (Exception e) {
            Debug.LogError(e.Message);
            return null;
        }
    }
    public static async Task<Lesson[]> GetLessons (string sid) {
        try {
            FirebaseUser user = auth.CurrentUser;
            if (user == null) {
                Debug.LogError("User is not logged in");
                return null;
            }

            Query que = dbReference.Child("lessons").OrderByChild("subjectId").EqualTo(sid);

            DataSnapshot snapshot = await que.GetValueAsync();

            if (snapshot.Exists) {
                List<Lesson> tempS = new List<Lesson>();
                foreach (DataSnapshot cr in snapshot.Children) {
                    tempS.Add(JsonUtility.FromJson<Lesson>(snapshot.GetRawJsonValue()));
                }
                return tempS.ToArray();
            }
            return null;
        } catch (Exception e) {
            Debug.LogError(e.Message);
            return null;
        }
    }
    public static async Task<Question[]> GetQuestions (string aid) {
        try {
            FirebaseUser user = auth.CurrentUser;
            if (user == null) {
                Debug.LogError("User is not logged in");
                return null;
            }

            Query que = dbReference.Child("questions").OrderByChild("activityId").EqualTo(aid);

            DataSnapshot snapshot = await que.GetValueAsync();

            if (snapshot.Exists) {
                List<Question> tempS = new List<Question>();
                foreach (DataSnapshot cr in snapshot.Children) {
                    tempS.Add(JsonUtility.FromJson<Question>(snapshot.GetRawJsonValue()));
                }
                return tempS.ToArray();
            }
            return null;
        } catch (Exception e) {
            Debug.LogError(e.Message);
            return null;
        }
    }
    public static async Task<Activity[]> GetActivities (string sid) {
        try {
            FirebaseUser user = auth.CurrentUser;
            if (user == null) {
                Debug.LogError("User is not logged in");
                return null;
            }

            Query que = dbReference.Child("activities").OrderByChild("subjectId").EqualTo(sid);

            DataSnapshot snapshot = await que.GetValueAsync();

            if (snapshot.Exists) {
                List<Activity> tempS = new List<Activity>();
                foreach (DataSnapshot cr in snapshot.Children) {
                    tempS.Add(JsonUtility.FromJson<Activity>(snapshot.GetRawJsonValue()));
                }
                return tempS.ToArray();
            }
            return null;
        } catch (Exception e) {
            Debug.LogError(e.Message);
            return null;
        }
    }
    public static async Task<Learner[]> GetLearners (string cid) {
        try {
            FirebaseUser user = auth.CurrentUser;
            if (user == null) {
                Debug.LogError("User is not logged in");
                return null;
            }

            Query que = dbReference.Child("learners").OrderByChild("classId").EqualTo(cid);

            DataSnapshot snapshot = await que.GetValueAsync();

            if (snapshot.Exists) {
                List<Learner> tempS = new List<Learner>();
                foreach (DataSnapshot cr in snapshot.Children) {
                    tempS.Add(JsonUtility.FromJson<Learner>(snapshot.GetRawJsonValue()));
                }
                return tempS.ToArray();
            }
            return null;
        } catch (Exception e) {
            Debug.LogError(e.Message);
            return null;
        }
    }


    // ============================= SET DATA ======================================
    
    public static async Task<bool> CreateClassroom() {
        // creates an empty classroom with default everything
        try {
            FirebaseUser user = auth.CurrentUser;
            if (user == null) {
                Debug.LogError("User is not logged in");
                return false;
            }

            Classroom newClass = new Classroom (user.UserId, "New Class");
            string json = JsonUtility.ToJson(newClass);

            await dbReference.Child("classrooms").Child(user.UserId).SetRawJsonValueAsync(json);
            Debug.Log("classroom has been created!");
            return true;
        } catch (Exception e) {
            Debug.LogError(e.Message);
            return false;
        }
    }
    public static async Task<bool> CreateSubject () {
        // creates an empty classroom with default everything
        try {
            FirebaseUser user = auth.CurrentUser;
            if (user == null) {
                Debug.LogError("User is not logged in");
                return false;
            }

            Subject newSubject = new Subject (user.UserId, "New Subject");
            string json = JsonUtility.ToJson(newSubject);

            await dbReference.Child("subjects").Child(user.UserId).SetRawJsonValueAsync(json);
            Debug.Log("subject has been created!");
            return true;
        } catch (Exception e) {
            Debug.LogError(e.Message);
            return false;
        }
    }
}
