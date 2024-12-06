using PartyApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Entity.Concrete
{
    public class Invitation : IBaseEntity
    {
        public int Id { get; set; }
        public string EventName { get; set; }
        public DateTime EventDate { get; set; }
        public List<InvitationParticipant> InvitationParticipants { get; set; } //Navigation Property

    }

    /*
     * Varsayalım ki elimizde bir Invitation nesnesi var.
     * Invitation invitation = invitationRepository.GetById(2);
     * invitation.Id=2
     * invitation.EventName="Noel Partisi"
     * invitation.EventDate=20.12.2024
     * invitation.InvitationParticipants=
     *  {
     *      InvitationParticipant(2,40),
     *      InvitationParticipant(2,44),
     *      InvitationParticipant(2,46),
     *      InvitationParticipant(2,49)
     *  }
    */
    
}


