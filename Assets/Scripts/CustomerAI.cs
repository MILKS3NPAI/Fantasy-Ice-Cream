using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;


public class CustomerAI : MonoBehaviour
{
    GameObject playerIC;
    public GameObject dialogbox;
    public Text dialogText;
    public bool orderDone;
    bool playerInRange;
    bool enteringShop = true;
    bool moving;
    //Lists
    public List<int> myOrder = new List<int>();
    public List<int> playerOrder = new List<int>();
    //Order Generator
    FlavorValue FV;
    enum FlavorValue { Vanilla = 1, Chocolate, Strawberry};
    public int stackLimit;
    public int stack = 0;
    //display ice cream
    public GameObject TextBubble;
    public GameObject OrderDisplay;
    public GameObject van;
    public GameObject choco;
    public GameObject straw;
    //Animator/movement
    public float moveSpeed = 5f;
    public Animator animator;
    public Rigidbody2D rb;
    public Vector3 target;
    public Vector2 position;
    Vector2 movement;
    //Patience
    public PatienceScript patienceBar;
    public GameObject bar;
    public int maxPatience = 10;
    public float currentPatience;
    public static float score;
    //Customer locations
    bool searching;
    public GameObject[] waitAreas;
    public List<GameObject> validWaitAreas;
    float distanceToTargetx;
    float distanceToTargety;
    float distanceThreshold = 0.1f;

    void Start()
    {
        var obj = Resources.FindObjectsOfTypeAll<GameObject>();
        dialogbox = obj.FirstOrDefault(g => g.CompareTag("IceCreamNotif"));
        dialogText = obj.FirstOrDefault(g => g.CompareTag("Notif")).GetComponent<Text>();
        playerIC = GameObject.FindGameObjectWithTag("IceCreamDisplay");

        stackLimit = Random.Range(1, 5);

        
        waitAreas = GameObject.FindGameObjectsWithTag("Stopper");
        validWaitAreas = new List<GameObject>();
        distanceToTargetx = this.transform.position.x - target.x;
        foreach (GameObject waitArea in waitAreas)
        {
            if (waitArea.GetComponent<Customer_Detect>().customerInRange == false && Mathf.Abs(this.transform.position.x - waitArea.transform.position.x) < 6)
            {
                validWaitAreas.Add(waitArea);
            }
        }

        if (validWaitAreas.Any() == false)
        {
            Debug.Log("destroyed");
            Destroy(gameObject);
        }
        else
        {
            searching = false;
            var rnd = Random.Range(0, validWaitAreas.Count);
            target = validWaitAreas[rnd].transform.position;
        }


        for (int i = 0; i < stackLimit; i++)
        {
            FV = (FlavorValue)Random.Range(1, 4);
            switch (FV)
            {
                case FlavorValue.Vanilla:
                    addToOrder(van);
                    break;
                case FlavorValue.Chocolate:
                    addToOrder(choco);
                    break;
                case FlavorValue.Strawberry:
                    addToOrder(straw);
                    break;

            }
            
        }

        for (int i = 0; i < myOrder.Count; i++)
        {
            
        }
        rb.isKinematic = true;

        currentPatience = maxPatience;
        patienceBar.SetMaxPatience(maxPatience);
        patienceBar.SetPatience(currentPatience);
        TextBubble.SetActive(false);
    }


    void Update()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);


        //Patience Timer
        if (enteringShop != true)
        {
            if (currentPatience > 0)
            {
                currentPatience -= Time.deltaTime;
                patienceBar.SetPatience(currentPatience);
            }
            else
            {
                TextBubble.SetActive(false);
                if (this.transform.position.x < 0)
                {
                    movement.x = -1;
                }
                else
                {
                    movement.x = 1;
                }
            }

        }
        if (orderDone == true)
        {
            bar.SetActive(false);
            TextBubble.SetActive(false);
        }

        //Position Check
        position = gameObject.transform.position;
        distanceToTargetx = this.transform.position.x - target.x;
        distanceToTargety = this.transform.position.y - target.y;
        if (Mathf.Abs(distanceToTargety) >= distanceThreshold)
        {
            if (position.y < target.y && enteringShop == true)
            {
                movement.x = 0;
                movement.y = 1;
            }
            else if (position.y > target.y && enteringShop == true)
            {
                movement.x = 0;
                movement.y = -1;
            }
        }
        else if (Mathf.Abs(distanceToTargetx) >= distanceThreshold)
        {
            if (position.x > target.x && enteringShop == true)
            {
                movement.x = -1;
                movement.y = 0;
            }
            else if (position.x < target.x && enteringShop == true)
            {
                movement.x = 1;
                movement.y = 0;
            }
        }
        else if (enteringShop == true)
        {
            GetComponents<AudioSource>().ElementAt(0).Play();
            movement.x = 0;
            movement.y = 0;
            enteringShop = false;
            TextBubble.SetActive(true);
        }

       
        


        if (Input.GetKeyDown(KeyCode.Space) && playerInRange)
        {
            OrderCheck();
        }
    }


    private void FixedUpdate()
    {

            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    private void OrderCheck()
    {
        playerOrder = playerIC.GetComponent<IceCreamDisplay>().currentOrder;
        if (playerOrder.SequenceEqual(myOrder) == true)
        {
            dialogbox.SetActive(true);
            dialogText.text = "Thank you!";
            playerIC.GetComponent<IceCreamDisplay>().Clear();
            orderDone = true;
            if (this.transform.position.x < 0)
            { 
                movement.x = -1;
            }
            else
            {
                movement.x = 1;
            }
            GetComponents<AudioSource>().ElementAt(1).Play();
            score += (myOrder.Count * 1.8f) * Mathf.Sqrt(currentPatience) * 0.7f;
        }

        else
        {
            dialogbox.SetActive(true);
            dialogText.text = "This isn't my order!";
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
           
        }

        if(collision.CompareTag("Stopper"))
        {
            collision.GetComponent<Customer_Detect>().customerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            dialogbox.SetActive(false);
        }
        if (collision.CompareTag("Stopper") && enteringShop == false)
        {
            collision.GetComponent<Customer_Detect>().customerInRange = false;
        }
    }

    void addToOrder(GameObject x)
    {
        x = Instantiate(x, new Vector2(0, 0), Quaternion.identity);
        x.transform.SetParent(OrderDisplay.transform);
        x.SetActive(true);
        x.transform.localPosition = new Vector2(1, (-9 + (10 * stack)));
        x.GetComponent<Image>().rectTransform.sizeDelta = new Vector2(20, 20);
        x.GetComponent<Image>().transform.localScale = new Vector3(1, 1, 0);
        stack++;
        myOrder.Add((int)FV);
    }
}
