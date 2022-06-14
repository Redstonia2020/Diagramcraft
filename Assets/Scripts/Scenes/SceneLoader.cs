using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scenes
{
    StartScreen,
    Editor
}

public static class SceneLoader
{
    public static Dictionary<Scenes, string> SceneToFileName = new Dictionary<Scenes, string>
    {
        { Scenes.StartScreen, "Scenes/TitleScreen" },
        { Scenes.Editor, "Scenes/DiagramEditor" }
    };

    public static void LoadScene(Scenes scene)
    {
        SceneManager.LoadScene(SceneToFileName[scene]);
    }
}
