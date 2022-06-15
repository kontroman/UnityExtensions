using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class SettingsKanban : EditorWindow
{
    Color textColor = Color.white;
    Color borderColor = Color.white;
    Color taskPanelColor = Color.white;

    void OnGUI()
    {
        GUILayout.Space(10f);

        textColor = EditorGUILayout.ColorField("Text color", textColor);
        GUILayout.Space(5f);

        borderColor = EditorGUILayout.ColorField("Border color", borderColor);
        GUILayout.Space(5f);

        taskPanelColor = EditorGUILayout.ColorField("Task panel color", taskPanelColor);
        GUILayout.Space(5f);

        if (GUILayout.Button("Delete all tasks"))
            DeleteTasks();
    }

    private void DeleteTasks()
    {

    }
}
