using UnityEngine;
using BCrypt.Net;

public class DatabaseManager : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        string pass1 = "quicktest";
        string passhash = BCrypt.Net.BCrypt.EnhancedHashPassword(pass1, 12);
        Debug.Log(passhash);
        Debug.Log(BCrypt.Net.BCrypt.EnhancedVerify("quicktest", passhash));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
