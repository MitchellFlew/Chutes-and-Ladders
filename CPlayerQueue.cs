/**********************************************************************
 * Project:     Chutes and Ladders
 * File:        Player Queue Class
 * Language:    C#
 * 
 * Description: This file implements a player queue for the players in 
 *              a game of chutes and ladders. 
 *              
 *  College:    Husson University
 *  Course:     IT 325
 *  
 *  Edit History
 *  Ver: Who: Date:     Notes
 *  ---  ---  --------   -----------------------------------------------
 *  0.2  MLF  11/18/23  - initial writing
 *  0.3  MLF  11/19/23  - added properties to check if the queue is full 
 *                        or empty
 *                      - added Enqueue & Dequeue logic
 *  0.5  MLF  11/21/23  - added GetNodeAtIndex & Peek methods
 *  0.6  MLF  11/22/23  - added error trapping to Dequeue method
 **********************************************************************/
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_05b___Chutes___Ladders
{
    internal class CPlayerQueue : IEnumerable<string>
    {
        #region data
        // maximum number of players allowed in the queue
        private int maxPlayers;
        private string[] players; // internal array to store player names
                                  // initialize player position arrays with zeros
        
        #endregion data

        #region properties
        private CNode Front { get; set; }   // front of queue
        private CNode Back { get; set; }    // back of queue

        public int Count { get; private set; } // # of items in queue
        /// <summary>
        /// Property to check if the queue is empty
        /// </summary>
        public bool IsEmpty
        {
            get { return Front == null;}
        }
        /// <summary>
        /// This property checks if the queue is full
        /// </summary>
        public bool IsFull
        {
            get { return Count >= maxPlayers; }
        }
        #endregion properties

        #region constructor
        /// <summary>
        /// Initializes the array and sets maximum players.
        /// Throws an error if player count is less than 2 or 
        /// greater than six. 
        /// </summary>
        /// <param name="maxPlayers">maximum players allowed in queue</param>
        public CPlayerQueue(int maxPlayers)
        {
            // initialize the players array 
            players = new string[maxPlayers];
            // validate the number of players is between 2 and six
            if (maxPlayers < 2 || maxPlayers > 6)
            {
                throw new ArgumentException
                ("Number of players must be between 2 and 6");
            }
            // set maxmimum player limit
            this.maxPlayers = maxPlayers;
            // initialize front and back pointers
            Front = null; ;
            Back = null;
            // initialize player count to zero
            Count = 0;   
        }

        #endregion constructor

        #region events
        #endregion events.

        #region methods
        /// <summary>
        /// This method removes a player from the queue (game)
        /// </summary>
        /// <returns></returns>
        public string Dequeue()
        {
            try
            {
                string dequeuedPlayer; // stores name of the dequeued player

                // empty queue, throw an error
                if (IsEmpty)
                {
                    throw new InvalidOperationException
                       ("Queue is empty. No players to dequeue.");
                }
                // get the first player in the array
                dequeuedPlayer = Front.PlayerName;
                // move the front pointer to the next item
                Front = Front.Next;
                // decrememnt the count
                Count--;

                // return the dequeued player
                return dequeuedPlayer;
            }
            catch (Exception)
            {
                // throw an error if dequeue fails
                throw new InvalidOperationException
                    ("Dequeue failed");  
            }
          
        }
        /// <summary>
        /// Method to add a player to the queue
        /// </summary>
        /// <param name="player">The name of the player to be added</param>
        public void Enqueue(string playerName)
        {
            // if queue is full, throw an error
            if (IsFull)
            {
                throw new InvalidOperationException
                    ("Queue is full. Maximum player limit reached");
            }

            // create a new node for the new player
            CNode newNode = new CNode(playerName);
            // if queue is empty, set back and front to the new node
            if (IsEmpty)
            {
                Front = newNode;
                Back = newNode; 
            }
            else
            {
                 // add new node to the back of the queue and update
                 // the back pointer
                 Back.Next = newNode;
                 Back = newNode;
                 newNode.Next = null;  
            }
            // increment player count
            Count++;
        }
        /// <summary>
        /// This method helps get the node at a specific index in the queue 
        /// </summary>
        /// <param name="index"></param>
        /// <returns></returns>
        public CNode GetNodeAtIndex(int index)
        {
            if (index < 0 || index >= Count || IsEmpty)
            {
                // show error message to the user
                // if the index is out of range
                throw new IndexOutOfRangeException
                    ("Index is out of range");
            }
            // start at the front of the queue
            CNode current = Front;
            // walk down the queue until the index is reached
            for (int i = 0; i < index; i++)
            {
                current = current.Next;
            }
            return current;
        }
        /// <summary>
        /// Retrieves the first node in the queue without removing it
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException"></exception>
        public CNode Peek()
        {
            // if queue is empty, throw an error
            if (IsEmpty)
            {
                throw new InvalidOperationException
                    ("Queue is empty. No players to peek.");
            }
            // return the front node
            return Front;
        }   
        #endregion methods

        #region IEnumerable
        /// <summary>
        /// This method allows for the traversal of the queue
        /// from front to back, sending each element to the 
        /// calling method.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<String> GetEnumerator()
        {
            // start at the front of the queue
            CNode current = Front;

            // walk down the queue, send one item at a time
            while (current != null)
            {
                yield return current.PlayerName;
                current = current.Next;
            }

        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
        #endregion IEnumberable
    }
}
