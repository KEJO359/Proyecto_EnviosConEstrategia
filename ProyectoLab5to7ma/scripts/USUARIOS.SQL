CREATE USER IF NOT EXISTS 'administrador'@'localhost'
IDENTIFIED BY 'admin123';

GRANT ALL PRIVILEGES ON *.*
TO 'administrador'@'localhost'
WITH GRANT OPTION;


CREATE USER IF NOT EXISTS 'desarrollo'@'localhost'
IDENTIFIED BY 'desarrollo123';

GRANT ALL PRIVILEGES ON DB_JoacoEnvios.*
TO 'desarrollo'@'localhost';


FLUSH PRIVILEGES;