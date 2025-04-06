using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;


public class TicTacToeManager : MonoBehaviour
{
    public Button[] buttons;          // 9 buttons representing the grid
    public TMP_Text resultText;           // Text object to show win/draw messages
    private string currentPlayer = "X";
    private string[] board = new string[9];
    private bool gameOver = false;
    private int[][] winConditions = new int[][]
{
    new int[] {0,1,2}, new int[] {3,4,5}, new int[] {6,7,8},  // Rows
    new int[] {0,3,6}, new int[] {1,4,7}, new int[] {2,5,8},  // Columns
    new int[] {0,4,8}, new int[] {2,4,6}                      // Diagonals
};

    void Start()
    {
        ResetGame();
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = ""; 
        }
        Debug.Log($" at index 1: [{board[1]}], Current Player: {currentPlayer}");
        Debug.Log("Board State: " + string.Join(", ", board));
    }

    public void MakeMove(int index)
    {
        if (board[index] != null && board[index].Equals("") && !gameOver)
        {
            board[index] = currentPlayer;
            buttons[index].GetComponentInChildren<TMP_Text>().text = currentPlayer;
            buttons[index].interactable = false;
            Debug.Log($"MakeMove called for index {index}, Current Player: {currentPlayer}");

            if (CheckWinner())
            {
                resultText.text = $"{currentPlayer} Wins!";  
                gameOver = true;
            }
            else if (IsDraw())
            {
                resultText.text = "It's a Draw!";
                gameOver = true;
            }
            else
            {
                currentPlayer = (currentPlayer.Equals("X")) ? "O" : "X";
                Debug.Log($"Toggled Player: {currentPlayer}");
            }
        }
    }

    private bool CheckWinner()
    {
        foreach (var condition in winConditions)
        {
            int a = condition[0];
            int b = condition[1];
            int c = condition[2];

            if (!board[a].Equals("") && board[a] == board[b] && board[b] == board[c])
            {
                HighlightWinningButtons(a, b, c);  
                return true;
            }
        }
        return false;
    }

    private bool IsDraw()
    {
        foreach (var spot in board)
        {
            if (spot.Equals("")) return false;
        }
        return true;
    }

    public void ResetGame()
    {
        currentPlayer = "X";
        for (int i = 0; i < board.Length; i++)
        {
            board[i] = "";
        }
        gameOver = false;
        resultText.text = "";

        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].interactable = true;

            TMP_Text buttonText = buttons[i].GetComponentInChildren<TMP_Text>();
            if (buttonText != null)
                buttonText.text = "";

            buttons[i].GetComponent<Image>().color = Color.white;
        }
    }
    private void HighlightWinningButtons(int a, int b, int c)
    {
        Color winColor = Color.green;

        buttons[a].GetComponent<Image>().color = winColor;
        buttons[b].GetComponent<Image>().color = winColor;
        buttons[c].GetComponent<Image>().color = winColor;
    }
}