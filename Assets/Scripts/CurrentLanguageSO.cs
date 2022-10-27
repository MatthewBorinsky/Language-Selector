using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentLanguageSO : ScriptableObject
{
    public ScriptableLanguage currentLanguage;

    public ScriptableLanguage GetLanguage(){
        return currentLanguage;
    }

    public void SetLanguage(ScriptableLanguage newLanguage){
        currentLanguage = newLanguage;
    }
}
