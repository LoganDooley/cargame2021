// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// https://pixelnest.io/tutorials/2d-game-unity/parallax-scrolling/
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using System;

public class BackgroundScript : MonoBehaviour
{

    public GameObject[] panels = new GameObject[3];
    public float base_speed;

    void Start() 
    {
    }

    void Update()
    {
        for(int i = 0; i<panels.Length; i++)
        {
            panels[i].transform.position += Vector3.left * base_speed * Time.deltaTime;
        }

        if(panels[0].transform.position.x <= -20)
        {
            panels[0].transform.position += Vector3.right * 57;
            GameObject first_panel = panels[0];
            panels[0] = panels[1];
            panels[1] = panels[2];
            panels[2] = first_panel;
        }
    }
}
    // public GameObject[] layers;
    // // next time todos: make a 2d array for layers. each time boundary is reached, 
    // // move the panel at position 0 to position 1, the one at position 1 to position 
    // // 2 and so on
    // public Vector3[] start_pos;
    // public float base_speed;

    // // Start is called before the first frame update
    // void Start()
    // {
    //     for(int i = 0; i<layers.Length; i++)
    //     {
    //         start_pos[i] = layers[i].transform.position;
    //     }
    // }

    // void FixedUpdate()
    // {
    //     for(int i = 0; i<layers.Length; i++)
    //     {
    //         layers[i].transform.position += base_speed* Vector3.left * (1f / (i + 1));
    //         if(layers[i].transform.position.x <= -100)
    //         {
    //             layers[i].transform.position = start_pos[i];
    //         }
    //     }
    // }




/// Parallax scrolling script that should be assigned to a layer
// public class BackgroundScript : MonoBehaviour
// {
//     /// Scrolling speed
//     public Vector2 speed = new Vector2(10, 10);

//     /// Moving direction
//     public Vector2 direction = new Vector2(-1, 0);

//     /// Movement should be applied to camera
//     public bool isLinkedToCamera = false;

//     /// 1 - Background is infinite
//     public bool isLooping = true;

//     /// 2 - List of children with a renderer.
//     private List<SpriteRenderer> backgroundPart;

//     // 3 - Get all the children
//     void Start()
//     {
//         // For infinite background only
//         if (isLooping)
//         {
//             // Get all the children of the layer with a renderer
//             backgroundPart = new List<SpriteRenderer>();

//             print("Here");
//             for (int i = 0; i < transform.childCount; i++)
//             {
//                 Console.WriteLine(i);
//                 Transform child = transform.GetChild(i);
//                 SpriteRenderer r = child.GetComponent<SpriteRenderer>();

//                 // Add only the visible children
//                 if (r != null)
//                 {
//                     backgroundPart.Add(r);
//                 }
//             }

//             // Sort by position.
//             // Note: Get the children from left to right.
//             // We would need to add a few conditions to handle
//             // all the possible scrolling directions.
//             backgroundPart = backgroundPart.OrderBy(
//               t => t.transform.position.x
//             ).ToList();
//         }
//     }

//     void Update()
//     {
//         // Movement
//         Vector3 movement = new Vector3(
//           speed.x * direction.x,
//           speed.y * direction.y,
//           0);

//         movement *= Time.deltaTime;
//         transform.Translate(movement);

//         // Move the camera
//         if (isLinkedToCamera)
//         {
//             Camera.main.transform.Translate(movement);
//         }

//         // 4 - Loop
//         if (isLooping)
//         {
//             // Get the first object.
//             // The list is ordered from left (x position) to right.
//             SpriteRenderer firstChild = backgroundPart.FirstOrDefault();

//             if (firstChild != null)
//             {
//                 // Check if the child is already (partly) before the camera.
//                 // We test the position first because the IsVisibleFrom
//                 // method is a bit heavier to execute.
//                 if (firstChild.transform.position.x < Camera.main.transform.position.x)
//                 {
//                     // If the child is already on the left of the camera,
//                     // we test if it's completely outside and needs to be
//                     // recycled.
//                     if (firstChild.IsVisibleFrom(Camera.main) == false)
//                     {
//                         // Get the last child position.
//                         SpriteRenderer lastChild = backgroundPart.LastOrDefault();

//                         Vector3 lastPosition = lastChild.transform.position;
//                         Vector3 lastSize = (lastChild.bounds.max - lastChild.bounds.min);

//                         // Set the position of the recyled one to be AFTER
//                         // the last child.
//                         // Note: Only work for horizontal scrolling currently.
//                         firstChild.transform.position = new Vector3(lastPosition.x + lastSize.x, firstChild.transform.position.y, firstChild.transform.position.z);

//                         // Set the recycled child to the last position
//                         // of the backgroundPart list.
//                         backgroundPart.Remove(firstChild);
//                         backgroundPart.Add(firstChild);
//                     }
//                 }
//             }
//         }
//     }
// }

//

// public class BackgroundScript : MonoBehaviour
// {
//     public GameObject[] layers;
//     // next time todos: make a 2d array for layers. each time boundary is reached, 
//     // move the panel at position 0 to position 1, the one at position 1 to position 
//     // 2 and so on
//     public Vector3[] start_pos_vect;
//     public float base_speed;
//     public float parallaxEffect;
//     private float length, startpos;
//     public GameObject cam;
//     // private Vector2 screenBounds;

