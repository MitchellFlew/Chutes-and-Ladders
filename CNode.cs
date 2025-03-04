/**********************************************************************
 * Project:     Chutes & Ladders
 * File:        Node Class
 * Language:    C#
 * 
 * Description: This is a class representing a player node in a linked list. 
 *              
 *  College:    Husson University
 *  Course:     IT 325
 *  
 *  Edit History
 *  Ver: Who: Date:     Notes
 *  ---  ---  --------   -----------------------------------------------
 *  0.3  MLF  11/19/23  - initial writing 
 *                      - added all functionality for the node
 **********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_05b___Chutes___Ladders
{
    internal class CNode
    {
        #region data
        #endregion data

        #region properties
       
        public string PlayerName { get; set; }   // property to store
                                                 // player name
        public CNode Next { get; set; }          // reference to the next
                                                 // node in the linked list
        #endregion properties

        #region constructors
        public CNode(string playerName)
        {
            // player name for node
            PlayerName = playerName;
            // intialize next node reference to null
            Next = null;
        }
        #endregion constructors

        #region events
        #endregion events

        #region methods
        #endregion methods
    }
}
