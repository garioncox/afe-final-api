CREATE TABLE customer (
    id SERIAL PRIMARY KEY,
    surname TEXT,
    email TEXT UNIQUE NOT NULL
);

CREATE TABLE transaction_event (
    id SERIAL PRIMARY KEY,
    amt DECIMAL(10, 2),
    transaction_date DATE NOT NULL,
    transaction_name TEXT,
    customer_id INTEGER,
    FOREIGN KEY (customer_id) REFERENCES customer (id)
);

CREATE TABLE budget (
    id SERIAL PRIMARY KEY,
    budget_name TEXT NOT NULL,
    subcategory_of INTEGER,
    customer_id INTEGER NOT NULL,
    FOREIGN KEY (subcategory_of) REFERENCES budget (id),
    FOREIGN KEY (customer_id) REFERENCES customer (id)
);

CREATE TABLE budget_transaction_event (
    id SERIAL PRIMARY KEY,
    transaction_event_id INTEGER NOT NULL,
    budget_id INTEGER NOT NULL,
    FOREIGN KEY (transaction_event_id) REFERENCES transaction_event (id),
    FOREIGN KEY (budget_id) REFERENCES budget (id)
);

INSERT INTO customer (surname, email) VALUES
('John Doe', 'john.doe@example.com'),
('Mary Smith', 'mary.smith@example.com'),
('Susan Bateman', 'sue.bateman@example.com'),
('Nao Romero', 'nao.romero@example.com');

-- 1: 'Necessities'
-- 2: 'Entertainment'
-- 3: 'Food'
-- 4: 'Pokemon Cards'
INSERT INTO budget (budget_name, subcategory_of, customer_id) VALUES
('Necessities', NULL, 1),
('Entertainment', NULL, 1),
('Food', 1, 1),
('Pokemon Cards', 2, 1);

-- 1: '151 ETB'
-- 2: 'Dr Pepper (6 Pack)'
INSERT INTO transaction_event (transaction_name, amt, transaction_date, customer_id) VALUES
('151 ETB', 50.00, '2024-03-12', 1),
('Dr Pepper (6 Pack)', 7.25, '2024-03-13', 1);

INSERT INTO budget_transaction_event (transaction_event_id, budget_id) VALUES
(1, 4),  -- '151 ETB' goes into 'Pokemon Cards' (id 4)
(1, 2),  -- '151 ETB' goes into 'Entertainment' (id 2)
(2, 3);  -- 'Dr Pepper (6 Pack)' goes into 'Food' (id 3)