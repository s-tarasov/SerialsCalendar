DROP PROCEDURE IF EXISTS RemoveSerial
;
delimiter //
;
CREATE PROCEDURE RemoveSerial(serialId varchar(128), userId varchar(128))
BEGIN
  DELETE FROM `UserSerials`
  WHERE `UserSerials`.`UserId` = userId
    AND `UserSerials`.`SerialId` = serialId;
END//
;
delimiter ;
;