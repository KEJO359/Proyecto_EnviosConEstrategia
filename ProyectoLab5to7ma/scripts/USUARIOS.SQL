
-- Crear usuario administrador
CREATE USER IF NOT EXISTS 'administrador'@'localhost'
IDENTIFIED BY 'admin123';

ALTER USER 'administrador'@'localhost'
IDENTIFIED BY 'admin123';

GRANT ALL PRIVILEGES ON DB_JoacoEnvios.*
TO 'administrador'@'localhost';


-- Crear usuario invitado
CREATE USER IF NOT EXISTS 'invitado'@'localhost'
IDENTIFIED BY 'invitado123';

ALTER USER 'invitado'@'localhost'
IDENTIFIED BY 'invitado123';

-- Permitir solamente consultas
GRANT SELECT ON DB_JoacoEnvios.*
TO 'invitado'@'localhost';

-- Permitir ejecutar el procedimiento de estadísticas
GRANT EXECUTE ON PROCEDURE DB_JoacoEnvios.obtenerEstadisticas
TO 'invitado'@'localhost';

FLUSH PRIVILEGES;