//     // Start is called before the first frame update
//     void Start()
//     {
//         //startpos = transform.position.x; // new
//         length = GetComponent<SpriteRenderer>().bounds.size.x; // new

//         //cam = GetComponent<Camera>();
//         //screenBounds = cam.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, cam.transform.position.z));

//         for(int i = 0; i<layers.Length; i++)
//         {
//             start_pos_vect[i] = layers[i].transform.position;
//         }
//     }

//     void FixedUpdate()
//     {
//         float temp = cam.transform.position.x * (1 - parallaxEffect); // new
//         float dist = cam.transform.position.x * parallaxEffect; // new
//         for(int i = 0; i<layers.Length; i++)
//         {
//             layers[i].transform.position += base_speed * Vector3.left * (1f / (i + 1));
//             // if(layers[i].transform.position.x <= -100)
//             // {
//             //     layers[i].transform.position = start_pos_vect[i];
//             // }

//             // if (temp > start_pos_vect[i].x + length) start_pos_vect[i].x += length;
//             // else if (temp < start_pos_vect[i].x - length) start_pos_vect[i].x -= length;
            
//         }
//     }
// }

// Speed of slowest background layer (Street): 0.1 * (1/6) = 0.0167

// https://pressstart.vip/tutorials/2019/04/15/93/endless-2d-background.html

// public class BackgroundScript : MonoBehaviour
// {
//     public GameObject[] layers;
//     // public Vector3[] start_pos;
//     // public float base_speed;

//     private Camera mainCamera;
//     private Vector2 screenBounds;
//     public float choke;
//     public float scrollSpeed; 
    

//     void Start()
//     {
//         mainCamera = gameObject.GetComponent<Camera>();
//         screenBounds = mainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, mainCamera.transform.position.z));
//         foreach(GameObject obj in layers)
//         {
//             loadChildObjects(obj);
//         }
//     }

//     void loadChildObjects(GameObject obj)
//     {
//         float objectWidth = obj.GetComponent<SpriteRenderer>().bounds.size.x - choke;
//         int childsNeeded = (int) Mathf.Ceil(screenBounds.x * 2 / objectWidth);
//         GameObject clone = Instantiate(obj) as GameObject;
//         for (int i = 0; i <= childsNeeded; i++)
//         {
//             GameObject c = Instantiate(clone) as GameObject;
//             c.transform.SetParent(obj.transform);
//             c.transform.position = new Vector3(objectWidth * i, obj.transform.position.y, obj.transform.position.z);
//             c.name = obj.name + 1;
//         }
//         Destroy(clone);
//         Destroy(obj.GetComponent<SpriteRenderer>());
//     }

//     void repositionChildObjects(GameObject obj) 
//     {
//         Transform[] children = obj.GetComponentsInChildren<Transform>();
//         if (children.Length > 1)
//         {
//             GameObject firstChild = children[1].gameObject;
//             GameObject lastChild = children[children.Length - 1].gameObject;
//             float halfObjectWidth = lastChild.GetComponent<SpriteRenderer>().bounds.extents.x - choke;
//             if (transform.position.x + screenBounds.x > lastChild.transform.position.x + halfObjectWidth)
//             {
//                 firstChild.transform.SetAsLastSibling();
//                 firstChild.transform.position = new Vector3(lastChild.transform.position.x + halfObjectWidth * 2, lastChild.transform.position.y, lastChild.transform.position.z);
//             }
//             else if (transform.position.x - screenBounds.x < firstChild.transform.position.x - halfObjectWidth)
//             {
//                 lastChild.transform.SetAsLastSibling();
//                 lastChild.transform.position = new Vector3(firstChild.transform.position.x - halfObjectWidth * 2, firstChild.transform.position.y, firstChild.transform.position.z);
//             }
//         }
//     }

//     void Update()
//     {
//         Vector3 velocity = Vector3.zero;
//         Vector3 desiredPosition = transform.position + new Vector3(scrollSpeed, 0, 0);
//         Vector3 smoothPosition = Vector3.SmoothDamp(transform.position, desiredPosition, ref velocity, 0.3f);
//         transform.position = smoothPosition;
//     }

//     void LateUpdate() 
//     {
//         foreach(GameObject obj in layers)
//         {
//             repositionChildObjects(obj);
//         }
//     }
// }

// Scrap Paper
    // private float length, startpos; // of sprites
    // public GameObject cam;
    // public float parallaxEffect;

    // // Start is called before the first frame update
    // void Start () {
    //     startpos = transform.position.x;
    //     length = GetComponent<SpriteRenderer>().bounds.size.x;
    // }

    // // Update is called once per frame
    // void FixedUpdate()
    // {
    //     // how far we've moved in world space
    //     float dist = (cam.transform.position.x * parallaxEffect);
        
    //     // move the camera
    //     cam.transform.position = new Vector3(startpos + dist, cam.transform.position.y, cam.transform.position.z);

        
    // }
        