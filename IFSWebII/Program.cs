using IFSWebII.Data;
using IFSWebII.Model;

using IFSDbContext db = new();

foreach (Disciplina disciplina in
    Disciplina.LerCSV(@"C:\Users\emers\source\repos\IFSWebII\IFSWebII\Data\CSV\disciplinas2.csv"))
{
    db.Add(disciplina);
}
db.SaveChanges();

foreach (Prerequisito prerequisito in
    Prerequisito.LerCSV(@"C:\Users\emers\source\repos\IFSWebII\IFSWebII\Data\CSV\prerequisito.csv"))
{
    db.Add(prerequisito);
}
db.SaveChanges();

Prerequisito pre = new("teste", "teste", 2);

db.Prerequisitos.Add(pre);
db.SaveChanges();