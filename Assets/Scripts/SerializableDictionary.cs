using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SerializableDictionary
{
    [HideInInspector]
    public string Key;
    public string Value;   

    public SerializableDictionary(string key, string value=null){
        Key = key;
        Value = value;
    }

    public string GetKey(){
        return Key;
    }

    public string GetValue(){
        return Value;
    }

    public void SetValue(string value){
        Value = value;
    }
}
