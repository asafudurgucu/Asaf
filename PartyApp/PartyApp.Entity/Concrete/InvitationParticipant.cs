using PartyApp.Entity.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Entity.Concrete
{
    public class InvitationParticipant : IBaseEntity
    {
        public int Id { get; set; }
        public int InvitationId { get; set; }
        public Invitation Invitation { get; set; }//Navigation Property
        public int ParticipantId { get; set; }
        public Participant Participant { get; set; }//Navigation Property
    }
}
