using Microsoft.EntityFrameworkCore;
using Web_atrio;

internal class PersonneService
{
    private readonly PersonneContext _context;
    public PersonneService(PersonneContext context)
    {
        _context = context;
    }
    public List<Personne> GetAll() => _context.Personnes
            .AsNoTracking()
            .ToList();
    public Personne? GetById(int id)
    {
        var person = _context.Personnes.Find(id);
        if(person is null) return null;
        return person;
    }
    
    public void AddEmploi(int personneId, Emploi emploi)
    {
        var personneToUpdate = _context.Personnes.Find(personneId);
        if (personneToUpdate is null)
        {
            throw new InvalidOperationException("Personne or emploi does not exist");
        }
        personneToUpdate.Emploies.Add(emploi);
        _context.SaveChanges();
    }
    public void DeleteById(int personneId)
    {
        var PersonneToDelete = _context.Personnes.Find(personneId);
        if (PersonneToDelete is not null)
        {
            _context.Personnes.Remove(PersonneToDelete);
            _context.SaveChanges();
        }
    }
    public void DeleteAll()
    {
        _context.Personnes.ExecuteDelete();
    }
    public Personne Create( Personne nouvelPersonne)
    {
        _context.Personnes.Add(nouvelPersonne);
        _context.SaveChanges();
        return nouvelPersonne;
    }
}