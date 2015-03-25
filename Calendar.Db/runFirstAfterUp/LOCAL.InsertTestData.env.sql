SET NAMES 'utf8';

INSERT IGNORE INTO `Users` 
SET 
	Id = 'c362a645-a20e-48a3-aa56-8adef82b5f98',
	Email = 'mr.netpilgrim@gmail.com', 
	EmailConfirmed = 0, 
	PasswordHash = NULL,
	SecurityStamp = 'e871e26d-a75b-4070-9e0e-a8fcdb4c968f',
	PhoneNumber = NULL,
	PhoneNumberConfirmed = 0,
	TwoFactorEnabled = 0,
	LockoutEndDateUtc = NULL,
	LockoutEnabled = 0,
	AccessFailedCount = 0,
	UserName = 'mr.netpilgrim@gmail.com';

INSERT IGNORE INTO `UserLogins`
SET
	LoginProvider = 'Google',
	ProviderKey = '113805772164691984340',
	UserId = 'c362a645-a20e-48a3-aa56-8adef82b5f98';


INSERT IGNORE INTO `UserSerials`
SET
	SerialId = 'Game_of_Thrones',
	UserId = 'c362a645-a20e-48a3-aa56-8adef82b5f98';

INSERT IGNORE INTO `UserSerials`
SET
	SerialId = 'Suits',
	UserId = 'c362a645-a20e-48a3-aa56-8adef82b5f98';