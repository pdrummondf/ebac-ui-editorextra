using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class ScriptUnitExtra 
{
#if UNITY_EDITOR
    [UnityEditor.MenuItem("Ebac/Teste001")]
    public static void TesteMenu()
    {
        Debug.Log("Acionando menu!");
    }

    [UnityEditor.MenuItem("Ebac/Teste002/TesteSubMenu %g")]
    public static void TesteSubMenu()
    {
        Debug.Log("Acionando sub-menu!");
    }
#endif

    public static T GetRandom<T>(this List<T> list)
    {
        return list[Random.Range(0, list.Count)];
    }

    public static T RanbomButNotSame<T>(this List<T> list, T unique)
    {
        if (list.Count == 1)
        {
            return unique;
        }

        int randomIndex = Random.Range(0, list.Count);

        return list[randomIndex];
    }
}
