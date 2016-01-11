using FerryLineContractApp.Contract;
using FerryLineContractApp.DTO;
using FerryLineContractApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;

namespace FerryLineContractApp.Repository
{
    public class AdminstrationManager :  AdminstrationContract  // ontroller can be added here
    {
        FerryLineModelContext db = new FerryLineModelContext();
        //AdminstrationManager repository = new AdminstrationManager();

        public List<Models.Customer> GetAllCustomer()
        {
            var CustomerList = db.Customers.ToList();
            return CustomerList;
        }

        public Models.Customer CreateCustomer(CustomerDTO customerDTO)
        {
            var customer = new Customer
            {
                Firstname = customerDTO.Firstname,
                Lastname = customerDTO.Lastname,
                Phone = customerDTO.Phone,
                Mail = customerDTO.Mail,
                Street = customerDTO.Street,
                HouseNumber = customerDTO.HouseNumber,
                PostalCode = customerDTO.PostalCode,
                City = customerDTO.City,
                Native = customerDTO.Native,
                AmountOfFreeRides = customerDTO.AmountOfFreeRides,
            };

            return customer;
        }

        // Controller, 

        //public void CreateCustomers(CustomerDTO customerDTO)
        //{
        //    var customer = new Customer
        //    {
        //        Firstname = customerDTO.Firstname,
        //        Lastname = customerDTO.Lastname,
        //        Phone = customerDTO.Phone,
        //        Mail = customerDTO.Mail,
        //        Street = customerDTO.Street,
        //        HouseNumber = customerDTO.HouseNumber,
        //        PostalCode = customerDTO.PostalCode,
        //        City = customerDTO.City,
        //        Native = customerDTO.Native,
        //        AmountOfFreeRides = customerDTO.AmountOfFreeRides,
        //    };

        //    if (ModelState.IsValid)
        //    {
        //        db.Customers.Add(customer);
        //        db.SaveChanges();
        //    }

        //}

        public Models.Customer GetCustomer(string mail)
        {
            throw new NotImplementedException(); ;
        }

        public Models.Customer UpdateCustomer(int id)
        {
            var customerToUpdate = db.Customers.Find(id);
            return customerToUpdate;
        }

        public Customer getCustomerToDelete(int id) //mine
        {
            var customer = db.Customers.Find(id);            
            return customer;
        }

        public void DeleteCustomer(int id) //mine
        {
            //var customer = new Customer
            //{
            //    Firstname = customerDTO.Firstname,
            //    Lastname = customerDTO.Lastname,
            //    Phone = customerDTO.Phone,
            //    Mail = customerDTO.Mail,
            //    Street = customerDTO.Street,
            //    HouseNumber = customerDTO.HouseNumber,
            //    PostalCode = customerDTO.PostalCode,
            //    City = customerDTO.City,
            //    Native = customerDTO.Native,
            //    AmountOfFreeRides = customerDTO.AmountOfFreeRides,
            //};

            //var customer = db.Customers.Find(id);

            //if (ModelState.IsValid)
            //{
            //    db.Customers.Remove(customer);
            //    db.SaveChanges();
            //}
        }



        public bool DeleteCustomer(Models.Customer customer)
        {
            throw new NotImplementedException();
        }

        public Models.Customer DetailsCustomer(int id) //mine
        {
            var customerDetail = db.Customers.Find(id);
            return customerDetail;
        }

        //public Models.Customer EditCustomer(int id) //mine
        //{
        //    var customerToDelete = db.Customers.Find(id);
        //    return customerToDelete;

        //}

        public List<Models.Ferry> GetAllFerries()
        {
            var ferry = db.Ferrys.ToList();
            return ferry;
        }

        public Models.Ferry CreateFerry(FerryDTO ferryDTO)
        {
            var ferry = new Ferry
            {
                FerryId = ferryDTO.FerryId,
                FerryName = ferryDTO.FerryName,
                FerrySize = ferryDTO.FerrySize,
                PassengerCapacity = ferryDTO.PassengerCapacity,
                VehicleCapacity = ferryDTO.VehicleCapacity,
                Municipality = ferryDTO.Municipality,
                DockId = ferryDTO.DockId,
            };

            return ferry;
        }

        public Models.Ferry GetFerry(int ferryId)
        {
            var ferry = db.Ferrys.Find(ferryId);
            return ferry;
        }

        public Models.Ferry UpdateFerry(FerryDTO ferryDTO)
        {
            var ferry = new Ferry
            {
                FerryId = ferryDTO.FerryId,
                FerryName = ferryDTO.FerryName,
                FerrySize = ferryDTO.FerrySize,
                PassengerCapacity = ferryDTO.PassengerCapacity,
                VehicleCapacity = ferryDTO.VehicleCapacity,
                Municipality = ferryDTO.Municipality,
                DockId = ferryDTO.DockId,
            };

            return ferry;
        }

        public Ferry DeleteFerry(int id) // change from bool to Ferry and parameter change from Ferry to int
        {
            var DeletFerry = db.Ferrys.Find(id);
            return DeletFerry;
        }

