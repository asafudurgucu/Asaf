using PartyApp.Data.Concrete.Repositories;
using PartyApp.Entity.Concrete;
using PartyApp.Shared.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Business.Contcrete
{
    public class InvitationService
    {
        private readonly InvitationRepository _invitationRepository;

        public InvitationService(InvitationRepository invitationRepository)
        {
            _invitationRepository = invitationRepository;
        }
        public List<InvitationViewModal> GetAll()
        {
            var invitations = _invitationRepository.GetAll();
            List<InvitationViewModal> result = invitations
                .Select(x => new InvitationViewModal
                {
                    Id = x.Id,
                    EventName = x.EventName,
                    EventDate = x.EventDate
                }).ToList();
            return result;
            
        }
        public InvitationViewModal GetById(int id) 
        {
            var invitation = _invitationRepository.GetById(id);
            InvitationViewModal result = new();
            result.Id = invitation.Id;
            result.EventName = invitation.EventName;
            result.EventDate = invitation.EventDate;
            return result;

        }
        
        public void Create(InvitationViewModal ınvitationViewModal)
        {
            Invitation invitation = new()
            {
                Id = ınvitationViewModal.Id,
                EventName = ınvitationViewModal.EventName,
                EventDate = ınvitationViewModal.EventDate,
            };
            _invitationRepository.Create(invitation);

        }
        public void Update(InvitationViewModal ınvitationViewModal)
        {
            var invitation = _invitationRepository.GetById(ınvitationViewModal.Id);
            invitation.EventName = ınvitationViewModal.EventName;
            invitation.EventDate = ınvitationViewModal.EventDate;
            _invitationRepository.Update(invitation);

        }
        public void Delete(int id) 
        {
            var invitation = _invitationRepository.GetById(id);
            _invitationRepository.Delete(invitation);
        }
    }
}
