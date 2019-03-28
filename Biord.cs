using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boird : MonoBehaviour {

    private const float targetLength = 0.01f;

    private Vector3[,] bezierPoints;

    private float time;
    private int section;

	// Use this for initialization
	void Start () {
        transform.Translate(new Vector3(1, 0, 0));

        bezierPoints = new Vector3[2, 4];
        bezierPoints[0, 0] = new Vector3(1,  0,  0);
        bezierPoints[0, 1] = new Vector3(1,  0,  1);
        bezierPoints[0, 2] = new Vector3(-1, 0,  1);
        bezierPoints[0, 3] = new Vector3(-1, 0,  0);

        bezierPoints[1, 0] = new Vector3(-1, 0,  0);
        bezierPoints[1, 1] = new Vector3(-1, 0, -1);
        bezierPoints[1, 2] = new Vector3(1,  0, -1);
        bezierPoints[1, 3] = new Vector3(1,  0,  0);

        time = 0.0f;
    }
	
	// Update is called once per frame
	void Update () {
        time += Time.smoothDeltaTime;
        if (time > 4.0f)
        {
            section = (section == 0) ? 1 : 0;
            time = 0.0f;
        }

        Vector3 proposed_position = B_of(time / 4.0f);
        if((transform.position - proposed_position).magnitude >= targetLength)
        {
            transform.position = proposed_position;
        }
        
	}

    Vector3 B_of(float t)
    {
        return  (1 - t) * (1 - t) * (1 - t) * bezierPoints[section,0] 
                + 3 * (1 - t) * (1 - t)  * t * bezierPoints[section, 1]
                + 3 * (1 - t) * t * t * bezierPoints[section, 2]
                + t * t * t * bezierPoints[section, 3];
    }
}
