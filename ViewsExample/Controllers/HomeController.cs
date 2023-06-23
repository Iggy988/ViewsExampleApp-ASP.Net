using Microsoft.AspNetCore.Mvc;
using ViewsExample.Models;

namespace ViewsExample.Controllers;

public class HomeController : Controller
{
    [Route("/")]
    [Route("home")]
    public IActionResult Index()
    {
        ViewData["pageTitle"] = "Asp.Net Core Demo App";

        List<Person> people = new List<Person>()
        {
            new Person(){ Name = "Igor", DateOfBirth = Convert.ToDateTime("1988-04-21"), PersonGender = Gender.Male },
            new Person(){ Name = "Jovana", DateOfBirth = Convert.ToDateTime("1995-04-14"), PersonGender = Gender.Female },
            new Person(){ Name = "Nina", DateOfBirth = Convert.ToDateTime("1991-03-06"), PersonGender = Gender.Female },
        };

        //ViewData["people"] = people;    
        //ViewBag.people = people;

        //kad stavimo @model imeModelClass onda trebamo supplly model object kroz View kao property
        return View("Index", people);// Views/Home/Index.cshtml
        //return View("abc"); //abc.cshtml
        //return new ViewResult() { ViewName = "abc"};
    }

    [Route("person-details/{name}")]
    public IActionResult Details(string? name)
    {
       if (name == null)
        {
            return Content("Person name can't be null");
        }
        List<Person> people = new List<Person>()
        {
            new Person(){ Name = "Igor", DateOfBirth = Convert.ToDateTime("1988-04-21"), PersonGender = Gender.Male },
            new Person(){ Name = "Jovana", DateOfBirth = Convert.ToDateTime("1995-04-14"), PersonGender = Gender.Female },
            new Person(){ Name = "Nina", DateOfBirth = Convert.ToDateTime("1991-03-06"), PersonGender = Gender.Female },
        };
        Person? matchingPerson = people.Where(temp => temp.Name == name).FirstOrDefault();

        return View(matchingPerson); // Views/Home/Details.cshtml
    }

    [Route("person-with-product")]
    public IActionResult PersonWithProduct()
    {
        Person person = new Person() { Name = "Ena", DateOfBirth = Convert.ToDateTime("1993-06-20"), PersonGender = Gender.Female };
        Product product = new Product() { ProductId = 1, ProductName = "Air Conditioner" };
        
        // ne mozemo u View() staviti 2 objekta, zato smo napravili wrapper model class u koji smijestamo
        // podatke iz person i product modela
        PersonAndProductWrapperModel personAndProductWrapperModel =
            new PersonAndProductWrapperModel() { PersonData = person,ProductData = product};
        return View(personAndProductWrapperModel);
    }

    [Route("home/all-products")]
    public IActionResult All()
    {
        return View();
        //Views/Home/All.cshtml
        //Views/Shared/All.cshtml
    }
}
