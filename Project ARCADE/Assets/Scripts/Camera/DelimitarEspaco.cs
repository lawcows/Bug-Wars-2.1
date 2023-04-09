using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DelimitarEspaco : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    public float limiteEsquerdo = -10f; // Define o limite esquerdo
    public float limiteDireito = 10f; // Define o limite direito
    public float limiteInferior = -20f; // Define o limite inferior
    public float limiteSuperior = 20f; // Define o limite superior
    public float limiteBaixo = -10f; // Define o limite inferior em y
    public float limiteAlto = 10f; // Define o limite superior em y

    private void FixedUpdate()
    {
        // Obt�m as coordenadas x, y e z do player
        float x = transform.position.x;
        float y = transform.position.y;
        float z = transform.position.z;

        // Verifica se o player ultrapassou os limites
        if (x < limiteEsquerdo)
        {
            x = limiteEsquerdo;
        }
        else if (x > limiteDireito)
        {
            x = limiteDireito;
        }

        if (z < limiteInferior)
        {
            z = limiteInferior;
        }
        else if (z > limiteSuperior)
        {
            z = limiteSuperior;
        }

        if (y < limiteBaixo)
        {
            y = limiteBaixo;
        }
        else if (y > limiteAlto)
        {
            y = limiteAlto;
        }

        // Define a nova posi��o do player com as coordenadas limitadas
        transform.position = new Vector3(x, y, z);
    }
}
