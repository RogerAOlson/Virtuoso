using ContactManager.Models;
using ContactManager.Services;

namespace MarketingWeb.ViewModelProviders
{
    public class ContactViewModelProvider
    {
        public IResult ConvertToActionResult(ContactSelectResult result)
        {
            if (result.StatusCode == ContactServiceResultType.Success)
                return Results.Ok(result.Record);

            return ConvertToActionResult(result.StatusCode);
        }

        public IResult ConvertToActionResult(ContactAddResult result)
        {
            if (result.ResultType == ContactServiceResultType.Success)
                return Results.Ok(new { result.Id });

            return ConvertToActionResult(result.ResultType);
        }

        public IResult ConvertToActionResult(ContactUpdateResult result)
        {
            return ConvertToActionResult(result.ResultType);
        }

        public IResult ConvertToActionResult(ContactDeleteResult result)
        {
            return ConvertToActionResult(result.ResultType);
        }

        public IResult ConvertToActionResult(ContactServiceResultType resultType)
        {
            return resultType switch
            {
                ContactServiceResultType.Success => Results.Ok(),
                ContactServiceResultType.UnknownError => Results.Problem("Unexpected error"),

                ContactServiceResultType.IdIsRequired => MyBadRequest("Id is required"),
                ContactServiceResultType.IdIsInvalid => MyBadRequest("Id is invalid"),
                ContactServiceResultType.FirstNameIsRequired => MyBadRequest("First Name is required"),
                ContactServiceResultType.FirstNameIsInvalid => MyBadRequest("First Name is invalid"),
                ContactServiceResultType.LastNameIsRequired => MyBadRequest("Last Name is required"),
                ContactServiceResultType.LastNameIsInvalid => MyBadRequest("Last Name is invalid"),
                ContactServiceResultType.EmailIsRequired => MyBadRequest("Email is required"),
                ContactServiceResultType.EmailIsInvalid => MyBadRequest("Email is invalid"),
                ContactServiceResultType.PhoneNumberIsRequired => MyBadRequest("PhoneNumber is required"),
                ContactServiceResultType.PhoneNumberIsInvalid => MyBadRequest("PhoneNumber is invalid"),

                ContactServiceResultType.ContactNotFound => Results.NotFound(new { Errormessage = "Contact not found" }),
                ContactServiceResultType.ContactAlreadyExists => MyBadRequest("Contact already exists"),
            };
        }

        public IResult MyBadRequest(string errorMessage)
        {
            return Results.BadRequest(new { ErrorMessage = errorMessage });
        }
    }
}