using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGameButton : MonoBehaviour
{
    public GameObject errorPanel;
    public InputField fNameField, lNameField;


    public void StartGame()
    {
        // CHECK TO MAKE SURE ALL DATA IS INPUT
        if (fNameField.text == "")                                                     // No first name
        {
            DisplayError("Please enter first name.");
            return;
        }
        if (lNameField.text == "")                                                     // No last name
        {
            DisplayError("Please enter last name.");
            return;
        }

        // Find Player
        PlayerData pd = FindObjectOfType<Player>().data;
        pd.fName = fNameField.text;


        // Load Scene
        SceneManager.LoadScene(2);
    }

    /// <summary>
    /// Method to display error using specified string.
    /// </summary>
    /// <param name="s">the message to display</param>
    private void DisplayError(string s)
    {
        errorPanel.SetActive(true);
        Animator a = errorPanel.GetComponent<Animator>();
        errorPanel.GetComponentInChildren<Text>().text = s;
        StartCoroutine(errorPause(a));
    }
    /// <summary>
    /// Coroutine for error message display timing
    /// </summary>
    /// <param name="a">error panel animator</param>
    /// <returns></returns>
    IEnumerator errorPause(Animator a)
    {
        a.SetBool("IsOpen", true);
        yield return new WaitForSeconds(2);
        a.SetBool("IsOpen", false);
        yield return new WaitForSeconds(a.GetCurrentAnimatorStateInfo(0).length + a.GetCurrentAnimatorClipInfo(0).Length);
        a.gameObject.SetActive(false);
    }
}
