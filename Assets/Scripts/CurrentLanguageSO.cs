using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * Matthew Borinsky 251093967
 * Scriptable Object to hold which language is currently being used in the scene. 
 * The buttons use SetLanguage to change the language and the textboxes have a script
 * which checks the current language on FixedUpdate(). It also holds a list of all 
 * new elements added using the tools function.
 */

public class CurrentLanguageSO : ScriptableObject
{
    public ScriptableLanguage currentLanguage;  // Current language used in the scene
    [HideInInspector]
    public List<SerializableDictionary> addedElements = new List<SerializableDictionary>();  // All added elements from using the tools function

    // Getter to return the current language
    public ScriptableLanguage GetLanguage(){
        return currentLanguage;
    }

    // Setter to set the current language
    public void SetLanguage(ScriptableLanguage newLanguage){
        currentLanguage = newLanguage;
    }

    // Getter to return the elements
    public List<SerializableDictionary> GetElements(){
        return addedElements;
    }

    // Setter to add elements to the list
    public void AddElement(string key, string value){
        if (value == null){
            addedElements.Add(new SerializableDictionary(key));
        }else{
            addedElements.Add(new SerializableDictionary(key, value));
        }
        
    }

    // Remove element
    public void RemoveElement(string key){
    List<SerializableDictionary> elementsToRemove = new List<SerializableDictionary>();
    foreach(SerializableDictionary element in addedElements){
        if (element.GetKey() == key){
            elementsToRemove.Add(element);
        }
    }
    foreach(SerializableDictionary element in elementsToRemove){
        addedElements.Remove(element);
    }
    }
}
