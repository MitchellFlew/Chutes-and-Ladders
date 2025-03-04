/**********************************************************************
 * Project:     Chutes & Ladders
 * File:        Square Class
 * Language:    C#
 * 
 * Description: This file is a class to store the data for square types
 *              for the chutes & ladders game
 *              
 *  College:    Husson University
 *  Course:     IT 325
 *  
 *  Edit History
 *  Ver: Who: Date:     Notes
 *  ---  ---  --------   -----------------------------------------------
 *  0.4  MLF  11/20/23  - initial writing
 *                      - added enumeration types for squares
 *                      - added all code elements 
 **********************************************************************/
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PR_05b___Chutes___Ladders
{
    internal class CSquare
    {
        #region enum
        /// <summary>
        /// Enumeration representing each type of square on the board
        /// </summary>
        public enum SquareType
        {
            Normal,     // nothing happens on square
            Chute,      // represents a square with a chute
            Ladder      // represents a square with a ladder
        }
        #endregion enum 

        #region data
        #endregion data

        #region properties
        public int Number { get; set; }     // number assigned to a square

        public SquareType Type { get; set;} // type of square

        public int TargetSquare { get; set; }   // player's destination
                                                // once the roll happens
                                                // and condition is resolved
                                                // (i.e., land on 1, go to 38)

        #endregion properties

        #region constructors
        /// <summary>
        /// Constructor to initialize a square with number and type
        /// </summary>
        /// <param name="number"></param>
        /// <param name="type"></param>
        public CSquare(int number, SquareType type, int targetSquare)
        {
            Number = number; 
            Type = type;
            TargetSquare = targetSquare;
        }
        #endregion constructors

        #region events
        #endregion events

        #region methods
        #endregion methods
    }
    }
