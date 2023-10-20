using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASM2_1651_NguyenDinhTam_GCD210186
{
    internal class ListTicket
    {
        private List<Ticket> tickets;

        public ListTicket()
        {
            // Initialize an empty list of tickets when an instance of this class is created.
            tickets = new List<Ticket>();
        }

        public void AddTicket(Ticket ticket)
        {
            // Add a given Ticket object to the list of tickets.
            tickets.Add(ticket);
        }

        public void RemoveTicket(Ticket ticket)
        {
            // Remove a given Ticket object from the list of tickets.
            tickets.Remove(ticket);
        }

        public List<Ticket> GetTickets()
        {
            // Retrieve the list of tickets.
            return tickets;
        }
    }
}
