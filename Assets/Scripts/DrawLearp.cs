using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawLearp : MonoBehaviour
{
    [SerializeField] private Transform a;
    [SerializeField] private Transform b;
    [SerializeField] private float positionLearp;

    private void OnDrawGizmos()
    {
        // desenha a linha Y
        float distanceY = b.position.y - a.position.y;
        Gizmos.DrawLine(a.position, a.position + new Vector3(0, distanceY, 0));

        // desenha a linha X
        float distanceX = b.position.x - a.position.x;
        Gizmos.DrawLine(a.position, a.position + new Vector3(distanceX, 0, 0));

        // desenha a bolinha no eixo X do learp
        float distanceLearpX = Mathf.Abs(b.position.x - a.position.x);
        float learpPositionX = distanceLearpX * positionLearp;
        Gizmos.DrawSphere(a.position + new Vector3(learpPositionX, 0, 0), 0.1f);

        // desenha a bolinha no eixo Y do learp
        float distanceLearpY = Mathf.Abs(b.position.y - a.position.y);
        float learpPositionY = distanceLearpY * positionLearp;
        Gizmos.DrawSphere(a.position + new Vector3(0, learpPositionY, 0), 0.1f);

        // desenha a linha ligando os dois pontos
        Gizmos.color = Color.blue;
        Gizmos.DrawLine(a.position, b.position);
        Gizmos.DrawSphere(a.position, 0.1f);
        Gizmos.DrawSphere(b.position, 0.1f);

        // desenha a bolinha do learp sobre a linha
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(a.position + new Vector3(learpPositionX, learpPositionY, 0), 0.1f);
    }
}
