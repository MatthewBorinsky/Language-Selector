using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class AddStringTool : EditorWindow {
    public ScriptableLanguage languages; // This doesnt show up in the inspector

    [MenuItem("Tools/Add Key")]
    public static void OpenSentenceTool() => GetWindow<AddStringTool>("Key Manager");

    void OnEnable() {
        Selection.selectionChanged += Repaint;
    }

    void OnDisable() {
        Selection.selectionChanged -= Repaint;
    }

    string key;
    string stringToAdd = null;
    
    void OnGUI()
    {
        key = EditorGUI.TextField(new Rect(10, 10, position.width - 20, 20), "Associated key:", key);

        EditorGUI.LabelField(new Rect(10, 20, position.width, 55), "Insert associated string (if applicable):");
        stringToAdd = EditorGUI.TextArea(new Rect(10, 70, position.width - 20, position.height - 130), stringToAdd);
        
        if (GUI.Button(new Rect(10, position.height - 50, (position.width / 2) - 15, 35), "Add Key"))
        {
            languages.AddElement(key, stringToAdd);
        }

        if (GUI.Button(new Rect((position.width / 2) + 5, position.height - 50, (position.width / 2) - 15, 35), "Remove Key"))
        {
            // RemoveKey();
        }
        
    }

}