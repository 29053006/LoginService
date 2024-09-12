CREATE TRIGGER DoNotRepeatUser
ON Users
INSTEAD OF INSERT
AS
BEGIN
    IF EXISTS (SELECT 1 FROM Users WHERE UserName = (SELECT UserName FROM inserted))
    BEGIN
			RETURN
    END
    ELSE
    BEGIN
        INSERT INTO Users (UserId, UserName, Password,Email,PhoneNumber,RolId,TwoStepVerification,ExpiratePassword)
        SELECT UserId, UserName, Password,Email,PhoneNumber,RolId,TwoStepVerification,ExpiratePassword
        FROM inserted;
    END
END;