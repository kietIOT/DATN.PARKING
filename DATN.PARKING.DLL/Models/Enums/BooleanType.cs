// <copyright file="AlertProcessType.cs" company="TCIS">
// Copyright (c) .  All rights reserved.  Reproduction or transmission in 
// whole or in part, in any form or by any means, electronic, mechanical or 
// otherwise, is prohibited without the prior written consent of the copyright 
// owner.
// </copyright>
//
// <summary>
// </summary>
// <remarks>
// </remarks>
// <history>
// Date         Release         Task            Who         Summary
// ===================================================================================
// 28/05/2013   1.0.0.0                         DVDUOC      Created
// </history>

using System;
using TCIS.TTOS.Commons;

namespace TCIS.TTOS.EDI.DAL.Models
{
    /// <summary>
    /// BooleanType type defines bool values as it storaged in database 
    /// </summary>
    public sealed class BooleanType : StringEnumClass
    {
        /// <summary>
        /// "Y" - Yes
        /// </summary>
        public static readonly BooleanType Yes = new BooleanType("Y");

        /// <summary>
        /// "N" - No
        /// </summary>
        public static readonly BooleanType No = new BooleanType("N");

        /// <summary>
        /// " " - Blank
        /// </summary>
        public static readonly BooleanType Blank = new BooleanType(" ");

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="type"></param>
        private BooleanType(String type)
            : base(type)
        {
        }

        /// <summary>
        /// An extension method to covert the given bool value to a BooleanType value
        /// </summary>
        /// <param name="value"></param>
        public static BooleanType ToBooleanType(bool? value)
        {
            if (value == null)
            {
                return Blank;
            }

            return value == true ? Yes : Blank;

        }

        /// <summary>
        /// Implicit convert an instance of string to Boolean value
        /// </summary>
        /// <param name="value"></param>
        public static implicit operator BooleanType(string value)
        {
            return new BooleanType(value);
        }

        /// <summary>
        /// Implicit convert an instance of BooleanType to bool value
        /// </summary>
        /// <param name="booleanType"></param>
        /// <returns></returns>
        public static implicit operator bool(BooleanType booleanType)
        {
            return booleanType == BooleanType.Yes ? true : false;
        }


        /// <summary>
        /// Implicit convert an instance of bool to BooleanType value
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static implicit operator BooleanType(bool? value)
        {
            if (value == null)
            {
                return Blank;
            }

            return value == true ? Yes : Blank;

        }


    }
}