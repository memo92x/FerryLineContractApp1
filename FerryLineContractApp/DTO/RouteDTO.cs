﻿using FerryLineContractApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FerryLineContractApp.DTO
{
    /// <summary>
    /// Route object
    /// </summary>
    public class RouteDTO
    {
        /// <summary>
        /// Property for route id
        /// </summary>
        /// <value>
        /// Contains the route's unique id
        /// </value>
        public int RouteId { get; set; }
        /// <summary>
        /// Property for depature
        /// </summary>
        /// <value>
        /// Contains the name of the depature city of the trip
        /// </value>
        public string Depature { get; set; }
        /// <summary>
        /// Property for destination
        /// </summary>
        /// <value>
        /// Contains the name of the destination name of the trip
        /// </value>
        public string Destination { get; set; }
        /// <summary>
        /// Property for duration
        /// </summary>
        /// <value>
        /// Contains duration of the trip i minutes
        /// </value>
        public int Duration { get; set; }

        public virtual List<Route> RouteList { get; set; }
    }
}
