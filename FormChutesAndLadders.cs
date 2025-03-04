/**********************************************************************
 * Project:     Chutes & Ladders
 * File:        Main Form
 * Language:    C#
 * 
 * Description: This form is the main form for the gameplay and menu
 *              for the chutes & ladders game.
 *              
 *  College:    Husson University
 *  Course:     IT 325
 *  
 *  Edit History
 *  Ver: Who: Date:     Notes
 *  ---  ---  --------   -----------------------------------------------
 *  0.1  MLF  11/15/23  - initial writing
 *                      - added menu strip & functionality for exit on 
 *                        the menu bar.
 *                      - added functionality to the Game Instructions 
 *                        part of the menu bar. 
 *                      - UI design
 * 0.2  MLF   11/18/23  - added image of game board programmatically 
 *                        to the form. 
 * 0.3  MLF   11/19/23  - added method to simulate a dice roll RollDice()
 * 0.5  MLF   11/21/23  - added a ComboBox to the UI for user input of a
 *                        player amount
 *                      - added functionality to the turn button. 
 *                      - implemented a win condition
 * 0.6  MLF   11/22/23  - changed turnLog from a list to an array
 *                        (the way I have it isn't very dynamic)
 **********************************************************************/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PR_05b___Chutes___Ladders
{
    public partial class FormChutesAndLadders : Form
    {
        #region data
        private CSquare[] board;    // declares the board array
        private CPlayerQueue playerQueue;  // queue to manage player's turns
                                           // and order
                                           
        private string[] turnLog = new string[10000]; // array to store turn log
        private int[] playerPositions;  // array to store player positions
        private int currentPosition = 0;   // starting point on the board
        private int currentPlayerIndex = 0; // index for the current player
        private bool playerSelected = false; // bool to check if player is selected
        #endregion data

        #region properties

        #endregion properties

        #region constructor
        public FormChutesAndLadders()
        {
            InitializeComponent();
            InitializeGame();
        }


        #endregion constructor

        #region events
        /// <summary>
        /// This event handles the button click functionality
        /// to simulate a turn in chutes & ladders. A player in enqueued,
        /// rolls the dice, goes x amount of spaces, does special
        /// functionality (going up a ladder or down a chute), then dequeues
        /// that player and enqueues the next player. 
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void buttonTurn_Click(object sender, EventArgs e)
        { 
            if (playerQueue.IsEmpty)
            {
                MessageBox.Show("Game Over");
                return; 
            }

            // get the current player from the queue based on the currentPlayerIndex
            CNode currentPlayerNode = playerQueue.GetNodeAtIndex(currentPlayerIndex);
            // get the current player's name
            string playerName = currentPlayerNode.PlayerName;
            // get the dice roll result
            int diceResult = RollDice();
            // move the token on the board
            int newPosition = MoveToken(playerName, diceResult);
            // update the player position array
            playerPositions[currentPlayerIndex] = newPosition;
            // find the first empty index in the turn log array
            int turnLogIndex = Array.IndexOf(turnLog, null);
            // update the turn log
            turnLog[turnLogIndex] = $"{playerName} rolled {diceResult} and moved to {newPosition}";
            // display the turn log
            DisplayTurnLog();
            if (newPosition == 100)
            {
                 MessageBox.Show
                    (Text = $"{playerName} wins!");
                    MessageBox.Show("Click File > New Game to play again");
            }
            else if (newPosition > 100)
            {
                // reset the player position to previous position before the roll
                playerPositions[currentPlayerIndex] = currentPosition;
                // user stays on the same square until next turn
                MessageBox.Show($"{playerName} rolled {diceResult} and stays on {currentPosition}");
            }

            // increment the current player index
            currentPlayerIndex++;
           // if the current player index is greater than the player queue count
           // reset the current player index to 0
           if (currentPlayerIndex >= playerQueue.Count)
            {
                currentPlayerIndex = 0;
            }
        }
        /// <summary>
        /// This event allows user to dynamically choose between two
        /// and six players before starting a game of chutes & ladders
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void comboBoxPlayers_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Retrieve the selected number of players from the ComboBox
            int selectedNumberOfPlayers = Convert.ToInt32(comboBoxPlayers.SelectedItem);
            // Call the method to initialize the player queue with the selected number of players
            InitializePlayerQueue(selectedNumberOfPlayers);
            // enable comboBox by default
            comboBoxPlayers.Enabled = true;
            // disable comboBox after player is selected
            comboBoxPlayers.Enabled = false;
        }
        /// <summary>
        /// Closes the game when the user clicks "eXit"
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void eXitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // close the game
            this.Close();
        }

        /// <summary>
        /// Shows a message box to select a player amount at the start
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FormChutesAndLadders_Load(object sender, EventArgs e)
        {
            MessageBox.Show("Select between 2 - 6 players to get started");
            // enable the ComboBox only if the player has not been selected
            if (!playerSelected)
            {
                comboBoxPlayers.Enabled = true;
            }

        }
        /// <summary>
        /// This event shows the user the instructions for Chutes & Ladders when 
        /// the user clicks "Help" > "Game Instructions".
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gameInstructionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            // create a new instance of FormGameInstructions
            using (var gameInstructionsForm = new FormGameInstructions())
            {
                // show the game instructions as dialog. 
                gameInstructionsForm.ShowDialog();
            }
        }

        /// <summary>
        /// This event when clicked will restart the chutes and ladders game. 
        /// File > New Game
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void newGameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            InitializeGame();
        }
        #endregion events.

        #region methods
        /// <summary>
        /// This method displays the turn data in a turn log listBox
        /// </summary>
        private void DisplayTurnLog()
        {
            // clear the list box
            listBoxTurnLog.Items.Clear();
           // loop through the turn log array (most recent to least recent)
           for (int index = turnLog.Length - 1; index >= 0; index--)
            {
                // check if the turn log is not null
                if (turnLog[index] != null)
                {
                    // add the turn log to the list box
                    listBoxTurnLog.Items.Add(turnLog[index]);
                }
              } 
        }
       /// <summary>
       /// This method initializes the game board with chute and ladder 
       /// configuration. 
       /// </summary>
        private void InitializeBoard()
        {
            // initialize the game board
            board = new CSquare[101];
            // initialize the first square
            board[0] = new CSquare(0, CSquare.SquareType.Normal, 0);
            // initialize the rest of the squares
            board[1] = new CSquare(1, CSquare.SquareType.Ladder, 38);
            board[2] = new CSquare(2, CSquare.SquareType.Normal, 2);
            board[3] = new CSquare(3, CSquare.SquareType.Normal, 3);
            board[4] = new CSquare(4, CSquare.SquareType.Ladder, 14);
            board[5] = new CSquare(5, CSquare.SquareType.Normal, 5);
            board[6] = new CSquare(6, CSquare.SquareType.Normal, 6);
            board[7] = new CSquare(7, CSquare.SquareType.Normal, 7);
            board[8] = new CSquare(8, CSquare.SquareType.Normal, 8);
            board[9] = new CSquare(9, CSquare.SquareType.Ladder, 31);
            board[10] = new CSquare(10, CSquare.SquareType.Normal, 10);
            board[11] = new CSquare(11, CSquare.SquareType.Normal, 11);
            board[12] = new CSquare(12, CSquare.SquareType.Normal, 12);
            board[13] = new CSquare(13, CSquare.SquareType.Normal, 13);
            board[14] = new CSquare(14, CSquare.SquareType.Normal, 14);
            board[15] = new CSquare(15, CSquare.SquareType.Normal, 15);
            board[16] = new CSquare(16, CSquare.SquareType.Chute, 6);
            board[17] = new CSquare(17, CSquare.SquareType.Normal, 17);
            board[18] = new CSquare(18, CSquare.SquareType.Normal, 18);
            board[19] = new CSquare(19, CSquare.SquareType.Normal, 19);
            board[20] = new CSquare(20, CSquare.SquareType.Normal, 20);
            board[21] = new CSquare(21, CSquare.SquareType.Ladder, 42);
            board[22] = new CSquare(22, CSquare.SquareType.Normal, 22);
            board[23] = new CSquare(23, CSquare.SquareType.Normal, 23);
            board[24] = new CSquare(24, CSquare.SquareType.Normal, 24);
            board[25] = new CSquare(25, CSquare.SquareType.Normal, 25);
            board[26] = new CSquare(26, CSquare.SquareType.Normal, 26);
            board[27] = new CSquare(27, CSquare.SquareType.Normal, 27);
            board[28] = new CSquare(28, CSquare.SquareType.Ladder, 84);
            board[29] = new CSquare(29, CSquare.SquareType.Normal, 29);
            board[30] = new CSquare(30, CSquare.SquareType.Normal, 30);
            board[31] = new CSquare(31, CSquare.SquareType.Normal, 31);
            board[32] = new CSquare(32, CSquare.SquareType.Normal, 32);
            board[33] = new CSquare(33, CSquare.SquareType.Normal, 33);
            board[34] = new CSquare(34, CSquare.SquareType.Normal, 34);
            board[35] = new CSquare(35, CSquare.SquareType.Normal, 35);
            board[36] = new CSquare(36, CSquare.SquareType.Ladder, 44);
            board[37] = new CSquare(37, CSquare.SquareType.Normal, 37);
            board[38] = new CSquare(38, CSquare.SquareType.Normal, 38);
            board[39] = new CSquare(39, CSquare.SquareType.Normal, 39);
            board[40] = new CSquare(40, CSquare.SquareType.Normal, 40);
            board[41] = new CSquare(41, CSquare.SquareType.Normal, 41);
            board[42] = new CSquare(42, CSquare.SquareType.Normal, 42);
            board[43] = new CSquare(43, CSquare.SquareType.Normal, 43);
            board[44] = new CSquare(44, CSquare.SquareType.Normal, 44);
            board[45] = new CSquare(45, CSquare.SquareType.Normal, 45);
            board[46] = new CSquare(46, CSquare.SquareType.Normal, 46);
            board[47] = new CSquare(47, CSquare.SquareType.Chute, 26);
            board[48] = new CSquare(48, CSquare.SquareType.Normal, 48);
            board[49] = new CSquare(49, CSquare.SquareType.Chute, 11);
            board[50] = new CSquare(50, CSquare.SquareType.Normal, 50);
            board[51] = new CSquare(51, CSquare.SquareType.Ladder, 67);
            board[52] = new CSquare(52, CSquare.SquareType.Normal, 52);
            board[53] = new CSquare(53, CSquare.SquareType.Normal, 53);
            board[54] = new CSquare(54, CSquare.SquareType.Normal, 54);
            board[55] = new CSquare(55, CSquare.SquareType.Normal, 55);
            board[56] = new CSquare(56, CSquare.SquareType.Chute, 53);
            board[57] = new CSquare(57, CSquare.SquareType.Normal, 57);
            board[58] = new CSquare(58, CSquare.SquareType.Normal, 58);
            board[59] = new CSquare(59, CSquare.SquareType.Normal, 59);
            board[60] = new CSquare(60, CSquare.SquareType.Normal, 60);
            board[61] = new CSquare(61, CSquare.SquareType.Normal, 61);
            board[62] = new CSquare(62, CSquare.SquareType.Chute, 19);
            board[63] = new CSquare(63, CSquare.SquareType.Normal, 63);
            board[64] = new CSquare(64, CSquare.SquareType.Chute, 60);
            board[65] = new CSquare(65, CSquare.SquareType.Normal, 65);
            board[66] = new CSquare(66, CSquare.SquareType.Normal, 66);
            board[67] = new CSquare(67, CSquare.SquareType.Normal, 67);
            board[68] = new CSquare(68, CSquare.SquareType.Normal, 68);
            board[69] = new CSquare(69, CSquare.SquareType.Normal, 69);
            board[70] = new CSquare(70, CSquare.SquareType.Normal, 70);
            board[71] = new CSquare(71, CSquare.SquareType.Ladder, 91);
            board[72] = new CSquare(72, CSquare.SquareType.Normal, 72);
            board[73] = new CSquare(73, CSquare.SquareType.Normal, 73);
            board[74] = new CSquare(74, CSquare.SquareType.Normal, 74);
            board[75] = new CSquare(75, CSquare.SquareType.Normal, 75);
            board[76] = new CSquare(76, CSquare.SquareType.Normal, 76);
            board[77] = new CSquare(77, CSquare.SquareType.Normal, 77);
            board[78] = new CSquare(78, CSquare.SquareType.Normal, 78);
            board[79] = new CSquare(79, CSquare.SquareType.Normal, 79);
            board[80] = new CSquare(80, CSquare.SquareType.Ladder, 100);
            board[81] = new CSquare(81, CSquare.SquareType.Normal, 81);
            board[82] = new CSquare(82, CSquare.SquareType.Normal, 82);
            board[83] = new CSquare(83, CSquare.SquareType.Normal, 83);
            board[84] = new CSquare(84, CSquare.SquareType.Normal, 84);
            board[85] = new CSquare(85, CSquare.SquareType.Normal, 85);
            board[86] = new CSquare(86, CSquare.SquareType.Normal, 86);
            board[87] = new CSquare(87, CSquare.SquareType.Chute, 24);
            board[88] = new CSquare(88, CSquare.SquareType.Normal, 88);
            board[89] = new CSquare(89, CSquare.SquareType.Normal, 89);
            board[90] = new CSquare(90, CSquare.SquareType.Normal, 90);
            board[91] = new CSquare(91, CSquare.SquareType.Normal, 91);
            board[92] = new CSquare(92, CSquare.SquareType.Normal, 92);
            board[93] = new CSquare(93, CSquare.SquareType.Chute, 73);
            board[94] = new CSquare(94, CSquare.SquareType.Normal, 94);
            board[95] = new CSquare(95, CSquare.SquareType.Chute, 75);
            board[96] = new CSquare(96, CSquare.SquareType.Normal, 96);
            board[97] = new CSquare(97, CSquare.SquareType.Normal, 97);
            board[98] = new CSquare(98, CSquare.SquareType.Chute, 78);
            board[99] = new CSquare(99, CSquare.SquareType.Normal, 99);
            board[100] = new CSquare(100, CSquare.SquareType.Normal, 100);
        }
        /// <summary>
        /// This method initializes the game board and player queue
        /// </summary>
        private void InitializeGame()
        {
            // initialize turn log
            turnLog = new string[10000];
            // clear the turn log list box
            listBoxTurnLog.Items.Clear();
            // initialize the game board
            InitializeBoard();
            // initialize the player queue
            InitializePlayerQueue(6);
            // initialize the player positions
            InitializePlayerPositions();
            // initialize the player combo box
            InitializePlayerComboBox();
            // when the user restarts the game, enable the combo box
            comboBoxPlayers.Enabled = true;
            // reset the current player index
            currentPlayerIndex = 0;
            // reset the current position
            currentPosition = 0;
            // initialize the turn log
            DisplayTurnLog();
        }
           
        /// <summary>
        /// This method initializes the ComboBox with player count options 
        /// Sets the default player amount to two. 
        /// </summary>
        private void InitializePlayerComboBox()
        {
            // clear the combo box
            comboBoxPlayers.Items.Clear();
            // initialize combobox with player count options 
            comboBoxPlayers.Items.AddRange(new object[] { 2, 3, 4, 5, 6 });
            // default amount of players is 2
            comboBoxPlayers.SelectedIndex = 2;
        }
        /// <summary>
        /// This method initializes the position of the players on the board
        /// </summary>
        private void InitializePlayerPositions()
        {
            // initialize the player positions
            playerPositions = new int[playerQueue.Count];
            for (int index = 0; index < playerQueue.Count; index++)
            {
                playerPositions[index] = 0;
            }
        }
        /// <summary>
        /// This method initializes the player queue with the 
        /// specifed number of players 
        /// </summary>
        private void InitializePlayerQueue(int playerAmount)
        {
            // initializes the player queue with specified player amount
            playerQueue = new CPlayerQueue(playerAmount);
            // add each player to the queue
            for (int index = 1; index <= playerAmount; index++)
            {
                playerQueue.Enqueue($"Player {index}");
            }
        }
        /// <summary>
        /// Move the player's token on the board based on the dice result. 
        /// </summary>
        /// <param name="playerName">Name of the player</param>
        /// <param name="diceResult">Result of the dice roll</param>
        /// <returns>New position of the player on the board</returns>
        private int MoveToken(string playerName, int diceResult)
        { 
            // get the current player's position
           int currentPosition = playerPositions[currentPlayerIndex];
           // calculate the new position
           int newPosition = currentPosition + diceResult;
            // check if the new position exceeds 100
            if (newPosition > 100)
            {
                // calculate the difference between the new position and 100
                int difference = newPosition - 100;
                // calculate the new position
                newPosition = 100 - difference;
            }
            // get the square type
            CSquare.SquareType squareType = board[newPosition].Type;
            // check if the square type is a chute or ladder
            if (squareType == CSquare.SquareType.Chute || squareType == CSquare.SquareType.Ladder)
            {
                // update the new position to the target square
                newPosition = board[newPosition].TargetSquare;
            }
            // return the new position
            return newPosition;
        }
        /// <summary>
        /// Simulates rolling a six-sided die and returns the result.
        /// </summary>
        /// <returns>an integer representing the result of the die roll</returns>
        private int RollDice()
        {
            // create a random number generator
            Random rng = new Random();
            // generate a random number between 1 - 7
            // simulates a six-sided die roll
            int result = rng.Next(1, 7);

            // return dice roll
            return result;
        }

        #endregion methods

        
    }
}
