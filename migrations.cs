////Nugets
Microsoft.EntityFrameworkCore.SqlServer
Microsoft.EntityFrameworkCore.Tools

//// Migration
Add-Migration InitialCreate
Update-Database

//// Models
# validation
[Column(TypeName ="decimal(18,2")] 
public decimal Price { get; set; }

[Required(ErrorMessage = "Please enter your real name")]
[Display(Name = "Real name")]
[StringLength(100)]

// for unused cols
[BindNever] // don't bind it with the form
[ScaffoldColumn(false)] // don't include this col in the scaffold

[DataType(DataType.Date)]
[Display(Name = "Release Date")]
[Range(0, 999.99)]
public decimal Price { get; set; }
[CreditCard]: Validates that the property has a credit card format. Requires jQuery Validation Additional Methods.
[Compare]: Validates that two properties in a model match.
[EmailAddress]: Validates that the property has an email format.
[Phone]: Validates that the property has a telephone number format.
[Range]: Validates that the property value falls within a specified range.
[RegularExpression(@"(>/>jkxfds><p")]: Validates that the property value matches a specified regular expression.
[Required]: Validates that the field is not null. See [Required] attribute for details about this attribute's behavior.
[StringLength]: Validates that a string property value doesn't exceed a specified length limit.
[Url]: Validates that the property has a URL format.
[Remote]: Validates input on the client by calling an action method on the server. See [Remote] attribute for details about this attribute's behavior.