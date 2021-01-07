using System.Collections;
using UnityEngine;

public class TrafficLightController : MonoBehaviour
{
    [System.Serializable]
    public struct TrafficLightLight
    {
        public MeshRenderer renderer;

        public Material on;

        public Material off;
    }

    private enum State
    {
        GREEN,

        YELLOW,

        RED
    }

    public TrafficLightLight green;

    public TrafficLightLight yellow;

    public TrafficLightLight red;

    public float eachTime = 1;

    private State m_State;

    private bool flag = false;

    void Start()
    {
        green.renderer.material = green.on;
        yellow.renderer.material = yellow.off;
        red.renderer.material = red.off;

        m_State = State.GREEN;

        flag = true;
    }

    void Update()
    {
        if (flag)
            StartCoroutine("ChangeLight");
    }

    private IEnumerator ChangeLight()
    {
        flag = false;

        yield return new WaitForSeconds(eachTime);

        switch (m_State)
        {
            case State.GREEN:
                green.renderer.material = green.off;
                yellow.renderer.material = yellow.on;
                red.renderer.material = red.off;
                m_State = State.YELLOW;
                break;
            case State.YELLOW:
                green.renderer.material = green.off;
                yellow.renderer.material = yellow.off;
                red.renderer.material = red.on;
                m_State = State.RED;
                break;
            case State.RED:
                green.renderer.material = green.on;
                yellow.renderer.material = yellow.off;
                red.renderer.material = red.off;
                m_State = State.GREEN;
                break;
        }

        flag = true;
    }
}
