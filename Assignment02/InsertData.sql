CREATE DATABASE PRN231_Assignment02

USE PRN231_Assignment02

SET IDENTITY_INSERT MedicalFacility OFF;
INSERT INTO MedicalFacility (FacilityId, FacilityName, NoDoctors, NoStaffs, PrivateFacility, Level)
VALUES
(1, 'General Hospital', 50, 200, 0, 1),
(2, 'City Clinic', 20, 80, 0, 2),
(3, 'Elite Health Center', 30, 100, 1, 3),
(4, 'Community Hospital', 40, 150, 0, 1),
(5, 'Private Medical Center', 25, 90, 1, 2),
(6, 'Downtown Clinic', 15, 70, 0, 3),
(7, 'Suburban Hospital', 35, 120, 0, 1),
(8, 'Luxury Health Facility', 10, 30, 1, 4),
(9, 'Regional Health Center', 45, 160, 0, 2),
(10, 'Advanced Care Hospital', 55, 220, 1, 5);
SET IDENTITY_INSERT MedicalFacility OFF;

SET IDENTITY_INSERT ServicePriceList ON;
INSERT INTO ServicePriceList (ServiceId, ServiceLevel, ServiceName, ServicePrice)
VALUES
(1, 1, 'General Checkup', 100.00),
(2, 2, 'Specialist Consultation', 200.00),
(3, 3, 'Blood Test', 50.00),
(4, 4, 'X-Ray', 150.00),
(5, 5, 'MRI Scan', 1000.00),
(6, 1, 'Vaccination', 75.00),
(7, 2, 'Ultrasound', 300.00),
(8, 3, 'Physical Therapy', 250.00),
(9, 4, 'Emergency Care', 500.00),
(10, 5, 'Surgery', 5000.00);
SET IDENTITY_INSERT ServicePriceList OFF;