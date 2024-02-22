using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(ObstacleData))]
public class ObstacleEditor : Editor
{
    private bool showGrid = true;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        ObstacleData obstacleData = (ObstacleData)target;

        EditorGUILayout.Space();

        showGrid = EditorGUILayout.Toggle("Show Grid", showGrid);

        if (showGrid)
        {
            DrawGrid(obstacleData);
        }
    }

    private void DrawGrid(ObstacleData obstacleData)
    {
        GUILayout.BeginHorizontal();

        for (int y = 0; y < 10; y++)
        {
            GUILayout.BeginVertical();

            for (int x = 0; x < 10; x++)
            {
                EditorGUI.BeginChangeCheck();
                bool isObstacle = GUILayout.Toggle(obstacleData.obstacleGrid[x, y], GUIContent.none, "Button", GUILayout.Width(20), GUILayout.Height(20));
                if (EditorGUI.EndChangeCheck())
                {
                    obstacleData.obstacleGrid[x, y] = isObstacle;
                }
            }

            GUILayout.EndVertical();
        }

        GUILayout.EndHorizontal();
    }
}
