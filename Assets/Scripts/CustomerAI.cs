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
    //lists
    public List<int> myOrder = new List<int>();
    public List<int> playerOrder = new List<int>();
    //Order Generator
    int FV;
    public int stackLimit;
    //Animator
    public float moveSpeed = 5f;
    public Animator animator;
    public Rigidbody2D rb;
    public Vector2 target;
    public Vector2 position;
    Vector2 movement;



    void Start()
    {
        
        playerIC = GameObject.FindGameObjectWithTag("IceCreamDisplay");
        stackLimit = Random.Range(1, 6);
        target = new Vector2(-5.5f, 0f);
        

        for (int i = 0; i < stackLimit; i++)
        {
            FV = Random.Range(1, 4);
            myOrder.Add(FV);
        }
        rb.isKinematic = true;
    }

    
    void Update()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("speed", movement.sqrMagnitude);



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
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            dialogbox.SetActive(false);
        }
    }

}
