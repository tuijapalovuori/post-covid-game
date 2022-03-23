using UnityEngine;

public class NPCSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    GameObject NPC;
    public GameObject targetLocation;
    Vector3 endPos;
    public float speed; // Keep the speed low. Like under 0.1f
    public bool stop = false; // Movement stopper

    // Start is called before the first frame update
    void Start() {

        endPos = new Vector3(targetLocation.transform.position.x, 0f, targetLocation.transform.position.z);
        NPC = Instantiate(objectToSpawn, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update() {

        moveX(); 
        // TODO:
        // moveZ() same as moveX, but for Z axis
    }

    // Move the npc at speed to endPos, then Destroy the clone and instiate a new one and repeat
    private void moveX() {

        // Move NPC untill distance between it and target < 0.1
        if (Mathf.Abs(NPC.transform.position.x - targetLocation.transform.position.x) > 0.1) {

            if (stop) {
                Destroy(NPC);
                NPC = Instantiate(objectToSpawn, transform.position, transform.rotation);
            } else {

                Debug.Log(speed);
                // Get the spawner name and determinate the movement direction

                if (targetLocation.name.Contains("XPlus")) {
                    NPC.transform.position = new Vector3(NPC.transform.position.x + speed, NPC.transform.position.y, NPC.transform.position.z);
                }

                if (targetLocation.name.Contains("XMinus")) {
                    NPC.transform.position = new Vector3(NPC.transform.position.x - speed, NPC.transform.position.y, NPC.transform.position.z);
                }
            }
                // If is talked to, stops movement
            /* Another try
            } else {
                Debug.Log("Stop");
                //NPC.transform.position = new Vector3(NPC.transform.position.x, NPC.transform.position.y, NPC.transform.position.z);
            }
           */
        // Destroy the instance and create a new one and repeat the process.
        } else {
             Destroy(NPC);
             NPC = Instantiate(objectToSpawn, transform.position, transform.rotation);
        }
        
    }

}
