using PartyApp.Entity.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PartyApp.Data.Concrete.Repositories
{
    public class PartycipantsRepository
    {
        private readonly AppDbContext _appDbContext;
        public PartycipantsRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
        public List<Participant> GetAll()
        {
            var partycipant = _appDbContext.Participants.ToList();
            return partycipant;

        }

        public Participant GetById(int id)
        {
            var participants = _appDbContext.Participants.Where(x => x.Id == id).First();
            return participants;
        }
        public void Create(Participant participants)
        {
            _appDbContext.Participants.Add(participants);
            _appDbContext.SaveChanges();
        }
        public void Update(Participant participants)
        {
            _appDbContext.Participants.Update(participants);
            _appDbContext.SaveChanges();
        }
        public void Delete(Participant participants)
        {
            _appDbContext.Participants.Remove(participants);
            _appDbContext.SaveChanges();S
        }
    }
}
