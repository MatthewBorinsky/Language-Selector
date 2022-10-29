using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Matthew Borinsky 251093967
 * Serializable dictionary class to hold the key value pairs
 */

[System.Serializable]
public class SerializableDictionary
{
    [HideInInspector]
    public string Key;
    public string Value;   

    // Constructor to create the element
    public SerializableDictionary(string key, string value=null){
        Key = key;
        Value = value;
    }

    // Getter to get the key
    public string GetKey(){
        return Key;
    }

    // Getter to get the value
    public string GetValue(){
        return Value;
    }

    // Setter to set the value
    public void SetValue(string value){
        Value = value;
    }
}
