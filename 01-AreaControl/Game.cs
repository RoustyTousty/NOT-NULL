using System.Collections.Generic;
using System.Threading.Tasks;

class Game {
    private List<List<int>>? Grid { get; set; }
    private bool IsGameRunning { get; set; } = true;
    
    public int GridSize { get; set; }
    public int PlayerCount { get; set; }
    public List<Player> Players { get; set; }

    public Game(int gridSize, int playerCount = 2) 
    {
        GridSize = gridSize;
        PlayerCount = playerCount;

        InitGrid();
        InitPlayers();
        StartRuntime();
    }



    public void InitPlayers() 
    {
        for (int i = 0; i < PlayerCount; i++) {
            Players.Add(new Player(i + 1, $"Player{i + 1}"));
        }
    }


    public void InitGrid()
    {
        Grid = new List<List<int>>();
        for (int i = 0; i < GridSize; i++) {
            Grid.Add(new List<int>());
            for (int j = 0; j < GridSize; j++) {
                Grid[i].Add(0);
            }
        }
    }


    public void UpdateGrid()
    {
        // Seit prosta updato XAML Grid
    }


    public void MakeMove(int x, int y, Player player) 
    {
        // Error handle
        Grid[x][y] = player.Id;
        UpdateGrid();
    }


    public void StartRuntime() 
    {
        if (Grid == null) {
            return;
        }
        
        while (IsGameRunning) {
            // Loop all players un pagaidi kad vini izdara savu move
        }
    }

    public void StopRuntime()
    {
        IsGameRunning = false;
    }




    public void SaveGame() 
    {
        // Save game state to save.txt file
    }

    public void LoadGame() 
    {
        // Load game state from save.txt file
    }
}