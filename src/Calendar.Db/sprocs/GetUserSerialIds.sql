DROP PROCEDURE IF EXISTS GetUserSerialIds
;
delimiter //
;
CREATE PROCEDURE GetUserSerialIds(userId varchar(128))
BEGIN
	select `SerialId`
	from `UserSerials` as S
	where S.`UserId` = userId;
END//
;
delimiter ;
;