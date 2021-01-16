using UnityEngine;
using UnityEngine.Rendering.PostProcessing;

public class SlowMotion : MonoBehaviour
{
    private readonly float slowDownLength = 2f;
    private readonly float slowDownFactor = 0.05f;

    [SerializeField]
    private GameObject mPostProcessing;

    private Transform mPlayerPosition;

    private PostProcessVolume mPostProcessVolume;

    private void Start()
    {
        mPlayerPosition = GetComponent<Transform>();
        mPostProcessVolume = mPostProcessing.GetComponent<PostProcessVolume>();
        mPostProcessVolume.weight = 0.0f;
    }

    void Update()
    {
        bool movement = (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.D));
        TimeBulletEffects(movement);
    }

    private void TimeBulletEffects(bool timeTriggered)
    {
        
        //mPostProcessing.SetActive(!timeTriggered);
        
        if (timeTriggered)
        {
            // Normal time scale
            Time.timeScale += (1f / slowDownLength) * Time.unscaledDeltaTime;
            Time.timeScale = Mathf.Clamp(Time.timeScale, 0f, 1f);
            mPostProcessVolume.weight = Mathf.Lerp(mPostProcessVolume.weight, 0, 10.0f * Time.deltaTime);
            // mPostProcessing.position = new Vector3(mPlayerPosition.position.x, mPlayerPosition.position.y, mPlayerPosition.position.z - 3f);
            
        }
        else
        {
            mPostProcessVolume.weight = Mathf.Lerp(mPostProcessVolume.weight, 1, 20.0f * Time.deltaTime);

            // Slow time scale
            Time.timeScale = slowDownFactor;
            Time.fixedDeltaTime = Time.timeScale * 0.02f;
            //mPostProcessing.position = new Vector3(mPlayerPosition.position.x, mPlayerPosition.position.y, mPlayerPosition.position.z );
        }

    }
}
