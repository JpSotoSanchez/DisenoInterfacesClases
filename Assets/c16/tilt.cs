using UnityEngine;

public class tilt : MonoBehaviour
{
    public float time = 0;
    public float limite = 0;
    int sideActual = 0;
    int sidePasado = 5;
    float angulo = 0;
    Quaternion rotacionObjetivo;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rotacionObjetivo = this.gameObject.transform.localRotation;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= limite)
        {
            tiltFunction();
            time = 0;
        }

        this.gameObject.transform.localRotation = Quaternion.Slerp(this.gameObject.transform.localRotation, rotacionObjetivo, 2 * Time.deltaTime);
    }

    public void tiltFunction()
    {
        sideActual = Random.Range(0, 4);
        while (sideActual == sidePasado)
        {
            sideActual = Random.Range(0, 4);
        }
        sidePasado = sideActual;

        angulo = Random.Range(0, 5);

        switch (sideActual)
        {
            case 0:
                rotacionObjetivo = Quaternion.Euler(angulo, 0, 0);
            break;
            case 1:
                rotacionObjetivo = Quaternion.Euler(-angulo, 0, 0);
            break;
            case 2:
                rotacionObjetivo = Quaternion.Euler(0, 0, angulo);
            break;
            case 3:
                rotacionObjetivo = Quaternion.Euler(0, 0, -angulo);
            break;
            default:

            break;
        }
    }
}