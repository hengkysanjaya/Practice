//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace AmonicAirline
{
    using System;
    using System.Collections.Generic;
    
    public partial class AmenitiesTicket
    {
        public int AmenityID { get; set; }
        public int TicketID { get; set; }
        public decimal Price { get; set; }
    
        public virtual Amenity Amenity { get; set; }
        public virtual Ticket Ticket { get; set; }
    }
}
