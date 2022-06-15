using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class EditorMenu : EditorWindow
{
    static EditorMenu Instance;

    protected bool saveBtn = false;
    protected bool loadBtn = false;

    protected string NewTaskInput = "";

    protected List<string> TODO = new List<string>();
    protected List<string> PROGRESS = new List<string>();
    protected List<string> COMPLETE = new List<string>();

    [MenuItem("Window/KoMa")]
    public static void ShowWindow()
    {
        Instance = (EditorMenu)GetWindow(typeof(EditorMenu));
        Instance.titleContent = new GUIContent("Kanban board");
        Instance.LoadLists();
    }

    void OnGUI()
    {
        DrawUIElements();
    }

    private void AddNewTask(string task)
    {
        TODO.Add(task);
    }

    private void DrawUIElements()
    {
        DrawColumns();
        DrawTaskLableAndButton();
    }

    private void DrawColumns()
    {
        //Column style
        var areaStyle = new GUIStyle();
        areaStyle.border = new RectOffset(2, 2, 2, 2);
        areaStyle.normal.background = Resources.Load<Texture2D>("Area");

        //Column label style
        var LabelStyle = new GUIStyle();
        LabelStyle.alignment = TextAnchor.LowerCenter;
        LabelStyle.normal.textColor = Color.green;

        //Task style
        var TaskStyle = new GUIStyle();
        TaskStyle.alignment = TextAnchor.MiddleLeft;
        TaskStyle.fontSize = 17;
        TaskStyle.fixedWidth = 140;
        TaskStyle.normal.textColor = Color.white;
        TaskStyle.margin = new RectOffset(10, 10, 10, 10);
        TaskStyle.wordWrap = true;
        TaskStyle.border = new RectOffset(0, 0, 0, 0);
        TaskStyle.normal.background = Resources.Load<Texture2D>("Background");
        TaskStyle.padding = new RectOffset(4, 4, 4, 4);

        #region TO_DO_AREA
        GUILayout.BeginArea(new Rect(10, 50, 200, 600), areaStyle);
        GUILayout.Space(10f);

        GUILayout.Label("TODO", LabelStyle);

        for (int i = 0; i < TODO.Count; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(TODO[i], TaskStyle);

            GUILayout.BeginVertical();
            GUILayout.Space(8f);

            DrawMoveButton(TODO, PROGRESS, i, true);

            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
            GUILayout.Space(5f);
        }


        GUILayout.EndArea();
        #endregion

        #region IN_PROGRESS
        GUILayout.BeginArea(new Rect(220, 50, 200, 600), areaStyle);
        GUILayout.Space(10f);

        GUILayout.Label("IN PROGRESS", LabelStyle);

        for (int i = 0; i < PROGRESS.Count; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(PROGRESS[i], TaskStyle);

            GUILayout.BeginVertical();

            GUILayout.Space(8f);

            DrawMoveButton(PROGRESS, COMPLETE, i, true);
            DrawMoveButton(PROGRESS, TODO, i, false);

            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
            GUILayout.Space(5f);
        }

        GUILayout.EndArea();
        #endregion

        #region COMPLETE
        GUILayout.BeginArea(new Rect(430, 50, 200, 600), areaStyle);
        GUILayout.Space(10f);

        GUILayout.Label("COMPLETE", LabelStyle);

        for (int i = 0; i < COMPLETE.Count; i++)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Label(COMPLETE[i], TaskStyle);

            GUILayout.BeginVertical();

            GUILayout.Space(8f);
            DrawMoveButton(COMPLETE, PROGRESS, i, false);

            GUILayout.EndVertical();

            GUILayout.EndHorizontal();
            GUILayout.Space(5f);
        }

        GUILayout.EndArea();
        #endregion

    }

    private void DrawMoveButton(List<string> from, List<string> to, int index, bool toRight)
    {
        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button)
        {
            fixedWidth = 30,
            padding = new RectOffset(0, 0, 0, 0),
            alignment = TextAnchor.MiddleCenter,
        };

        string buttonText = toRight ? "->" : "<-";

        if (GUILayout.Button(buttonText, buttonStyle))
        {
            to.Add(from[index]);
            from.RemoveAt(index);
        }
    }

    private void DrawTaskLableAndButton()
    {
        //Text field style
        GUIStyle fieldStyle = new GUIStyle(GUI.skin.textField);
        fieldStyle.wordWrap = true;

        GUIStyle buttonStyle = new GUIStyle(GUI.skin.button)
        {
            fixedWidth = 40,
            fixedHeight = 40,
            
        };

        GUILayout.BeginHorizontal();
        GUILayout.BeginVertical();
        //Input field
        NewTaskInput = EditorGUILayout.TextField(NewTaskInput, fieldStyle, GUILayout.Height(20));

        //Add task button
        if (GUILayout.Button("Add new task") && !string.IsNullOrEmpty(NewTaskInput))
        {
            AddNewTask(NewTaskInput);
            NewTaskInput = "";
            SaveLists();
        }
        GUILayout.EndVertical();

        if (GUILayout.Button(Resources.Load<Texture>("settings"), buttonStyle))
        {
            var window = (SettingsKanban)GetWindow(typeof(SettingsKanban));
        }

        GUILayout.EndHorizontal();
    }

    private void SaveLists()
    {
        System.IO.File.WriteAllLines("TODO.txt", TODO);
        System.IO.File.WriteAllLines("PROGRESS.txt", PROGRESS);
        System.IO.File.WriteAllLines("COMPLETE.txt", COMPLETE);
    }

    private void LoadLists()
    {
        TODO = System.IO.File.ReadAllLines("TODO.txt").ToList<string>();
        PROGRESS = System.IO.File.ReadAllLines("PROGRESS.txt").ToList<string>();
        COMPLETE = System.IO.File.ReadAllLines("COMPLETE.txt").ToList<string>();
    }
}