CREATE TABLE Produtos (
    Id INT AUTO_INCREMENT PRIMARY KEY,
    Nome VARCHAR(100) NOT NULL,
    Preco DECIMAL(10,2) NOT NULL,
    Descricao TEXT,
    Detalhes TEXT,
    ImagemUrl VARCHAR(255)
);

INSERT INTO Produtos (Nome, Preco, Descricao, Detalhes, ImagemUrl)
VALUES (
    'Engrenagem de Motor',
    189.90,
    'Engrenagem metálica reforçada para motores de alto torque.',
    'Feita em aço carbono. Encaixe padrão industrial.',
    '/img/engrenagem.png'
);
