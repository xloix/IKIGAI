// this is the data structure of teachers, staff, and admins of the system
using UnityEngine;

public class User {
    public string username;
    public string email;
    public UserRole role;

    public User(string un, string em) {
        username = un;
        email = em;
    }
}