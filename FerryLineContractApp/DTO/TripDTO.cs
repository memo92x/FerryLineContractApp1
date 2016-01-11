using FerryLineContractApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace FerryLineContractApp.DTO
{
    /// <summary>
    /// Trip object
    /// </summary>
    public class TripDTO
    {
        /// <summary>
        /// Property for trip id
        /// </summary>
        /// <value>
        /// Contains the trips unique id
        /// </value>
        public int TripId { get; set; }
        /// <summary>
        /// Property for depature time
        /// </summary>
        /// <value>
        /// Contains time of depature for the trip
        /// </value>
        public DateTime DepatureTime { get; set; }
        /// <summary>
        /// Property for route id
        /// </summary>
        /// <value>
        /// Contains id of the route of the trip
        /// </value>
        public int RouteId { get; set; }
        /// <summary>
        /// Property for ferry id
        /// </summary>
        /// <value>
        /// Contains the id of the ferry, sailing the route for the trip
        /// </value>
        public int FerryId { get; set; }
        /// <summary>
        /// Property for the trip price
        /// </summary>
        /// <value>
        /// Contains price for the trip
        /// </value>
        public double TripPrice { get; set; }

        public virtual List<Trip> TripList { get; set; }
    }
}
