# Documentation

## Server side

### Database Setup:
1. Create user model
```
public class User
{
    [Key]
    public int Id { get; set; }

    public string firstname { get; set; }
    public string fathername { get; set; }
    public string familyname { get; set; }

    [Required(ErrorMessage = "Please Enter Username..")]
    [Display(Name = "UserName")]
    public string username { get; set; }

    [Required(ErrorMessage = "Please Enter Password..")]
    [DataType(DataType.Password)]
    [Display(Name = "Password")]
    public string password { get; set; }

    public DateTime birthdate { get; set; }
    public string occupation { get; set; }
    public string address { get; set; }
}
```
2. Add Data Annotations
3. Add Connection String in **appsettings.json**
```
"ConnectionStrings": {
    "DefaultConnection": "server=DESKTOP-HG0DSF0;Database=task2022;Trusted_Connection=True;"
  }
```
4. Add AppDbContext
5. Setup Program.cs to use DbContext
```
//Add Db Context
builder.Services.AddDbContext<AppDbContext>(options => options.UseSqlServer(
    builder.Configuration.GetConnectionString("DefaultConnection")
    ));
```
6. Add Migrations and check Database Connection