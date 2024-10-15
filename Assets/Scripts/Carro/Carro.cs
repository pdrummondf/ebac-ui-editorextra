using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Carro : MonoBehaviour
{
    public GameObject carro;

    public int velocidade = 20;
    public int marchas = 5;

    public List<int> listaInteiros;

    public int numeroAleatorio = 0;

    public int velocidadeAtual { get { return velocidade * marchas; } }

    public void InstanciarCarro()
    {
        var a = Instantiate(carro);

        a.transform.position = Vector3.zero;
    }

    public int GerarNumeroAleatorio()
    {
        return ScriptUnitExtra.RanbomButNotSame(listaInteiros,-1);
    }
}
