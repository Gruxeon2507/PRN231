CREATE DATABASE PRN231_Assignment01

USE PRN231_Assignment01

-- Sample Data
-- Add some sample data to the tables
INSERT INTO Subject (SubjectCode, SubjectName) VALUES
('MATH101', 'Calculus I'),
('ENG201', 'English Literature'),
('CSC301', 'Data Structures'),
('PHY101', 'Physics I');

INSERT INTO Instructor (TeacherCode, FullName, PhoneNumber) VALUES
('T001', 'John Smith', '1234567890'),
('T002', 'Jane Doe', '0987654321');

INSERT INTO InstructorSubject (TeacherCode, SubjectCode) VALUES
('T001', 'MATH101'),
('T001', 'PHY101'),
('T002', 'ENG201'),
('T002', 'CSC301');

INSERT INTO Student (StudentCode, FullName, DateOfBirth, Gender, Course, StillStudying) VALUES
('S001', 'Alice Johnson', '2000-01-15', 'F', 'Computer Science', 1),
('S002', 'Bob Brown', '1999-05-23', 'M', 'Physics', 0);

INSERT INTO Transcript (StudentCode, SubjectCode, HighestScore) VALUES
('S001', 'MATH101', 88.5),
('S001', 'ENG201', 92.0),
('S002', 'PHY101', 76.0),
('S002', 'CSC301', 81.5);
