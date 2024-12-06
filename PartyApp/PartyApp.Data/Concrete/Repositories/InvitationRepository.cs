using PartyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Data.Concrete.Repositories
{

    public class InvitationRepository
    {
        private readonly AppDbContext _appDbContext;

        public InvitationRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }

        public List<Invitation> GetAll()
        {
            var invitations = _appDbContext.Invitations.ToList();
            return invitations;    

        }

        public Invitation GetById(int id) 
        {
            var invitation = _appDbContext.Invitations.Where(x => x.Id == id).First();
            return invitation;
        }
        public void Create(Invitation invitation) 
        {
            _appDbContext.Invitations.Add(invitation);
            _appDbContext.SaveChanges();
        }
        public void Update(Invitation invitation) 
        {
            _appDbContext.Invitations.Update(invitation);
            _appDbContext.SaveChanges();
        }
        public void Delete(Invitation ınvitation) 
        {
            _appDbContext.Invitations.Remove(ınvitation);
            _appDbContext.SaveChanges();
        }


    }
}

