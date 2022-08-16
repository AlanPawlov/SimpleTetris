using Sirenix.OdinInspector.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class TetrisEditorWindow : OdinMenuEditorWindow
{
    [MenuItem("TetrisEditor/Main _%#D")]
    private static void OpenWindow()
    {
        GetWindow<TetrisEditorWindow>().Show();
    }

    protected override OdinMenuTree BuildMenuTree()
    {
        var tree = new OdinMenuTree();
        tree.Selection.SupportsMultiSelect = false;
        tree.Add("Constants", new GameplayConfigPageEditor());
        tree.Add("Figures", new FiguresPageEditor());
        return tree;
    }
}
