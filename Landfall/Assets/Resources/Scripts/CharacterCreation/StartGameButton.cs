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
        }

        // Find Player
        PlayerData pd = FindObjectOfType<Player>().data;
        pd.fName = fNameField.text;


        // Load Scene
        SceneManager.LoadScene(2);
    }


    private void DisplayError(string s)
    {
        errorPanel.SetActive(true);
    }

    IEnumerator errorPause(Animator a)
    {
        yield return new WaitForSeconds(2);
    }
}
