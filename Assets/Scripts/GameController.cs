using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Player player;

    public InputField textEntryField;
    public Text historyText;
    public Text currentText;

    [TextArea]
    public string introText;

    void Start()
    {
        historyText.text = introText;
        DisplayLocation();
        textEntryField.ActivateInputField();
    }

    void Update()
    {
        
    }

    public void DisplayLocation()
    {
        string description = player.currentLocation.desciption + "\n";
        description += player.currentLocation.GetConnectionsText();
        currentText.text = description;
    }

    public void TextEntered()
    {
        LogCurrentText();
        ProcessInput(textEntryField.text);
        textEntryField.text = "";
        textEntryField.ActivateInputField();
    }

    void LogCurrentText()
    {
        historyText.text += "\n\n";
        historyText.text += currentText.text;

        historyText.text += "\n\n";
        historyText.text += "<color=#42FF46>" + textEntryField.text + "</color>";
    }

    void ProcessInput(string input)
    {
        input = input.ToLower();
        char[] delimiter = {' '};
        string[] separateWords = input.Split(delimiter);

        //todo process the commands (separateWords)

        currentText.text = "Nothing happens! (having trouble? type Help)";
    }
}
