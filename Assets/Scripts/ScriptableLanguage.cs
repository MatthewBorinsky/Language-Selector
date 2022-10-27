using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Language", menuName = "Language")]
public class ScriptableLanguage : ScriptableObject {
    [NonReorderable]
    public List<SerializableDictionary> language = new List<SerializableDictionary>();
    private bool isCreated = false;

    void OnEnable(){
        if (!isCreated){
            Key[] allKeys = FindObjectsOfType(typeof(Key)) as Key[];

            foreach(Key key in allKeys){
                language.Add(new SerializableDictionary(key.key));
            }
            isCreated = true;
        }

    }

    public string GetValue(string key){
        foreach(SerializableDictionary element in language){
            if (element.GetKey() == key){
                return element.GetValue();
            }
        }
        return "ERROR COULD NOT FIND KEY";
    }

    public void AddElement(string key, string value){
        if (value == null){
            language.Add(new SerializableDictionary(key));
        }else{
            language.Add(new SerializableDictionary(key, value));
        }
        
    }

}