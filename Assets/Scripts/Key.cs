using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

/*
 * Matthew Borinsky 251093967
 * Key class attached to each textbox. This allows the scriptable objects to have key values on creation.
 * It is also where the textboxes will check if the language has to change and updates accordingly.
 */

public class Key : MonoBehaviour
{
    public string key;  // This text elements key
    public CurrentLanguageSO currentLanguage;  // The current language which holds this textboxes value

    // Checks to see if the language should be changed
    void FixedUpdate(){
        gameObject.GetComponent<TextMeshProUGUI>().text = currentLanguage.GetLanguage().GetValue(key);
    }

    // Changes the language if this is attached to a button
    public void LanguageChange(ScriptableLanguage newLanguage){
        currentLanguage.SetLanguage(newLanguage);
    }
}

