using ProgressTest01.Models;

namespace ProgressTest01.DTOs
{
    public static class BookViewDtoMapper
    {

        public static BookViewDto ToBookViewDto(this Book bookModel)
        {
            var authors = bookModel.BookAuthors.Select(ba => ba.Author);
            return new BookViewDto
            {
                BookID = bookModel.Book_id,
                Title = bookModel.Title,
                Country = bookModel.Publisher.Country,
                PublisherName = bookModel.Publisher.Publisher_name,
                Price = bookModel.Price,
                AuthorInformations = authors.Select(a => a.ToAuthorsDto()).ToList()
            };
        }
        public static Book ToBookFromCreate(this CreateBookRequestDto bookDto, Publisher publisherModel)
        {
            return new Book
            {
                Title = bookDto.Title,
                Type = bookDto.Type,
                Pub_id = publisherModel.Pub_id,
                Publisher = publisherModel,
                Price = bookDto.Price,
                Advanced = bookDto.Advanced,
                Royalty = bookDto.Royalty,
                Notes = bookDto.Notes
            };
        }
    }
}
