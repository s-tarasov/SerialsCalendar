DROP PROCEDURE IF EXISTS AddSerial;
;
delimiter //
;
CREATE PROCEDURE AddSerial(serialId varchar(128), userId varchar(128))
BEGIN
  INSERT `UserSerials` (
    `UserId`,
    `SerialId`
  ) 
  VALUES (userId, serialId);
END//
;
delimiter ;
;