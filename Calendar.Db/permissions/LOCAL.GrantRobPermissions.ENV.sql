Grant All Privileges on {{DatabaseName}}.* to 'calendar'@'%';

DROP USER 'calendar'@'%';

CREATE USER 'calendar'@'%' IDENTIFIED BY 'calendar';

Grant All Privileges on {{DatabaseName}}.* to 'calendar'@'%';
