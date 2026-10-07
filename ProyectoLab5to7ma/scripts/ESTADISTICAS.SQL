USE DB_JoacoEnvios;

DROP PROCEDURE IF EXISTS obtenerEstadisticas;

DELIMITER $$

CREATE PROCEDURE obtenerEstadisticas(
    IN p_fechaDesde DATETIME,
    IN p_fechaHasta DATETIME
)
BEGIN

    DECLARE EXIT HANDLER FOR SQLEXCEPTION
    BEGIN
        ROLLBACK;
        RESIGNAL;
    END;

    START TRANSACTION;

    SELECT
        e.modalidad,

        COUNT(*) AS cantidadEnvios,

        SUM(
            CASE
                WHEN e.modalidad = 'ESTANDAR'
                    THEN e.distancia * 10
                WHEN e.modalidad = 'EXPRESS'
                    THEN e.distancia * 20
                WHEN e.modalidad = 'PRIORITARIO'
                    THEN e.distancia * 30
            END
        ) AS costoAcumulado,

        AVG(
            CASE
                WHEN e.modalidad = 'ESTANDAR'
                    THEN e.distancia * 10
                WHEN e.modalidad = 'EXPRESS'
                    THEN e.distancia * 20
                WHEN e.modalidad = 'PRIORITARIO'
                    THEN e.distancia * 30
            END
        ) AS costoPromedio,

        SUM(
            IF  (e.estado = 'ENTREGADO', 1, 0)
        ) AS entregados,

        SUM(
            IF (e.estado = 'CANCELADO', 1, 0)
        ) AS cancelados,

        SUM(
            IF (e.estado = 'PENDIENTE', 1, 0)
        ) AS pendientes,

        AVG(
            CASE
                WHEN e.estado = 'ENTREGADO'
                THEN TIMESTAMPDIFF(
                    HOUR,
                    e.fechaCreacion,
                    (
                        SELECT MIN(h.fecha)
                        FROM HistorialEstado h
                        WHERE h.idEnvio = e.idEnvio
                        AND h.estado = 'ENTREGADO'
                    )
                )
            END
        ) AS tiempoPromedioEntregaHoras,

        SUM(
            CASE
                WHEN e.estado = 'ENTREGADO'
                    THEN
                        CASE
                            WHEN e.modalidad = 'ESTANDAR'
                                THEN e.distancia * 10
                            WHEN e.modalidad = 'EXPRESS'
                                THEN e.distancia * 20
                            WHEN e.modalidad = 'PRIORITARIO'
                                THEN e.distancia * 30
                        END
                ELSE 0
            END
        ) AS facturacion

    FROM Envio e

    WHERE e.fechaCreacion BETWEEN p_fechaDesde AND p_fechaHasta

    GROUP BY e.modalidad;

    COMMIT;

END$$

DELIMITER ;