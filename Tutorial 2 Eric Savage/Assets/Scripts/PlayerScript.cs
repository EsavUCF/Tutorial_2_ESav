using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PlayerScript : MonoBehaviour
{
      private Rigidbody2D rd2d;

    public float speed;
    public Text score;
    public Text Life;
  public AudioClip musicClipOne;
  public AudioSource musicSource;
    public Text GameOverText;
    Animator anim;
    private bool facingRight = true;
  private int livesText = 3;
    private int scoreValue = 0;
    // Start is called before the first frame update
    void Start()
    {
      
       
        rd2d = GetComponent<Rigidbody2D>();
         anim = GetComponent<Animator>();
        score.text = scoreValue.ToString();
        GameOverText.text = "";
        Life.text = livesText.ToString();
   
   
    
    }


    // Start is called before the first frame update
    

    // Update is called once per frame
    
    
    void FixedUpdate()
    
    {
     
      float hozMovement = Input.GetAxis("Horizontal");
        float vertMovement = Input.GetAxis("Vertical");
       rd2d.AddForce(new Vector2(hozMovement * speed, vertMovement * speed)); 
    if (facingRight == false && hozMovement > 0)
   {
     Flip();
   }
else if (facingRight == true && hozMovement < 0)
   {
     Flip();
   }

    }
void Update()
{
if (Input.GetKeyDown(KeyCode.D))
{
  anim.SetInteger("State", 1);
}
if (Input.GetKeyUp(KeyCode.D))
{
  anim.SetInteger("State", 0);
}
if (Input.GetKeyDown(KeyCode.A))
{
  anim.SetInteger("State", 1);
}
if (Input.GetKeyUp(KeyCode.A))
{
  anim.SetInteger("State", 0);
}


}
  
private void OnCollisionEnter2D(Collision2D collision) 
{
  if (collision.collider.tag == "Coin")
        {
          scoreValue += 1;
            score.text = scoreValue.ToString();
           Destroy(collision.collider.gameObject);
if (scoreValue ==4)
{livesText = 3;
SetLivesText();
transform.position = new Vector2 (44.0f, 0.0f);
}
   
        
        
        }
if (collision.collider.tag == "Enemy")
            {livesText -= 1;
            Life.text = livesText.ToString();
           Destroy(collision.collider.gameObject);
}
if (livesText ==0)
{GameOverText.text = "You lose! Game by Eric Savage";
}
{
  if (scoreValue >=8)
GameOverText.text = "You Win! Game by Eric Savage";
}
{if (scoreValue ==8)
{ musicSource.clip = musicClipOne;
  musicSource.Play();}
        }

    }



    
private void OnCollisionStay2D(Collision2D collision) 
{
   if (collision.collider.tag == "Ground") 
   {
if(Input.GetKey(KeyCode.W)) 
{
rd2d.AddForce(new Vector2(0, 3), ForceMode2D.Impulse);

}
   }
if (Input.GetKey("escape"))
{Application.Quit();}
}

void SetLivesText()
{
  Life.text =livesText.ToString();
if (livesText ==0)
{GameOverText.text = "You lose! Game by Eric Savage";
}
} 

void Flip()
   {
     facingRight = !facingRight;
     Vector2 Scaler = transform.localScale;
     Scaler.x = Scaler.x * -1;
     transform.localScale = Scaler;
   }

} 
