using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Key : MonoBehaviour
{
    public string key;
    public CurrentLanguageSO currentLanguage;

    void FixedUpdate(){
        // Debug.Log(currentLanguage.GetValue(key));
        gameObject.GetComponent<TextMeshProUGUI>().text = currentLanguage.GetLanguage().GetValue(key);
    }

    public void LanguageChange(ScriptableLanguage newLanguage){
        currentLanguage.SetLanguage(newLanguage);
    }
}

