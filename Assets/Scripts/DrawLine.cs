using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DrawLine : MonoBehaviour
{
    [SerializeField] private Transform a;
    [SerializeField] private Transform b;
    [SerializeField] private float sphereSize = 0.2f;
    [SerializeField] private Text text;

    private void OnDrawGizmos()
    {
        // Y = m * X + c => onde m = tangente e c = -tangente * a.X + a.Y
        float catetoAdjacente = b.position.x - a.position.x;
        float catetoOposto = b.position.y - a.position.y;
        float tangente = catetoOposto / catetoAdjacente;
        float c = -tangente * a.position.x + a.position.y;
        text.text = $"Y = {tangente}x + {c} ||| Anlge => {Mathf.Atan(tangente) * Mathf.Rad2Deg}";

        // mostra o cateto oposto
        Gizmos.color = Color.green;
        Vector3 oposto = b.position - new Vector3(0, b.position.y > a.position.y ? Mathf.Abs(catetoOposto) : catetoOposto, 0);
        Gizmos.DrawLine(b.position, oposto);

        // mostra o cateto adjacente
        Gizmos.color = Color.blue;
        Vector3 adjacent = a.position + new Vector3(a.position.x < b.position.x ? Mathf.Abs(catetoAdjacente) : catetoAdjacente, 0, 0);
        Gizmos.DrawLine(a.position, adjacent);

        // mostra hipotenusa
        Gizmos.color = Color.red;
        Gizmos.DrawLine(a.position, b.position);

        // desenha os pontos
        Gizmos.DrawSphere(a.position, sphereSize);
        Gizmos.DrawSphere(b.position, sphereSize);
    }
}
