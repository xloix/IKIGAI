using UnityEngine;
using UnityEngine.SceneManagement;

public class HomeFunctionality : MonoBehaviour
{
    public void SignOut() {
        //will issue a popup beforehand,,, in the future
        SceneManager.LoadScene(1);
    }
}
