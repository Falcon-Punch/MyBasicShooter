using UnityEngine;
using System.Collections.Generic;

public class Main : MonoBehaviour
{
    private enum GameStates
    {
        MainMain,
        Gameplay,
        Pause,
        HighScore
    }

    public static Main Singleton = null;

    [SerializeField] public Player player; // TODO: public?

    // Menu Variables.
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject gameOverScreen;

    // Gameplay Variables.
    [SerializeField] private GameObject gameplay;
    [SerializeField] private Enemy enemyPrefab;
    [SerializeField] private GameObject enemyParent;
    [SerializeField] public GameObject bulletParent;
    [SerializeField] private ScoreBoard scoreBoard;
    [SerializeField] private GameObject starfield; // Star parent.
    [SerializeField] private GameObject starPrefab;

    private List<Enemy> enemies = new List<Enemy>();
    private GameStates currentState = GameStates.MainMain;


    private void Awake()
    {
        // Check if instance already exists.
        if (Singleton == null)
            Singleton = this; // if not, set instance to this.

        // If instance already exists and it's not this:
        else if (Singleton != this)
            Destroy(gameObject);
        // Then destroy this. 
        // This enforces our singleton pattern, 
        // meaning there can only ever be one instance of Main.

        DontDestroyOnLoad(gameObject); // Sets this to not be destroyed when reloading scene.
    }

    private void Start()
    {
        //SpawnEnemy();

        // Loop through and make a randome starfield.
        for (int i = 0; i < 50; i++)
        {
            GameObject star = Instantiate(starPrefab);
            star.transform.SetParent(starfield.transform);

            // TODO: Find the 3D screen bounds to make a starfield.
            float rando_x = Random.Range(-10f, 10f);
            float rando_y = Random.Range(-10f, 10f);
            star.transform.localPosition = new Vector3(rando_x, rando_y, 10);

            float rando_scale = Random.Range(0.1f, 0.4f);
            star.transform.localScale = new Vector3(rando_scale, rando_scale, rando_scale);
        }
    }

    public void BeginGameplay()
    {
        player.Initialize();
        mainMenu.SetActive(false);
        gameplay.gameObject.SetActive(true);
        InvokeRepeating("SpawnEnemy", 1, 2);
        currentState = GameStates.Gameplay;
        Debug.Log("Switch to Gameplay.");
    }

    public void GotoMainMenu()
    {
        gameplay.gameObject.SetActive(false);
        gameOverScreen.SetActive(false);
        mainMenu.SetActive(true);
    }

    public void ExitGame()
    {
        Application.Quit();
    }


    //private void SwitchState(GameStates newState)
    //{
    //    currentState = newState;
    //}

    public void GameOver()
    {
        // What now?
        // Display GameOver screen.
        gameOverScreen.SetActive(true);
        CancelInvoke();
    }

    private void DestroyStars()
    {
        Debug.Log("Destroying Stars.");
        Destroy(starfield);

        //for (int i = 0; i < 5; i++)
        //{
        //    Transform child = starfield.transform.GetChild(i);
        //    Destroy(child.gameObject);
        //}
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            DestroyStars();
    }

    private void SpawnEnemy()
    {
        // Initialization.
        Enemy enemy = Instantiate(enemyPrefab);
        enemy.transform.SetParent(enemyParent.transform);
        //enemy.transform.localPosition = Vector3.zero;
        //enemy.transform.localScale = Vector3.one;
        enemy.gameObject.SetActive(true);
    }

    public void IncreaseScore(int amount)
    {
        scoreBoard.IncreaseScore(amount);
    }
}