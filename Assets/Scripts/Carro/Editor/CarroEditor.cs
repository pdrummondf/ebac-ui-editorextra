using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(Carro))]
public class CarroEditor : Editor
{
    SerializedProperty integerList;

    private void OnEnable()
    {
        // Link the SerializedProperty to the "integerList" in the target component
        integerList = serializedObject.FindProperty("listaInteiros");
    }

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        Carro myTarget = (Carro)target;

        myTarget.carro = (GameObject)EditorGUILayout.ObjectField(myTarget.carro, typeof(GameObject), true);
        myTarget.velocidade = EditorGUILayout.IntField("Minha velocidade", myTarget.velocidade);
        myTarget.marchas= EditorGUILayout.IntField("Marcha", myTarget.marchas);

        EditorGUILayout.HelpBox("Calculo da velocidade do carro.", MessageType.Info);
        EditorGUILayout.LabelField("Velocidade total", myTarget.velocidadeAtual.ToString());
        if ((myTarget.velocidadeAtual < 0) || (myTarget.velocidadeAtual > 200))
        {
            EditorGUILayout.HelpBox("Velocidade não permitida!", MessageType.Error);
        }

        if (GUILayout.Button("Criar carro"))
        {
            myTarget.InstanciarCarro();
        }

        myTarget.numeroAleatorio = EditorGUILayout.IntField("Numero Aleatorio", myTarget.numeroAleatorio);
        if (GUILayout.Button("Gerar Numero Aleatorio"))
        {
            myTarget.numeroAleatorio = myTarget.GerarNumeroAleatorio();
        }

        #region CodigoTeste
        // Update serializedObject so the fields are up-to-date
        serializedObject.Update();

        // Display the label for the list
        EditorGUILayout.LabelField("Lista de Inteiros", EditorStyles.boldLabel);

        // Check if the list is initialized
        if (integerList.isArray)
        {
            // Loop through each element in the list and display an integer field
            for (int i = 0; i < integerList.arraySize; i++)
            {
                EditorGUILayout.BeginHorizontal();

                // Display the integer field for each element in the list
                SerializedProperty element = integerList.GetArrayElementAtIndex(i);
                element.intValue = EditorGUILayout.IntField($"Elemento {i}", element.intValue);

                // Button to remove the element from the list
                if (GUILayout.Button("Apagar", GUILayout.Width(70)))
                {
                    integerList.DeleteArrayElementAtIndex(i);
                }

                EditorGUILayout.EndHorizontal();
            }

            // Button to add a new element to the list
            if (GUILayout.Button("Adicionar novo elemento"))
            {
                integerList.arraySize++;
            }
        }

        // Apply the property modifications
        serializedObject.ApplyModifiedProperties();
        #endregion
    }
}
