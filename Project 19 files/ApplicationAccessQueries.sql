-- FULL TABLE -- 
SELECT * FROM dbo.LocalDrivingLicenseApplications_View;

-- FULL APPLICATIONS DATA
SELECT * FROM dbo.Applications;


SELECT * FROM dbo.LocalDrivingLicenseApplications WHERE dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = @LDL_ID;

select * from Applications,dbo.LocalDrivingLicenseApplications where dbo.LocalDrivingLicenseApplications.LocalDrivingLicenseApplicationID = LocalDrivingLicenseApplications_View.;

SELECT * FROM dbo.LocalDrivingLicenseApplications;

-- CHECK A PERSON CAN APPLY
SELECT 1
FROM dbo.LocalDrivingLicenseApplications
WHERE @
NOT IN (SELECT dbo.LocalDrivingLicenseApplications.LicenseClassID 
		FROM dbo.LocalDrivingLicenseApplications
		LEFT JOIN dbo.Applications
		ON dbo.LocalDrivingLicenseApplications.ApplicationID = dbo.Applications.ApplicationID 
		WHERE dbo.Applications.ApplicantPersonID = @) 


--CANCEL APPLICATION--
UPDATE dbo.Applications 
SET ApplicationStatus = 1
WHERE dbo.Applications.ApplicantPersonID = 