        public List<Models.Trip> GetAllTrips()
        {
            var trip = db.Trips.ToList();
            return trip;
        }

        public Models.Trip CreateTrip(TripDTO tripDTO) // from Trip to TripDTO
        {
            var trip = new Trip
            {
                DepatureTime = tripDTO.DepatureTime,
                TripPrice = tripDTO.TripPrice,           
            };

            return trip;
        }

        public Models.Trip GetTrip(int tripId)
        {
            Trip trip = db.Trips.Find(tripId);
            return trip;
        }

        public Models.Trip UpdateTrip(TripDTO tripTDO)
        {
            var trip = new Trip
            {
                TripId = tripTDO.TripId,
                DepatureTime = tripTDO.DepatureTime,
                TripPrice = tripTDO.TripPrice,
            };

            return trip;
        }

        public bool DeleteTrip(Models.Trip trip)
        {
            throw new NotImplementedException();
        }

        public List<Models.Route> GetAllRoutes()
        {
            var route = db.Routes.ToList();
            return route;
        }

        public Models.Route CreateRoute(RouteDTO routeDTO)
        {
            var route = new Route
            {
                Depature = routeDTO.Depature,
                Destination = routeDTO.Destination,
                Duration = routeDTO.Duration
            };

            return route;
        }

        public Models.Route GetRoute(int routeId)
        {
            var route = db.Routes.Find(routeId);
            return route;
        }

        public Models.Route UpdateRoute(RouteDTO routeDTO)
        {
            var route = new Route
            {
                RouteId = routeDTO.RouteId,
                Depature = routeDTO.Depature,
                Destination = routeDTO.Destination,
                Duration = routeDTO.Duration,
            };

            return route;
        }

        public bool DeleteRoute(Route Route) 
        {
            throw new NotImplementedException();
        }

        public List<Models.Reservation> GetAllReservations()
        {
            var reserv = db.Reservations.ToList();
            return reserv;
        }

        public Models.Reservation CreateReservation(ReservationDTO reservationDTO)
        {
            var reservObject = new Reservation
            {
                TotalPrice = reservationDTO.TotalPrice,
                NumberOfPeople = reservationDTO.NumberOfPeople,
            };

            return reservObject;
        }

        public Models.Reservation GetReservation(int reservationId)
        {
            var findReserv = db.Reservations.Find(reservationId);
            return findReserv;
        }

        public Models.Reservation UpdateReservation(ReservationDTO reservDTO)
        {
            var reserv = new Reservation
            {
                TotalPrice = reservDTO.TotalPrice,
                NumberOfPeople = reservDTO.NumberOfPeople,
            };

            return reserv;
        }

        //commit
        public bool DeleteReservation(Models.Reservation reservation)
        {
            throw new NotImplementedException();
        }

        public List<Models.Vehicle> GetAllVehicles()
        {
            var vehicle = db.Vehicles.ToList();
            return vehicle;
        }

        public Models.Vehicle CreateVehicle(VehicleDTO vehicleDTO)
        {
            var vehicle = new Vehicle
            {
                VehicleId = vehicleDTO.VehicleId,
                VehiclePrice = vehicleDTO.VehiclePrice,
                VehicleSize = vehicleDTO.VehicleSize,
                VehicleType = vehicleDTO.VehicleType
            };

            return vehicle;
        }

        public Models.Vehicle GetVehicle(int vehicleId)
        {
            Vehicle vehicle = db.Vehicles.Find(vehicleId);
            return vehicle;
        }

        public Models.Vehicle UpdateVehicle(VehicleDTO vehicleDTO)
        {
            var vehicle = new Vehicle
            {
                VehicleId = vehicleDTO.VehicleId,
                VehiclePrice = vehicleDTO.VehiclePrice,
                VehicleSize = vehicleDTO.VehicleSize,
                VehicleType = vehicleDTO.VehicleType,
            };

            return vehicle;
        }

        public bool DeleteVehicle(Models.Vehicle vehicle)
        {
            throw new NotImplementedException();
        }

        public List<Models.Dock> GetAllDocks()
        {
            var DockList = db.Docks.ToList();
            return DockList;
        }

        public Models.Dock CreateDock(DockDTO dockDTO)
        {
            var dock = new Dock
            {
               DockName = dockDTO.DockName,
               FerryCapacity= dockDTO.FerryCapacity,
            };

            return dock;
        }

        public Models.Dock GetDock(int dockId)
        {
            var dock = db.Docks.Find(dockId);
            return dock;
        }

        public Models.Dock UpdateDock(Models.Dock dock)
        {
            throw new NotImplementedException();
        }

        public void DeleteDock(int id) //mine
        {

            var dock = db.Docks.Find(id);

            //if (ModelState.IsValid)
            //{
            db.Docks.Remove(dock);
            db.SaveChanges();
            //}
        }

        public bool DeleteDock(Models.Dock dock)
        {
            throw new NotImplementedException();
        }

        //public Models.Dock DockDetail(int id) //mine
        //{
        //    var dockDetail = db.Docks.Find(id);
        //    return dockDetail;
        //}
    }
}