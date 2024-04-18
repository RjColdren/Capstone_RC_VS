using UnityEngine;

public class FirstPersonCamera : MonoBehaviour
{
    //public float xAxisSpeed = 1.0f;
    // public float yAxisSpeed = 1.0f;

    //Creates a float called "xAxis"
    float xAxis;
    //Creates a float called "yAxis"
    float yAxis;

    //creates a float called "xAxisTurnRate" with a value of 360
    float xAxisTurnRate = 360f;
    //creates a float called "yAxisTurnRate" with a value of 360
    float yAxisTurnRate = 360f;

    // Start is called before the first frame update
    void Start()
    {
        //Locks the cursor when playing and hides it.
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void OnDisable()
    {
       Cursor.lockState = CursorLockMode.None;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        //creates a Quaternion (rotation) value for the camera and uses a 
        //Euler (Xaxis, Yaxis, Zaxis) value
        Quaternion newRotation = Quaternion.Euler(xAxis, yAxis, 0);

        //Applies the rotation to the camera.
        Camera.main.transform.rotation = newRotation;
    }

    public void AddXAxisInput(float input)
    {
        //Moves the xAxis up and down
        xAxis -= input * xAxisTurnRate;
        //locks the x axis so it doesn't completely twist around.
        xAxis = Mathf.Clamp(xAxis, -90f, 90f);
    }

    public void AddYAxisInput(float input)
    {
        //Moves the yAxis left and right.
        yAxis += input * yAxisTurnRate;
    }

}
