using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Display : MonoBehaviour
{
     //public GameObject mailUIPrefab;
      public TMP_Text displayText;
      public TMP_InputField inputField;
       public LeaderboardManager leaderboardManager;
      
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
 

   

    // public void UpdateText(string newName)
    // {
    //     newName=inputField.text; 
    //     displayText.text = newName;

    // }
    
public void addEntry()
{
    string name=inputField.text;
    string laptime=displayText.text;
    leaderboardManager.AddEntry(name,laptime);
    inputField.text = "";
    displayText.text = "";
}
    
}
