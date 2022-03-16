using UnityEngine;
using System.Threading;
public class NPCSpawner : MonoBehaviour
{
    public GameObject objectToSpawn;
    GameObject NPC;
    Vector3 endPos;
    public float speed; 
    private Interactable interactable;



    // Start is called before the first frame update
    void Start()
    {
        
        endPos = new Vector3(-50f, 0f, objectToSpawn.transform.position.z);
        NPC = Instantiate(objectToSpawn, transform.position, transform.rotation);
    }

    // Update is called once per frame
    void Update()
    {
        move();
    }

    // Move the npc at speed to endPos, then Destroy the clone and instiate a new one and repeat
    private void move() {
        
        if (NPC.transform.position != endPos) {
            Vector3 newPos = Vector3.MoveTowards(NPC.transform.position, endPos, speed * Time.deltaTime);
            NPC.transform.position = newPos;
        } else {
            Destroy(NPC);
            NPC = Instantiate(objectToSpawn, transform.position, transform.rotation);
        }
        
    }
}


/* // Attached interactable aka the interactable that this area belongs to
    

    // When the collider is entered
    private void OnTriggerEnter(Collider other) {

        // Ignore if not the player
        if (other.gameObject.tag != "Player") {
            return;
        }

        Debug.Log("Interaction area entered!");

        interactable.InteractionAreaEntered();
    }

    // When the collider is exited
    private void OnTriggerExit(Collider other) {

        // Ignore if not the player
        if (other.gameObject.tag != "Player") {
            return;
        }

        Debug.Log("Interaction area exited!");

        interactable.InteractionAreaExited();
    }
*/