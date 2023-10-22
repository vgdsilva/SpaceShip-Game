using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerShipController : StarshipsController
{
    [Header("Player Life System")]
    public Text healthText;
    public Image healthBar;

    Vector2 ShipMovement;
    Rigidbody2D _shipRigidbody2D;

    private Camera mainCamera;

    void Start()
    {
        //_shipRigidbody2D = GetComponent<Rigidbody2D>();
        mainCamera = Camera.main;
    }

    void Update()
    {
        //healthBarFiller();
        //if ( ShipLife <= 0 )
        //{
        //    Destroy(transform.gameObject);
        //    return;
        //}

        //HandleShipMovement();
        MoveShipCommand();
        //HandleLaserShooting();
    }

    void MoveShipCommand()
    {
        // Capturar a entrada do teclado ou do controle para o movimento
        float horizontalInput = 0f/*Input.GetAxis("Horizontal")*/;
        float verticalInput = Input.GetAxis("Vertical");

        // Calcular o vetor de movimento a partir da entrada
        Vector3 moveDirection = new Vector3(horizontalInput, verticalInput, 0);
        moveDirection.Normalize();

        // Calcular a posição do mouse na tela
        Vector3 mousePosition = Input.mousePosition;

        // Converter a posição do mouse para um ponto no espaço 2D da Unity
        Vector3 worldMousePosition = mainCamera.ScreenToWorldPoint(new Vector3(mousePosition.x, mousePosition.y, 0f));

        // Calcular a direção da nave em relação à posição do mouse
        Vector3 direction = worldMousePosition - transform.position;
        direction.z = 0;
        direction.Normalize();

        // Rotacionar a nave para olhar na direção do mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg - 90.0f;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angle));

        // Mover a nave na direção especificada pela entrada
        transform.Translate(moveDirection * ShipVelocity * Time.deltaTime);
    }

    void healthBarFiller()
    {
        healthText.text = $"{ShipLife}%";
        healthBar.fillAmount = ShipLife / maxHealth;

        if (ShipLife <= 20 )
        {
            healthBar.color = Color.red;
            healthText.color = Color.red;
        }
    }

    public override void HandleShipMovement()
    {
        ShipMovement = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        _shipRigidbody2D.velocity = ShipMovement.normalized * ShipVelocity ;
    }

    public override void HandleLaserShooting()
    {
        if ( Input.GetButtonDown("Jump") )
        {
            Instantiate(ShipLaser, GunRight.position, GunRight.rotation);
            Instantiate(ShipLaser, GunLeft.position, GunLeft.rotation);
        }
    }

    
}
