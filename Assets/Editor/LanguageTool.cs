using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

/*
 * Matthew Borinsky 251093967
 * Editor window tool to add keys and corrosponding values and remove keys
 */

public class AddStringTool : EditorWindow {
    public ScriptableLanguage languages; // This doesnt show up in the inspector

    [MenuItem("Tools/Add Key")]
    public static void OpenSentenceTool() => GetWindow<AddStringTool>("Key Manager");

    // on enable create
    void OnEnable() {
        Selection.selectionChanged += Repaint;
    }

    // on disable create
    void OnDisable() {
        Selection.selectionChanged -= Repaint;
    }

    string key;
    string stringToAdd = null;
    
    // In the GUI
    void OnGUI()
    {
        key = EditorGUI.TextField(new Rect(10, 10, position.width - 20, 20), "Associated key:", key);  // Key to be added/removed

        EditorGUI.LabelField(new Rect(10, 20, position.width, 55), "Insert associated string (if applicable):");
        stringToAdd = EditorGUI.TextArea(new Rect(10, 70, position.width - 20, position.height - 130), stringToAdd);  // Value to be added with the key
        
        // Add key button
        if (GUI.Button(new Rect(10, position.height - 50, (position.width / 2) - 15, 35), "Add Key"))
        {
            AddElement(key, stringToAdd);
            
        }

        // Remove key button
        if (GUI.Button(new Rect((position.width / 2) + 5, position.height - 50, (position.width / 2) - 15, 35), "Remove Key"))
        {
            RemoveKey(key);
        }
        
    }

    // Remove key function associated to button, iterates through all places where the key is saved and deletes it
    void RemoveKey(string key){
        string[] scriptableLanguages = AssetDatabase.FindAssets("t:" + typeof(ScriptableLanguage).Name);
        for (int i = 0; i < scriptableLanguages.Length; i++){  // Iterates through all languages
            string path = AssetDatabase.GUIDToAssetPath(scriptableLanguages[i]);
            ScriptableLanguage thisLanguage = AssetDatabase.LoadAssetAtPath<ScriptableLanguage>(path);
            thisLanguage.RemoveElement(key);
        }

        // Removes keys added that are not in the scene
        string[] additionalElements = AssetDatabase.FindAssets("t:" + typeof(CurrentLanguageSO).Name);
        string additionalPath = AssetDatabase.GUIDToAssetPath(additionalElements[0]);
        CurrentLanguageSO additionalSave = AssetDatabase.LoadAssetAtPath<CurrentLanguageSO>(additionalPath);
        additionalSave.RemoveElement(key);
    }

    // Add element function to add a key and its associated default value to all languages
    void AddElement(string key, string stringToAdd){
        string[] scriptableLanguages = AssetDatabase.FindAssets("t:" + typeof(ScriptableLanguage).Name);
        for (int i = 0; i < scriptableLanguages.Length; i++){  // Iterates through all languages
            string path = AssetDatabase.GUIDToAssetPath(scriptableLanguages[i]);
            ScriptableLanguage thisLanguage = AssetDatabase.LoadAssetAtPath<ScriptableLanguage>(path);
            thisLanguage.AddElement(key, stringToAdd);
        }

        // Adds the key and value to the additional storage space
        string[] additionalElements = AssetDatabase.FindAssets("t:" + typeof(CurrentLanguageSO).Name);
        string additionalPath = AssetDatabase.GUIDToAssetPath(additionalElements[0]);
        CurrentLanguageSO additionalSave = AssetDatabase.LoadAssetAtPath<CurrentLanguageSO>(additionalPath);
        additionalSave.AddElement(key, stringToAdd);
    }

}