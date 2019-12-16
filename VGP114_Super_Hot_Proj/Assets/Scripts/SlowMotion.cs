using UnityEngine;

public class SlowMotion : MonoBehaviour
{
    private readonly float slowDownLength = 2f;
    private readonly float slowDownFactor = 0.05f;

    [SerializeField]
    private Transform mPostProcessing;

    private Transform mPlayerPosition;
    private void Start()
    {
        mPlayerPosition = GetComponent<Transform>();
    }

    void Update()
    {
        bool movement = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D));
        TimeBulletEffects(movement);
    }

    private void TimeBulletEffects(bool timeTriggered)
    {
        if (timeTriggered)
        {
            Time.timeScale += (1f / slowDownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            mPostProcessing.position = new Vector3(mPlayerPosition.position.x, mPlayerPosition.position.y, mPlayerPosition.position.z + 2f);
        }
        else
        {
            Time.timeScale = slowDownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            mPostProcessing.position = new Vector3(mPlayerPosition.position.x, mPlayerPosition.position.y, mPlayerPosition.position.z  -1.5f);
        }

    }
}
