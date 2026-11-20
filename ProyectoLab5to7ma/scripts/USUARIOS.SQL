-- Crear usuario administrador
CREATE USER IF NOT EXISTS 'administrador'@'localhost'
IDENTIFIED BY 'admin123';

GRANT ALL PRIVILEGES ON DB_JoacoEnvios.*
TO 'administrador'@'localhost';


-- Crear usuario desarrollo
CREATE USER IF NOT EXISTS 'desarrollo'@'localhost'
IDENTIFIED BY 'desarrollo123';

-- Permitir solamente consultas
GRANT SELECT ON DB_JoacoEnvios.*
TO 'desarrollo'@'localhost';

-- Permitir ejecutar únicamente el procedimiento de estadísticas
GRANT EXECUTE ON PROCEDURE DB_JoacoEnvios.obtenerEstadisticas
TO 'desarrollo'@'localhost';


FLUSH PRIVILEGES;