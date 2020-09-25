//// SELECT
var student = _context.Student.FirstOrDefault(s => s.Name == "Jhon");
var student = _context.Student.Find(2);
var students = _context.Student.Where(s => s.Name == 'jhon').ToList();
var students = _context.Student.Where(s => EF.Functions.Like(s.Name, "J%")).ToList();

//// Execution Methods
ToList() || ToListAsync()
First()  || FirstAsync()
FirstOrDefault()  || FirstOrDefaultAsync()
Single()
SingleOrDefault()
Last()
LastOrDefault() // works only after .OrderBy(s => s.Key)
Skip(), Take()
Count()
LongCount()
Min(), Max()
Average(), Sum()

//// Updating and deleting
update ==> _context.SaveChanges();
delete ==> _context.Student.Delete(s); // var s = _context.Student.find(1)

//// Projection
using Microsoft.EntityFrameworkCore;
var studentsWithClasses = _context.Students.Include(s => s.Classes).ToList(); // LEFT join Query
var someProperties      = _context.Students.Select(s => new { s.Name, s.Classes } ); // select only name and classes properties
var someProperties      = _context.Students.Select(s => new { s.Name, s.Classes.Count } ); // select only name and classes.count properties
var someProperties      = _context.Students.Select(s => new { s.Name, 
                                                        goodClasses = s.Classes.Where(cls => cls.chihaja == chi7ajaKhra) } ); // filter the sub properties
// For single objects                                            
var samurai = _context.SamuraiFirstOrDefault(s => s.Name.Contains("Kakashi"));
_context.Entry(samurai).Collection(s => s.Quotes).Load(); // Get the samura Quotes (Quotes is a list)
_context.Entry(samurai).Reference(s -> s.Horse).Load(); // Get the samurai horse (only 1)
// Filter loaded data (sub properties)
var happyQuotes = _context.entry(samurai)
                        .Collection(s => s.Quotes)
                        .Query()
                        .Where(q => q.Text.Contains("happy"))
                        .ToList();

//// Filter objects by their sub objects properties
var samurais = _context.Samurais
                        .Where(a => a.Quotes.Any(q => q.Text.Contains("happy")))
                        .ToList();
// update sub properties
var quote = samurai.Quotes[0];
quote.Text = "abc";
using(var newContext = new SamuraiContext()) { // to track only the quote that you want to update
    newContext.Entity(quote).State = EntityState.Modified;
    newContext.SaveChanges();
}                                               

// update many to many
var battle = _context.Battles.find(1);
battle.SamuraiBattles.Add(new SamuraiBattle { Id = 21 } );
_context.SaveChanges();
//delete many to many
var join = new SamuraiBattle {battleId = 1, SamuraiId = 2 };
_context.remove(join);
_context.SaveChanges();
// Query many to many || Samurai has many battle throug SamuraiBattle
var samuraiWithBattles = _context.Samurais.Where(s => s.Id = 2)
                                        .Select(s => new {
                                            samurai = s,
                                            battles = s.SamuraiBattles.Select(sb => sb.Battle)
                                        })
                                        .FirstOrDefault();

//// Dependency injection
Startup.cs ->  public void ConfigureServices
# add
services.AddScoped<IModelRepository, IModelRepositoryImp>();
# build the project


////// Relationships /////////

//one to many exception:
//A possible object cycle was detected which is not supported. This can either be due to a cycle or if the object depth is larger than the maximum allowed depth of 32.
.NET Core 3.1 Install the package Microsoft.AspNetCore.Mvc.NewtonsoftJson
//Startup.cs Add service
services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);
