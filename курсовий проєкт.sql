DROP DATABASE IF EXISTS notary_office;
CREATE DATABASE IF NOT EXISTS notary_office
CHARACTER SET utf8mb4
COLLATE utf8mb4_unicode_ci;

USE notary_office;

-- Таблиці

CREATE TABLE clients ( 
    client_id INT AUTO_INCREMENT PRIMARY KEY, 
    full_name VARCHAR(150) NOT NULL, 
    passport_number VARCHAR(30) UNIQUE NOT NULL, 
    phone VARCHAR(30),
    email VARCHAR(150),
    address VARCHAR(255),
    is_archived TINYINT(1) NOT NULL DEFAULT 0,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

CREATE TABLE notaries ( 
    notary_id INT AUTO_INCREMENT PRIMARY KEY, 
    full_name VARCHAR(150) NOT NULL,
    position VARCHAR(100),
    experience_years INT, 
    phone VARCHAR(30),
    email VARCHAR(150),
    is_archived TINYINT(1) NOT NULL DEFAULT 0,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

CREATE TABLE services ( 
    service_id INT AUTO_INCREMENT PRIMARY KEY, 
    service_name VARCHAR(150) NOT NULL,
    description TEXT,
    price DECIMAL(12,2) NOT NULL,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP
) ENGINE=InnoDB;

CREATE TABLE cases ( 
    case_id INT AUTO_INCREMENT PRIMARY KEY, 
    client_id INT NOT NULL, 
    notary_id INT NOT NULL, 
    start_date DATE NOT NULL,
    closing_date DATE DEFAULT NULL,
    status ENUM('Активна','Завершена','Архівна') DEFAULT 'Активна',
    is_archived TINYINT(1) NOT NULL DEFAULT 0,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_cases_client FOREIGN KEY (client_id) REFERENCES clients(client_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT fk_cases_notary FOREIGN KEY (notary_id) REFERENCES notaries(notary_id) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB;

CREATE TABLE agreements ( 
    agreement_id INT AUTO_INCREMENT PRIMARY KEY, 
    case_id INT NOT NULL, 
    service_id INT NOT NULL, 
    amount DECIMAL(12,2) NOT NULL, 
    agreement_date DATE NOT NULL,
    is_archived TINYINT(1) NOT NULL DEFAULT 0,
    created_at TIMESTAMP DEFAULT CURRENT_TIMESTAMP,
    CONSTRAINT fk_agreements_case FOREIGN KEY (case_id) REFERENCES cases(case_id) ON DELETE RESTRICT ON UPDATE CASCADE,
    CONSTRAINT fk_agreements_service FOREIGN KEY (service_id) REFERENCES services(service_id) ON DELETE RESTRICT ON UPDATE CASCADE
) ENGINE=InnoDB;

-- optional
CREATE INDEX idx_clients_name ON clients(full_name);
CREATE INDEX idx_notaries_name ON notaries(full_name);
CREATE INDEX idx_cases_status ON cases(status);

-- Прикладні дані
INSERT INTO clients (full_name, passport_number, phone, email, address)
VALUES
('Іваненко Олена Сергіївна', 'АА123456', '0987654321', 'olena.ivanenko@example.com', 'м. Київ, вул. Лесі Українки, 4'),
('Петренко Андрій Васильович', 'ВВ234567', '0971562586', 'andriy.petrenko@example.com', 'м. Львів, вул. Князя Романа, 12'),
('Мельник Катерина Ігорівна', 'СС345678', '0930123492', 'kateryna.melnyk@example.com', 'м. Харків, просп. Науки, 50'),
('Сидоренко Олексій Петрович', 'DD456789', '0665672106', 'oleksiy.sydorenko@example.com', 'м. Одеса, вул. Дерибасівська, 1'),
('Гончар Людмила Василівна', 'EE567890', '0505023619', 'lyudmyla.gonchar@example.com', 'м. Дніпро, вул. Короленка, 7');

INSERT INTO notaries (full_name, position, experience_years, phone, email)
VALUES
('Коваленко Ганна Михайлівна', 'Головний нотаріус', 18, '0501012834', 'hanna.kovalenko@notary.com'),
('Бондар Юлія Олегівна', 'Нотаріус', 6, '0674802392', 'yuliia.bondar@notary.com'),
('Ткаченко Ігор Сергійович', 'Нотаріус', 9, '0634892402', 'igor.tkachenko@notary.com');

INSERT INTO services (service_name, description, price)
VALUES
('Посвідчення договору купівлі-продажу', 'Оформлення та посвідчення купівлі-продажу нерухомості.', 3000.00),
('Посвідчення довіреності', 'Підготовка та нотаріальне посвідчення довіреності.', 800.00),
('Засвідчення копій документів', 'Засвідчення відповідності копій оригіналам.', 200.00),
('Адвокатська довіреність (пакет)', 'Комплексна підготовка документів та посвідчення.', 1500.00),
('Підготовка заповіту', 'Підготовка та посвідчення заповіту.', 1200.00);

INSERT INTO cases (client_id, notary_id, start_date, closing_date, status)
VALUES
(1, 1, '2025-01-15', '2025-01-20', 'Завершена'),
(2, 2, '2025-02-01', NULL, 'Активна'),
(3, 1, '2025-02-10', '2025-02-12', 'Архівна'),
(4, 3, '2025-03-05', NULL, 'Активна'),
(5, 2, '2025-03-10', NULL, 'Активна');

INSERT INTO agreements (case_id, service_id, amount, agreement_date)
VALUES
(1, 1, 3000.00, '2025-01-20'),
(2, 2, 800.00, '2025-02-02'),
(3, 3, 200.00, '2025-02-12'),
(4, 4, 1500.00, '2025-03-06'), 
(5, 5, 1200.00, '2025-03-11'); 

-- VIEWs 
CREATE OR REPLACE VIEW vw_active_cases AS
SELECT c.case_id, c.client_id, cl.full_name AS client_name, c.notary_id, n.full_name AS notary_name,
       c.start_date, c.closing_date, c.status
FROM cases c
JOIN clients cl ON c.client_id = cl.client_id
JOIN notaries n ON c.notary_id = n.notary_id
WHERE c.is_archived = 0 AND cl.is_archived = 0 AND n.is_archived = 0;

CREATE OR REPLACE VIEW vw_archived_clients AS
SELECT client_id, full_name, passport_number, phone, email, address, created_at
FROM clients
WHERE is_archived = 1;

CREATE OR REPLACE VIEW agreements_full_view AS
SELECT
    ag.agreement_id,
    ag.case_id,
    ag.service_id,
    srv.service_name,
    srv.price AS service_price,
    ag.amount,
    ag.agreement_date,
    ag.is_archived
FROM agreements ag
INNER JOIN services srv ON ag.service_id = srv.service_id;

CREATE OR REPLACE VIEW services_view AS
SELECT
    service_id,
    service_name,
    description,
    price
FROM services;

CREATE OR REPLACE VIEW notaries_workload_view AS
SELECT
    n.notary_id,
    n.full_name,
    n.position,
    COUNT(c.case_id) AS active_cases
FROM notaries n
LEFT JOIN cases c
        ON n.notary_id = c.notary_id
       AND c.is_archived = 0
       AND c.status = 'Активна'
GROUP BY n.notary_id, n.full_name, n.position;

-- Функції 

DROP FUNCTION IF EXISTS fn_client_total_amount;
DELIMITER $$
CREATE FUNCTION fn_client_total_amount(p_client_id INT) RETURNS DECIMAL(12,2) 
DETERMINISTIC
BEGIN
    DECLARE total DECIMAL(12,2) DEFAULT 0.00;
    SELECT IFNULL(SUM(a.amount),0.00) INTO total
    FROM agreements a
    JOIN cases c ON a.case_id = c.case_id
    WHERE c.client_id = p_client_id AND a.is_archived = 0 AND c.is_archived = 0;
    RETURN total;
END$$
DELIMITER ;

-- Процедури 

DELIMITER $$

-- Додавання клієнта
DROP PROCEDURE IF EXISTS sp_add_client $$
CREATE PROCEDURE sp_add_client( 
    IN p_full_name VARCHAR(150),
    IN p_passport_number VARCHAR(30),
    IN p_phone VARCHAR(30),
    IN p_email VARCHAR(150),
    IN p_address VARCHAR(255)
)
BEGIN
    INSERT INTO clients(full_name, passport_number, phone, email, address)
    VALUES(p_full_name, p_passport_number, p_phone, p_email, p_address);
END$$

-- Оновлення даних клієнта
DROP PROCEDURE IF EXISTS sp_edit_client $$
CREATE PROCEDURE sp_edit_client( 
    IN p_client_id INT,
    IN p_full_name VARCHAR(150),
    IN p_passport_number VARCHAR(30),
    IN p_phone VARCHAR(30),
    IN p_email VARCHAR(150),
    IN p_address VARCHAR(255)
)
BEGIN
    UPDATE clients
    SET full_name = p_full_name,
        passport_number = p_passport_number,
        phone = p_phone,
        email = p_email,
        address = p_address
    WHERE client_id = p_client_id;
END$$

-- Архівування клієнта
DROP PROCEDURE IF EXISTS sp_archive_client $$
CREATE PROCEDURE sp_archive_client(IN p_client_id INT) 
BEGIN
    UPDATE clients SET is_archived = 1 WHERE client_id = p_client_id;
END$$

-- Повернути з архіву
DROP PROCEDURE IF EXISTS sp_unarchive_client $$
CREATE PROCEDURE sp_unarchive_client(IN p_client_id INT) 
BEGIN
    UPDATE clients SET is_archived = 0 WHERE client_id = p_client_id;
END$$

-- Пошук клієнтів
DROP PROCEDURE IF EXISTS sp_search_clients $$
CREATE PROCEDURE sp_search_clients(IN p_keyword VARCHAR(200)) 
BEGIN
    SELECT client_id, full_name, passport_number, phone, email, address, is_archived
    FROM clients
    WHERE full_name LIKE CONCAT('%', p_keyword, '%')
        OR passport_number LIKE CONCAT('%', p_keyword, '%')
        OR phone LIKE CONCAT('%', p_keyword, '%')
        OR email LIKE CONCAT('%', p_keyword, '%');
END$$

-- Додавання нотаріуса
DROP PROCEDURE IF EXISTS sp_add_notary $$
CREATE PROCEDURE sp_add_notary( 
    IN p_full_name VARCHAR(150),
    IN p_position VARCHAR(100),
    IN p_experience INT,
    IN p_phone VARCHAR(30),
    IN p_email VARCHAR(150)
)
BEGIN
    INSERT INTO notaries(full_name, position, experience_years, phone, email)
    VALUES(p_full_name, p_position, p_experience, p_phone, p_email);
END$$

-- Архівування нотаріуса
DROP PROCEDURE IF EXISTS sp_archive_notary $$
CREATE PROCEDURE sp_archive_notary(IN p_notary_id INT) 
BEGIN
    UPDATE notaries SET is_archived = 1 WHERE notary_id = p_notary_id;
END$$

-- Додавання послуги
DROP PROCEDURE IF EXISTS sp_add_service $$
CREATE PROCEDURE sp_add_service( 
    IN p_service_name VARCHAR(150),
    IN p_description TEXT,
    IN p_price DECIMAL(12,2)
)
BEGIN
    INSERT INTO services(service_name, description, price)
    VALUES(p_service_name, p_description, p_price);
END$$

-- Оновлення послуги
DROP PROCEDURE IF EXISTS sp_edit_service $$
CREATE PROCEDURE sp_edit_service( 
    IN p_service_id INT,
    IN p_service_name VARCHAR(150),
    IN p_description TEXT,
    IN p_price DECIMAL(12,2)
)
BEGIN
    UPDATE services
    SET service_name = p_service_name,
        description = p_description,
        price = p_price
    WHERE service_id = p_service_id;
END$$

-- Додавання справи
DROP PROCEDURE IF EXISTS sp_add_case $$
CREATE PROCEDURE sp_add_case( 
    IN p_client_id INT,
    IN p_notary_id INT,
    IN p_start_date DATE,
    IN p_status VARCHAR(50)
)
BEGIN
    INSERT INTO cases(client_id, notary_id, start_date, status)
    VALUES(p_client_id, p_notary_id, p_start_date, p_status);
END$$

-- Архівування справи
DROP PROCEDURE IF EXISTS sp_archive_case $$
CREATE PROCEDURE sp_archive_case(IN p_case_id INT) 
BEGIN
    UPDATE cases SET is_archived = 1, status = 'Архівна' WHERE case_id = p_case_id;
END$$

-- Закриття справи
DROP PROCEDURE IF EXISTS sp_close_case $$
CREATE PROCEDURE sp_close_case(IN p_case_id INT, IN p_closing_date DATE) 
BEGIN
    UPDATE cases SET closing_date = p_closing_date, status = 'Завершена' WHERE case_id = p_case_id;
END$$

-- Додавання угоди
DROP PROCEDURE IF EXISTS sp_add_agreement $$
CREATE PROCEDURE sp_add_agreement( 
    IN p_case_id INT,
    IN p_service_id INT,
    IN p_amount DECIMAL(12,2),
    IN p_agreement_date DATE
)
BEGIN
    INSERT INTO agreements(case_id, service_id, amount, agreement_date)
    VALUES(p_case_id, p_service_id, p_amount, p_agreement_date);
    -- оновлення статусу справи на 'Активна' якщо раніше був інший 
    UPDATE cases SET status = 'Активна' WHERE case_id = p_case_id AND status <> 'Завершена';
END$$

-- Архівування угоди
DROP PROCEDURE IF EXISTS sp_archive_agreement $$
CREATE PROCEDURE sp_archive_agreement(IN p_agreement_id INT) 
BEGIN
    UPDATE agreements SET is_archived = 1 WHERE agreement_id = p_agreement_id;
END$$

-- Пошук угод по клієнту
DROP PROCEDURE IF EXISTS sp_search_agreements_by_client $$
CREATE PROCEDURE sp_search_agreements_by_client(IN p_client_id INT) 
BEGIN
    SELECT a.* , s.service_name, s.price
    FROM agreements a
    JOIN cases c ON a.case_id = c.case_id
    JOIN services s ON a.service_id = s.service_id
    WHERE c.client_id = p_client_id;
END$$

-- Пошук по нотаріусу
DROP PROCEDURE IF EXISTS sp_search_by_notary $$
CREATE PROCEDURE sp_search_by_notary(IN p_notary_id INT) 
BEGIN
    SELECT c.case_id, c.client_id, cl.full_name AS client_name, c.start_date, c.closing_date, c.status,
           a.agreement_id, a.service_id, s.service_name, a.amount, a.agreement_date
    FROM cases c
    LEFT JOIN agreements a ON c.case_id = a.case_id
    LEFT JOIN clients cl ON c.client_id = cl.client_id
    LEFT JOIN services s ON a.service_id = s.service_id
    WHERE c.notary_id = p_notary_id;
END$$

-- Перегляд вартості послуги
DROP PROCEDURE IF EXISTS sp_get_service_price $$
CREATE PROCEDURE sp_get_service_price(IN p_service_id INT) 
BEGIN
    SELECT service_id, service_name, price FROM services WHERE service_id = p_service_id;
END$$

-- Отримати всі дані
DROP PROCEDURE IF EXISTS sp_get_all_clients $$
CREATE PROCEDURE sp_get_all_clients()
BEGIN
    SELECT * FROM clients;
END$$

DROP PROCEDURE IF EXISTS sp_get_all_notaries $$
CREATE PROCEDURE sp_get_all_notaries()
BEGIN
    SELECT * FROM notaries;
END$$

DROP PROCEDURE IF EXISTS sp_get_all_services $$
CREATE PROCEDURE sp_get_all_services()
BEGIN
    SELECT * FROM services;
END$$

DROP PROCEDURE IF EXISTS sp_get_all_cases $$
CREATE PROCEDURE sp_get_all_cases()
BEGIN
    SELECT * FROM cases;
END$$

DROP PROCEDURE IF EXISTS sp_get_all_agreements $$
CREATE PROCEDURE sp_get_all_agreements()
BEGIN
    SELECT * FROM agreements;
END$$

-- Пошук вільних дат нотаріуса на інтервалі
DROP PROCEDURE IF EXISTS sp_notary_free_days $$
CREATE PROCEDURE sp_notary_free_days( 
    IN p_notary_id INT,
    IN p_from_date DATE,
    IN p_to_date DATE
)
BEGIN
    DECLARE cur_date DATE;
    SET cur_date = p_from_date;

    CREATE TEMPORARY TABLE tmp_days (d DATE NOT NULL PRIMARY KEY) ENGINE=Memory;

    WHILE cur_date <= p_to_date DO
        INSERT IGNORE INTO tmp_days VALUES (cur_date);
        SET cur_date = DATE_ADD(cur_date, INTERVAL 1 DAY);
    END WHILE;

    -- Видаляємо дні, де нотаріус має справи 
    DELETE FROM tmp_days
    WHERE EXISTS (
        SELECT 1 FROM cases c
        WHERE c.notary_id = p_notary_id
          AND c.is_archived = 0
          AND (
                (c.closing_date IS NOT NULL AND tmp_days.d BETWEEN c.start_date AND c.closing_date)
              OR (c.closing_date IS NULL AND tmp_days.d = c.start_date) 
          )
    );

    SELECT d AS free_date FROM tmp_days ORDER BY d;

    DROP TEMPORARY TABLE IF EXISTS tmp_days;
END$$

DELIMITER ;

-- Тригери 

-- 1) Після додавання угоди якщо справа була неактивною, встановлюємо статус 'Активна'
DROP TRIGGER IF EXISTS trg_after_insert_agreement;
DELIMITER $$
CREATE TRIGGER trg_after_insert_agreement
AFTER INSERT ON agreements
FOR EACH ROW
BEGIN
    UPDATE cases SET status = 'Активна' WHERE case_id = NEW.case_id AND status <> 'Завершена';
END$$
DELIMITER ;

-- 2) Перевірка дат при вставці справи
DROP TRIGGER IF EXISTS trg_cases_before_insert;
DELIMITER $$
CREATE TRIGGER trg_cases_before_insert
BEFORE INSERT ON cases
FOR EACH ROW
BEGIN
    IF (NEW.closing_date IS NOT NULL AND NEW.start_date > NEW.closing_date) THEN
        SIGNAL SQLSTATE '45000' SET MESSAGE_TEXT = 'Дата початку справи не може бути пізнішою за дату завершення';
    END IF;
END$$
DELIMITER ;

-- 3) Якщо справа закрита, встановлюємо closing_date
DROP TRIGGER IF EXISTS trg_cases_before_update;
DELIMITER $$
CREATE TRIGGER trg_cases_before_update
BEFORE UPDATE ON cases
FOR EACH ROW
BEGIN
    IF (NEW.status = 'Завершена' AND NEW.closing_date IS NULL) THEN
        SET NEW.closing_date = CURDATE();
    END IF;
END$$
DELIMITER ;