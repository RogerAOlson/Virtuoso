using ContactManager.Models;
using MarketingWeb.ViewModels;
using System.Net;

namespace MarketingWeb.ViewModelProviders
{
    public partial class ContactViewModelProvider
    {
        public IResult ToActionResult(ContactResult result) 
        {
            return result.StatusCode switch
            {
                ContactServiceResultType.Success => Results.Ok(),
                ContactServiceResultType.UnknownError => BadRequest(result.StatusCode, "Unexpected error"),

                ContactServiceResultType.IdIsRequired => BadRequest(result.StatusCode, "Id is required"),
                ContactServiceResultType.IdIsInvalid => BadRequest(result.StatusCode, "Id is invalid"),
                ContactServiceResultType.FirstNameIsRequired => BadRequest(result.StatusCode, "First Name is required"),
                ContactServiceResultType.FirstNameIsInvalid => BadRequest(result.StatusCode, "First Name is invalid"),
                ContactServiceResultType.LastNameIsRequired => BadRequest(result.StatusCode, "Last Name is required"),
                ContactServiceResultType.LastNameIsInvalid => BadRequest(result.StatusCode, "Last Name is invalid"),
                ContactServiceResultType.EmailIsRequired => BadRequest(result.StatusCode, "Email is required"),
                ContactServiceResultType.EmailIsInvalid => BadRequest(result.StatusCode, "Email is invalid"),
                ContactServiceResultType.PhoneNumberIsRequired => BadRequest(result.StatusCode, "PhoneNumber is required"),
                ContactServiceResultType.PhoneNumberIsInvalid => BadRequest(result.StatusCode, "PhoneNumber is invalid"),

                ContactServiceResultType.ContactNotFound => NotFound(result.StatusCode, "Contact not found"),
                ContactServiceResultType.ContactAlreadyExists => Conflict(result.StatusCode, "Contact already exists"),

                _ => throw new NotImplementedException("doh!")
            };
        }

        public IResult Conflict(ContactServiceResultType errorCode, string errorMessage)
        {
            return Results.Conflict(new ErrorViewModel(errorCode, errorMessage));
        }

        public IResult NotFound(ContactServiceResultType errorCode, string errorMessage)
        {
            return Results.NotFound(new ErrorViewModel(errorCode, errorMessage));
        }

        public IResult BadRequest(ContactServiceResultType errorCode, string errorMessage)
        {
            return Results.BadRequest(new ErrorViewModel(errorCode, errorMessage));
        }
    }
}