using ProgressTest01.Models;

namespace ProgressTest01.DTOs
{
    public static class AuthorsDtoMapper
    {
        public static AuthorsDto ToAuthorsDto(this Author authorModel)
        {
            return new AuthorsDto
            {
                FirstName = authorModel.First_name,
                LastName = authorModel.Last_name,
                EmailAddress = authorModel.Email_address
            };
        }
    }
}
