using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

/*
 * Matthew Borinsky 251093967
 * Scriptable language class for keys and their values in that language.
 * Fills the new language on enable with already existing keys then has helpers.
 */

[CreateAssetMenu(fileName = "New Language", menuName = "Language")]
public class ScriptableLanguage : ScriptableObject {
    [NonReorderable]
    public List<SerializableDictionary> language = new List<SerializableDictionary>();
    private bool isCreated = false;

    #if UNITY_EDITOR  // Should only be done in the editor
    void OnEnable(){
        if (!isCreated){
            Key[] allKeys = FindObjectsOfType(typeof(Key)) as Key[];

            foreach(Key key in allKeys){
                language.Add(new SerializableDictionary(key.key));
            }

            string[] additionalElements = AssetDatabase.FindAssets("t:" + typeof(CurrentLanguageSO).Name);
            string path = AssetDatabase.GUIDToAssetPath(additionalElements[0]);
            CurrentLanguageSO thisLanguage = AssetDatabase.LoadAssetAtPath<CurrentLanguageSO>(path);
            foreach(SerializableDictionary element in thisLanguage.GetElements()){
                language.Add(element);
            }

            isCreated = true;
        }

    }
    #endif

    // Returns the value relating to this key
    public string GetValue(string key){
        foreach(SerializableDictionary element in language){
            if (element.GetKey() == key){
                return element.GetValue();
            }
        }
        return "ERROR COULD NOT FIND KEY";
    }

    // Adds a new key value element to the list
    public void AddElement(string key, string value){
        if (value == null){
            language.Add(new SerializableDictionary(key));
        }else{
            language.Add(new SerializableDictionary(key, value));
        }
        
    }

    // Removes the element associated with this.key
    public void RemoveElement(string key){
        List<SerializableDictionary> elementsToRemove = new List<SerializableDictionary>();
        foreach(SerializableDictionary element in language){
            if (element.GetKey() == key){
                elementsToRemove.Add(element);
            }
        }
        foreach(SerializableDictionary element in elementsToRemove){
            language.Remove(element);
        }
    }

}