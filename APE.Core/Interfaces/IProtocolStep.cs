﻿using APE.Core.Enumerations;
using System.ComponentModel;

namespace APE.Core.Interfaces
{
    public interface IProtocolStep
    {
        /*
         * --------------------------------------------------------------------------------------------------------
         * 
         * --------------------------------------------------------------------------------------------------------
         */
        int Id { get; set; }
        string Name { get; set; }
        string Description { get; set; }
        StatusEnum Status { get; set; }
        ISample Sample { get; set; }


        /*
         * --------------------------------------------------------------------------------------------------------
         * 
         * --------------------------------------------------------------------------------------------------------
         */
    }
}
