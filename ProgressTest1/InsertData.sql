-- Insert sample Authors
INSERT INTO Authors (Last_name, First_name, Phone, Address, City, State, Zip, Email_address)
VALUES 
    ('Doe', 'John', '123-456-7890', '123 Main St', 'New York', 'NY', '10001', 'john.doe@example.com'),
    ('Smith', 'Jane', '987-654-3210', '456 Elm St', 'Los Angeles', 'CA', '90001', 'jane.smith@example.com'),
    ('Johnson', 'Michael', '555-555-5555', '789 Oak St', 'Chicago', 'IL', '60001', 'michael.johnson@example.com'),
    ('Brown', 'Emily', '111-222-3333', '246 Pine St', 'Houston', 'TX', '77001', 'emily.brown@example.com'),
    ('Williams', 'David', '777-888-9999', '135 Cedar St', 'Miami', 'FL', '33101', 'david.williams@example.com');

-- Insert sample Publishers
INSERT INTO Publishers (Publisher_name, City, State, Country)
VALUES 
    ('Publisher A', 'New York', 'NY', 'USA'),
    ('Publisher B', 'London', 'LD', 'UK'),
    ('Publisher C', 'Toronto', 'Ontario', 'Canada'),
    ('Publisher D', 'Sydney', 'NSW', 'Australia'),
    ('Publisher E', 'Berlin', 'Ber', 'Germany');

	
-- Insert sample Books
INSERT INTO Books (Title, Type, Pub_id, Price, Advanced, Royalty, Ytd_sales, Notes, Published_date)
VALUES 
    ('Book 1', 1, 4, 29.99, 5.00, 10.00, 1000, 'Lorem ipsum dolor sit amet.', '2023-01-15'),
    ('Book 2', 2, 5, 24.99, 4.50, 8.00, 800, 'Consectetur adipiscing elit.', '2023-02-20'),
    ('Book 3', 1, 6, 19.99, 3.00, 7.50, 1200, 'Sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.', '2023-03-25'),
    ('Book 4', 2, 7, 34.99, 6.00, 12.00, 1500, 'Ut enim ad minim veniam.', '2023-04-30'),
    ('Book 5', 3, 8, 27.99, 4.50, 9.50, 900, 'Quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.', '2023-05-05');

-- Insert sample BookAuthors relationships
INSERT INTO BookAuthors (Book_id, Author_id, Author_order, Royality_percentage)
VALUES 
    (5, 6, 'Primary', 50.0),
    (5, 2, 'Secondary', 30.0),
    (6, 2, 'Primary', 60.0),
    (6, 3, 'Secondary', 40.0),
    (7, 3, 'Primary', 70.0),
    (7, 6, 'Secondary', 30.0),
    (8, 4, 'Primary', 80.0),
    (8, 5, 'Secondary', 20.0),
    (9, 5, 'Primary', 90.0),
    (9, 4, 'Secondary', 10.0);