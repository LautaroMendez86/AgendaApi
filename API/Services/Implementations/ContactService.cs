using AgendaApi.Data;
using AgendaApi.Entities;
using AgendaApi.Models;
using AgendaApi.Services.Interfaces;

namespace AgendaApi.Services.Implementations
{
    public class ContactService : IContactService
    {
        private readonly AgendaContext _context;

        public ContactService(AgendaContext context)
        {
            _context = context;
        }
        public List<Contact> GetAllByUser(int id)
        {

            return _context.Contacts.Where(c => c.User.Id == id).ToList();
        }

        public void Create(CreateAndUpdateContact dto, int loggedUserId)
        {
            Contact contact = new Contact()
            {
                Email = dto.Email,
                Image = dto.Image,
                Number = dto.Number,
                Company = dto.Company,
                Address = dto.Address,
                LastName = dto.LastName,
                Name = dto.Name,
                UserId = loggedUserId,
            };
            _context.Contacts.Add(contact);
            _context.SaveChanges();
        }

        public async void Update(CreateAndUpdateContact dto, int contactId)
        {
            Contact? contact = _context.Contacts.SingleOrDefault(contact => contact.Id == contactId);
            if (contact is not null)
            {
                contact.Id = contactId;
                contact.Email = dto.Email;
                contact.Image = dto.Image;
                contact.Number = dto.Number;
                contact.Company = dto.Company;
                contact.Address = dto.Address;
                contact.LastName = dto.LastName;
                contact.Name = dto.Name;
                await _context.SaveChangesAsync();
            }

        }
        public void Delete(int id)
        {
            Contact contact = _context.Contacts.Single(c => c.Id == id);
            _context.Contacts.Remove(contact);
            _context.SaveChanges();
        }
    }
}
