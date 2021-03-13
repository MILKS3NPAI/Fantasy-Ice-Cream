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
    bool playerInRange;
    bool orderDone;
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
    public Vector2 target;
    public Vector2 position;
    Vector2 movement;
    //Patience
    public PatienceScript patienceBar;
    public GameObject bar;
    public int maxPatience = 30;
    public float currentPatience;


    void Start()
    {
        playerIC = GameObject.FindGameObjectWithTag("IceCreamDisplay");
        stackLimit = Random.Range(1, 6);
        target = new Vector2(-5.5f, 0f);
        

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
                movement.x = 1;
                TextBubble.SetActive(false);
            }
           
        }
        if (orderDone == true)
        {
            bar.SetActive(false);
            TextBubble.SetActive(false);
        }

        //Position Check
        position = gameObject.transform.position;
        if (position.x > target.x && enteringShop == true)
        {
            movement.x = -1;
        }
        else if (enteringShop == true)
        {
            movement.x = 0;
            enteringShop = false;
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
            movement.x = 1;
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

        if (collision.CompareTag("Stopper") && enteringShop == true)
        {
            movement.x = 0;
            movement.y = 0;
            enteringShop = false;
            TextBubble.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            dialogbox.SetActive(false);
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
